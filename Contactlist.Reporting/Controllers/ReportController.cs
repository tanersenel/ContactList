using AutoMapper;
using Contactlist.Reporting.Entities;
using Contactlist.Reporting.Repostories.Interfaces;
using EventBusRabbitMQ.Core;
using EventBusRabbitMQ.Events;
using EventBusRabbitMQ.Producer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Contactlist.Sourcing.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository _reportRepository;
        private readonly ILogger<ReportController> _logger;
        private readonly EventBusRabbitMQProducer _eventBus;
        private readonly IMapper _mapper;

        public ReportController(IReportRepository reportRepository, IMapper mapper, EventBusRabbitMQProducer eventBus, ILogger<ReportController> logger)
        {
            _reportRepository = reportRepository;
            _logger = logger;
            _eventBus = eventBus;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(typeof(Report), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Report>>> GetReports()
        {
            return Ok(await _reportRepository.GetReports());
        }
       
        [HttpGet("{id:length(24)}", Name = "GetReport")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Report), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Report>> GetReport(string id)
        {
            var report = await _reportRepository.GetReport(id);
            if (report == null)
            {
                _logger.LogError($"Contact with id : {id}, hasn't been found in database ");
                return NotFound();
            }
            return Ok(report);
        }
        [HttpPost]
        [ProducesResponseType(typeof(Report), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Report>> CreateReport([FromBody] Report report)
        {
            await _reportRepository.Create(report);
            return CreatedAtRoute("GetReport", new { id = report.UUID }, report);

        }
        [HttpDelete("{id:length(24)}", Name = "DeleteReport")]
        [ProducesResponseType(typeof(Report), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteReport(string id)
        {
            return Ok(await _reportRepository.Delete(id));
        }
        [HttpPost("CompleteReport")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        public async Task<ActionResult> CompleteReport([FromBody] string id)
        {
            Report report = await _reportRepository.GetReport(id);
            if (report == null)
                return NotFound();

            if (report.RaporDurum != (int)RaporDurum.Tamamlandi)
            {
                _logger.LogError("Report can not be completed");
                return BadRequest();
            }

        

            ReportCreateEvents eventMessage = _mapper.Map<ReportCreateEvents>(report);

            try
            {
                _eventBus.Publish(EventBusConstants.ReportCreateQueue, eventMessage);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR Publishing integration event: {EventId} from {AppName}", eventMessage.UUID, "Sourcing");
                throw;
            }

            return Accepted();
        }
        [HttpPost("TestEvent")]
        public ActionResult<ReportCreateEvents> TestEvent()
        {
            ReportCreateEvents eventMessage = new ReportCreateEvents();
            eventMessage.RaporDurum = (int)RaporDurum.Tamamlandi;
            eventMessage.UUID   = Guid.NewGuid().ToString();
            eventMessage.RaporDurumText = "Tamamlandi";
            eventMessage.RaporTarihi = DateTime.Now;
            
            
            try
            {
                _eventBus.Publish(EventBusConstants.ReportCreateQueue, eventMessage);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR Publishing integration event: {EventId} from {AppName}", eventMessage.UUID, "Sourcing");
                throw;
            }

            return Accepted(eventMessage);
        }

    }

}

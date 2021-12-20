using Contactlist.Reporting.Entities;
using Contactlist.Reporting.Repostories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        public ReportController(IReportRepository reportRepository, ILogger<ReportController> logger)
        {
            _reportRepository = reportRepository;
            _logger = logger;
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
    }
       
}

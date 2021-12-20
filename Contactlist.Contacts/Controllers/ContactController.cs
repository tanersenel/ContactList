using Contactlist.Contacts.Entities;
using Contactlist.Contacts.RepoSitories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace Contactlist.Contacts.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        #region Veriables
        private readonly IContactRepository _contactRepository;
        private readonly ILogger<ContactController> _logger;
        #endregion
        #region Constructor
        public ContactController(IContactRepository contactRepository, ILogger<ContactController> logger)
        {
            _contactRepository = contactRepository;
            _logger = logger;
        }
        #endregion
        #region Cruds
        [HttpGet]
        [ProducesResponseType(typeof(Contact),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumareble<Contact>>> GetContacts()
        {
            var contacts = await _contactRepository.GetContacts();
            return Ok(contacts);

        }
        [HttpGet("{id:lenght(24)}",Name ="GetContact")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Contact), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Contact>> GetContact(string id)
        {
            var contact = await _contactRepository.GetContact(id);
            if(contact ==null)
            {
                _logger.LogError($"Contact with id : {id}, hasn't been found in database ");
                return NotFound();
            }
            return Ok(contact);

        }
        [HttpPost]
        [ProducesResponseType(typeof(Contact), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Contact>> CreateContact([FromBody] Contact contact)
        {
            await _contactRepository.Create(contact);
            return CreatedAtRoute("GetContact", new { id = contact.UUID },contact);

        }
        [HttpPut]
        [ProducesResponseType(typeof(Contact), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> UpdateContact([FromBody] Contact contact)
        {
            return Ok(await _contactRepository.Update(contact));
            
        }
        [HttpGet("{id:lenght(24)}", Name = "GetContact")]
        [ProducesResponseType(typeof(Contact), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteContact(string id)
        {
            return Ok(await _contactRepository.Delete(id));
        }
        #endregion 

    }
}

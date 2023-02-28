using Microsoft.AspNetCore.Mvc;
using Server.Domain.Class;
using Server.Domain.IRepository;
using Server.Domain.Services;
using Server.Infra.Data.Repository;

namespace Server.Web.Api.Controllers
{
    [ApiController]
    [Route("api/contact")]
    public class ContactController : Controller
    {
        private readonly ContactService _contactService;
        private readonly IContactRepository _contactRepository;

        public ContactController()
        {
            _contactRepository = new ContactRepository();
            _contactService = new ContactService(_contactRepository);
        }

        [HttpPost]
        public IActionResult PostNewContact(Contact newContact)
        {
            try
            {
                return Ok(_contactService.AddNewContact(newContact));
            }
            catch (Exception e)
            {
                return StatusCode(500, new Answer(500, e.Message));
            }
        }

        [HttpPut]
        public IActionResult PutUpContact(Contact upContact)
        {
            try
            {
                return Ok(_contactService.UpdateContact(upContact));
            }
            catch (Exception e)
            {
                return StatusCode(500, new Answer(500, e.Message));
            }
        }

        [HttpGet]
        public IActionResult GetAllContact()
        {
            try
            {
                return Ok(_contactService.SearchAllContact());
            }
            catch (Exception e)
            {
                return StatusCode(500, new Answer(500, e.Message));
            }
        }

        [HttpGet("filter/{searchFilter}")]
        public IActionResult GetFilterContact(string searchFilter)
        {
            try
            {
                return Ok(_contactService.SearchFilterContact(searchFilter));
            }
            catch (Exception e)
            {
                return StatusCode(500, new Answer(500, e.Message));
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            try
            {
                return Ok(_contactService.DeleteContact(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, new Answer(500, e.Message));
            }
        }


        public class Answer
        {
            public Answer(int status, string mensagem)
            {
                this.Status = status;
                this.Mensagem = mensagem;

            }

            public int Status { get; set; }
            public string Mensagem { get; set; }

        }


    }
}
using Agenda.Application.Interfaces;
using Agenda.Application.Model;
using Agenda.Application.Params;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateContactModel model)
        {
            var result = await _contactService.Register(model);
            return Created(nameof(Post), result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateContactModel model)
        {
            var result = await _contactService.Edit(model);
            return Ok(result);  
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var result = await _contactService.Remove(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] ContactParams contactParams)
        {
            var result = await _contactService.Recover(contactParams);

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var result = await _contactService.RecoverById(id);
            return Ok(result);
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var result = await _contactService.RecoverAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }   
        }

    }
}

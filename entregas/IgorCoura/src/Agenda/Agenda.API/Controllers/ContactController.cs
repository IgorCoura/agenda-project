using Agenda.Application.Interfaces;
using Agenda.Application.Model;
using Agenda.Application.Params;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers
{
    [Route("api/[controller]")]
    public class ContactController : MainController
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateContactModel model)
        {
            if(!ModelState.IsValid) return BadCustomResponse(ModelState);
            var result = await _contactService.Register(model);
            return OkCustomResponse(result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateContactModel model)
        {   
            if (!ModelState.IsValid) return BadCustomResponse(ModelState);
            var result = await _contactService.Edit(model);
            return OkCustomResponse(result);  
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var result = await _contactService.Remove(id);
            return OkCustomResponse(result);
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] ContactParams contactParams)
        {
            var result = await _contactService.Recover(contactParams);

            return OkCustomResponse(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var result = await _contactService.RecoverById(id);
            return OkCustomResponse(result);
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _contactService.RecoverAll();
            return OkCustomResponse(result);
        }

    }
}

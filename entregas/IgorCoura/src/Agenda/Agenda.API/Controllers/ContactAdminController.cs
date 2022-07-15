using Agenda.Application.Constants;
using Agenda.Application.Interfaces;
using Agenda.Application.Model;
using Agenda.Application.Params;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Contact/admin")]
    [Authorize(Roles = Roles.Admin)]
    public class ContactAdminController:MainController
    {
        private readonly IContactService _contactService;

        public ContactAdminController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost("{userId:int}")]
        public async Task<ActionResult> PostAdmin([FromRoute] int userId, [FromBody] CreateContactModel model)
        {
            if (!ModelState.IsValid)
                return BadCustomResponse(ModelState);
            var result = await _contactService.Register(model, userId);
            return OkCustomResponse(result);
        }

        [HttpPut("{userId:int}")]
        public async Task<ActionResult> PutAdmin([FromRoute] int userId, [FromBody] UpdateContactModel model)
        {
            if (!ModelState.IsValid)
                return BadCustomResponse(ModelState);
            var result = await _contactService.Edit(model, userId);
            return OkCustomResponse(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAdmin([FromQuery] int id, [FromQuery] int userId)
        {
            var result = await _contactService.Remove(id, userId);
            return OkCustomResponse(result);
        }

        [HttpDelete("phone")]
        public async Task<ActionResult> DeletePhoneAdmin([FromQuery] int id, [FromQuery] int userId)
        {
            var result = await _contactService.RemovePhone(id, userId);
            return OkCustomResponse(result);
        }

        [HttpGet("search")]
        public async Task<ActionResult> GetAdmin([FromQuery] int userId, [FromQuery] ContactParams contactParams)
        {
            var result = await _contactService.Recover(contactParams, userId);
            var totalItems = await _contactService.GetTotalItems(contactParams, userId);
            return OkPageResponse(totalItems, result);
        }

        [HttpGet]
        public async Task<ActionResult> GetByIdAdmin([FromQuery] int id, [FromQuery] int userId)
        {
            var result = await _contactService.RecoverById(id, userId);
            return OkCustomResponse(result);
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAllAdmin()
        {
            var result = await _contactService.RecoverAll();
            return OkCustomResponse(result);
        }

    }
}

using System.Security.Claims;
using Agenda.Application.Constants;
using Agenda.Application.Interfaces;
using Agenda.Application.Model;
using Agenda.Application.Params;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
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
            var userId = int.Parse(User.FindFirst(ClaimTypes.Sid)!.Value);
            var result = await _contactService.Register(model, userId);
            return OkCustomResponse(result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateContactModel model)
        {   
            if (!ModelState.IsValid) return BadCustomResponse(ModelState);
            var userId = int.Parse(User.FindFirst(ClaimTypes.Sid)!.Value);
            var result = await _contactService.Edit(model, userId);
            return OkCustomResponse(result);  
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.Sid)!.Value);
            var result = await _contactService.Remove(id, userId);
            return OkCustomResponse(result);
        }

        [HttpDelete("phone/{id:int}")]
        public async Task<ActionResult> DeletePhone([FromRoute] int id)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.Sid)!.Value);
            var result = await _contactService.RemovePhone(id, userId);
            return OkCustomResponse(result);
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] ContactParams contactParams)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.Sid)!.Value);
            var result = await _contactService.Recover(contactParams, userId);

            return OkCustomResponse(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.Sid)!.Value);
            var result = await _contactService.RecoverById(id, userId);
            return OkCustomResponse(result);
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAll()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.Sid)!.Value);
            var result = await _contactService.RecoverAll(userId);
            return OkCustomResponse(result);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost("admin/{userId:int}")]
        public async Task<ActionResult> PostAdmin([FromRoute] int userId, [FromBody] CreateContactModel model)
        {
            if (!ModelState.IsValid)
                return BadCustomResponse(ModelState);
            var result = await _contactService.Register(model, userId);
            return OkCustomResponse(result);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut("admin/{userId:int}")]
        public async Task<ActionResult> PutAdmin([FromRoute] int userId,[FromBody] UpdateContactModel model)
        {
            if (!ModelState.IsValid)
                return BadCustomResponse(ModelState);
            var result = await _contactService.Edit(model, userId);
            return OkCustomResponse(result);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpDelete("admin")]
        public async Task<ActionResult> DeleteAdmin([FromQuery] int id, [FromQuery] int userId)
        {
            var result = await _contactService.Remove(id, userId);
            return OkCustomResponse(result);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpDelete("admin/phone")]
        public async Task<ActionResult> DeletePhoneAdmin([FromQuery] int id, [FromQuery] int userId)
        {
            var result = await _contactService.RemovePhone(id, userId);
            return OkCustomResponse(result);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet("admin/search")]
        public async Task<ActionResult> GetAdmin([FromQuery] int userId, [FromQuery] ContactParams contactParams)
        {
            var result = await _contactService.Recover(contactParams, userId);

            return OkCustomResponse(result);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet("admin")]
        public async Task<ActionResult> GetByIdAdmin([FromQuery] int id, [FromQuery]  int userId)
        {
            var result = await _contactService.RecoverById(id, userId);
            return OkCustomResponse(result);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet("admin/all")]
        public async Task<ActionResult> GetAllAdmin()
        {
            var result = await _contactService.RecoverAll();
            return OkCustomResponse(result);
        }

    }
}

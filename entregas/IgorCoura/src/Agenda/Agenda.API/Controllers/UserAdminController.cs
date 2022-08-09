using Agenda.Application.Constants;
using Agenda.Application.Interfaces;
using Agenda.Application.Model;
using Agenda.Application.Params;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("/api/v{version:apiVersion}/User/admin")]
    [Authorize(Roles = Roles.Admin)]
    public class UserAdminController: MainController
    {
        private readonly IUserService _userService;

        public UserAdminController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> PostAdmin([FromBody] CreateUserModel model)
        {
            if (!ModelState.IsValid)
                return BadCustomResponse(ModelState);
            var result = await _userService.Register(model);
            return OkCustomResponse(result);
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutAdmin([FromRoute] int id, [FromBody] UpdateUserModel model)
            {
            if (!ModelState.IsValid)
                return BadCustomResponse(ModelState);
            var result = await _userService.Edit(id, model);
            return OkCustomResponse(result);
        }

        [HttpPut("password/{id:int}")]
        public async Task<ActionResult> PutAdminPassword([FromRoute] int id, [FromBody] UpdatePasswordModel model)
        {
            if (!ModelState.IsValid)
                return BadCustomResponse(ModelState);
            var result = await _userService.EditPassword(id, model);
            return OkCustomResponse(result);
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _userService.RecoverAll();
            return OkCustomResponse(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var result = await _userService.RecoverById(id);
            return OkCustomResponse(result);
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] UserParams userParams)
        {
            var result = await _userService.Recover(userParams);
            var totalitems = await _userService.GetTotalItems(userParams);
            return OkPageResponse(totalitems, result);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var result = await _userService.Remove(id);
            return OkCustomResponse(result);
        }
    }
}

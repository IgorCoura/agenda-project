using System.Security.Claims;
using Agenda.Application.Constants;
using Agenda.Application.Interfaces;
using Agenda.Application.Model;
using Agenda.Application.Params;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers
{
    [Route("/api/[controller]")]
    [Authorize]
    public class UserController : MainController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody] CreateUserModel model)
        {
            if(!ModelState.IsValid) return BadCustomResponse(ModelState);
            model.UserRoleId = 2;
            var result = await _userService.Register(model);
            return OkCustomResponse(result);
        }

        [HttpPost("admin")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<ActionResult> PostAdmin([FromBody] CreateUserModel model)
        {
            if (!ModelState.IsValid)
                return BadCustomResponse(ModelState);
            var result = await _userService.Register(model);
            return OkCustomResponse(result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateUserModel model)
        {
            if (!ModelState.IsValid) return BadCustomResponse(ModelState);
            model.UserRoleId = 2;
            var id = int.Parse(User.FindFirst(ClaimTypes.Sid)!.Value);
            var result = await _userService.Edit(id, model);
            return OkCustomResponse(result);
        }

        [HttpPut("admin/{id:int}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<ActionResult> PutAdmin([FromRoute] int id, [FromBody] UpdateUserModel model)
        {
            if (!ModelState.IsValid)
                return BadCustomResponse(ModelState);
            var result = await _userService.Edit(id, model);
            return OkCustomResponse(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetUser()
        {
            var id = int.Parse(User.FindFirst(ClaimTypes.Sid)!.Value);
            var result = await _userService.RecoverById(id);
            return OkCustomResponse(result);
        }

        [HttpGet("admin/all")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<ActionResult> GetAll()
        {
            var result = await _userService.RecoverAll();
            return OkCustomResponse(result);
        }

        [HttpGet("admin/{id:int}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var result = await _userService.RecoverById(id);
            return OkCustomResponse(result);
        }

        [HttpGet("admin")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<ActionResult> Get([FromQuery] UserParams userParams)
        {
            var result = await _userService.Recover(userParams);
            return OkCustomResponse(result);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete()
        {
            var id = int.Parse(User.FindFirst(ClaimTypes.Sid)!.Value);
            var result = await _userService.Remove(id);
            return OkCustomResponse(result);
        }

        [HttpDelete("admin/{id:int}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var result = await _userService.Remove(id);
            return OkCustomResponse(result);
        }
    }
}

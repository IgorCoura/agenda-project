using Agenda.Application.Interfaces;
using Agenda.Application.Model;
using Agenda.Application.Params;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers
{
    [Route("/api/[controller]")]
    public class UserController : MainController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateUserModel model)
        {
            if(!ModelState.IsValid) return BadCustomResponse(ModelState);
            var result = await _userService.Register(model);
            return OkCustomResponse(result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateUserModel model)
        {
            if (!ModelState.IsValid) return BadCustomResponse(ModelState);
            var result = await _userService.Edit(model);
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
            return OkCustomResponse(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var result = await _userService.Remove(id);
            return OkCustomResponse(result);
        }
    }
}

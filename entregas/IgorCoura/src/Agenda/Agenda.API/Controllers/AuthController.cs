using Agenda.Application.Interfaces;
using Agenda.Application.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers
{
    [Route("api/auth")]
    [Authorize]
    public class AuthController: MainController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> PostAsync([FromBody] LoginModel model)
        {
            var token = await _authService.Login(model);
            return OkCustomResponse(token);
        }

    }
}

using Agenda.Application.Interfaces;
using Agenda.Application.Model;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers
{
    [Route("api/auth")]
    public class AuthController: MainController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] LoginModel model)
        {
            var token = await _authService.Login(model);
            return OkCustomResponse(token);
        }

    }
}

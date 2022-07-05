using Agenda.MVC.Interfaces;
using Agenda.MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthService _authService;

        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(LoginViewModel viewModel)
        {
            var result = await _authService.Login(viewModel);
            return View(viewModel);
        }
    }


}

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Agenda.MVC.Interfaces;
using Agenda.MVC.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.MVC.Controllers
{
    public class LoginController : BaseController
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public LoginController(IAuthService authService, INotificator notificator, IUserService userService) : base(notificator)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var token = await _authService.Login(viewModel);

            if(HasErrors())
                return View(viewModel);

            await CreateCookie(token);

            return Redirect(Url.Action("Index", "Home")!);
        }

        [HttpGet]
        public async Task<ActionResult> RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> RegisterUser(CreateUserViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View();

            await _userService.Register(viewModel);

            if (HasErrors())
            {
                View(viewModel);
            }
            return View("Index");
        }

        public async Task CreateCookie(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var decodedToken = handler.ReadJwtToken(token);
            var claims = new List<Claim>() { new Claim("token", token) };
            claims.AddRange(decodedToken.Claims);

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
                IsPersistent = true,
                RedirectUri = "/"
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }
    }


}

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

            return Redirect(Url.Action("Index", "Contact")!);
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

        [HttpGet]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("Index");
        }

        public async Task CreateCookie(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var decodedToken = handler.ReadJwtToken(token);
            var claims = new List<Claim>() { new Claim("token", token) };
            claims.AddRange(decodedToken.Claims);

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, "name",
                "role");

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

        [Route("erro/{id:length(3,3)}")]
        public IActionResult Errors(int id)
        {
            var modelErro = new ErrorViewModel();

            if (id == 500)
            {
                modelErro.Mensagem = "Ocorreu um erro! Tente novamente mais tarde ou contate nosso suporte.";
                modelErro.Titulo = "Ocorreu um erro!";
                modelErro.ErroCode = id;
            }
            else if (id == 404)
            {
                modelErro.Mensagem = "A página que está procurando não existe! <br />Em caso de dúvidas entre em contato com nosso suporte";
                modelErro.Titulo = "Ops! Página não encontrada.";
                modelErro.ErroCode = id;
            }
            else if(id == 401)
            {
                HttpContext.SignOutAsync();
                return Redirect("Index");
            }
            else if (id == 403)
            {
                modelErro.Mensagem = "Você não tem permissão para fazer isto.";
                modelErro.Titulo = "Acesso Negado";
                modelErro.ErroCode = id;
            }
            else
            {
                return StatusCode(500);
            }

            return View("Error", modelErro);
        }
    }


}

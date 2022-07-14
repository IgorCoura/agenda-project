using Agenda.MVC.Constants;
using Agenda.MVC.Interfaces;
using Agenda.MVC.ViewModel.User;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.MVC.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, INotificator notificator, IMapper mapper) : base(notificator)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        public async Task<ActionResult> Create(CreateUserViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View();

            await _userService.RegisterAdmin(viewModel);

            if (HasErrors())
            {
                View(viewModel);
            }
            return View("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit()
        {
            var user = await _userService.GetUser();
            return View(_mapper.Map<EditUserViewModel>(user));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditUserViewModel model)
        {
            var user = await _userService.Edit(model);
            if (HasErrors())
                return View(model);

            TempData["Sucesso"] = "Perfil alterado com sucesso.";
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> EditPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> EditPassword(EditPasswordViewModel model)
        {
            var user = await _userService.EditPassword(model);
            if (HasErrors())
                return View(model);

            TempData["Sucesso"] = "Senha alterada com sucesso.";
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Delete()
        {
            await _userService.RemoverUser();
            await HttpContext.SignOutAsync();
            return Redirect(Url.ActionLink("index","login")!);
        }
    }
}

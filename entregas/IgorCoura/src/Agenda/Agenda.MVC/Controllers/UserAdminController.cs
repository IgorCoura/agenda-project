using Agenda.MVC.Constants;
using Agenda.MVC.Interfaces;
using Agenda.MVC.Params;
using Agenda.MVC.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.MVC.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class UserAdminController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserAdminController(IUserService userService, INotificator notificator, IMapper mapper) : base(notificator)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var response = await _userService.GetAllAdmin(new UserParams());
            return View(response.ToList());
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var response = await _userService.GetByIdAdmin(id);
            return View(_mapper.Map<EditUserViewModel>(response));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditUserViewModel model)
        {
            await _userService.EditAdmin(model);
            if (HasErrors())
                View(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateUserViewModel model)
        {
            await _userService.RegisterAdmin(model);
            if (HasErrors())
                View(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            await _userService.RemoverByIdAdmin(id);
            return RedirectToAction("Index");
        }
    }
}

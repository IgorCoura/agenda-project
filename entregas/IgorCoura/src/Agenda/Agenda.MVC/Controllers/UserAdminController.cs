using Agenda.MVC.Constants;
using Agenda.MVC.Interfaces;
using Agenda.MVC.Params;
using Agenda.MVC.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public async Task<ActionResult> Index(SearchViewModel<List<UserViewModel>> model, int page = 1)
        {
            var param = new UserParams();
            param.SetParam(model.Key, model.Value);
            param.SetParam("Take", model.Take.ToString());
            param.SetParam("Skip", (model.Take * (page - 1)).ToString());

            var result = await _userService.GetAllAdmin(param);
            var totalPages = (int)Math.Ceiling((decimal)result.TotalItems / model.Take);

            var response = new SearchViewModel<List<UserViewModel>>()
            {

                Data = result.Data.ToList(),
                SearchKeys = new List<SelectListItem>()
                {
                    new SelectListItem("Nome", "Name"),
                    new SelectListItem("Email", "Email"),
                    new SelectListItem("Username", "Username")
                },
                CurrentPage = page,
                TotalPages = totalPages
            };

            return View(response);
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
                return View(model);
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
                return View(model);
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

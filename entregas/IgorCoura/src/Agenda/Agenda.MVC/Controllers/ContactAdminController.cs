using Agenda.MVC.Interfaces;
using Agenda.MVC.Params;
using Agenda.MVC.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Agenda.MVC.Controllers
{
    [Authorize]
    public class ContactAdminController : BaseController
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactAdminController(IContactService contactService, IMapper mapper, INotificator notificator): base(notificator)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Index(SearchViewModel<List<ContactViewModel>> model, int userId, int page = 1)
        {
            var param = new ContactParams();
            param.SetParam("UserId", userId.ToString());
            param.SetParam(model.Key, model.Value);
            param.SetParam("Take", model.Take.ToString());
            param.SetParam("Skip", (model.Take * (page - 1)).ToString());

            var result = await _contactService.GetAllAdmin(param);

            var totalPages = (int)Math.Ceiling((decimal)result.TotalItems / model.Take);

            var response = new SearchViewModel<List<ContactViewModel>>()
            {
                Data = result.Data.ToList(),
                SearchKeys = new List<SelectListItem>()
                {
                    new SelectListItem("Nome", "Name"),
                    new SelectListItem("Número", "Number"),
                    new SelectListItem("DDD", "DDD")
                },
                TotalPages = totalPages,
                CurrentPage = page,

            };
            TempData["userId"] = userId;
            return View(response);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id, int userId)
        {
            await GetPhoneTypes();
            var contact = await _contactService.GetByIdAdmin(id, userId);
            var editContact = _mapper.Map<EditContactViewModel>(contact);
            TempData["userId"] = userId;
            return View(editContact);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditContactViewModel model, int userId,  string option = "save")
        {
            TempData["userId"] = userId;
            await GetPhoneTypes(); 
            model = await EditPhones(model, userId, option);
            if (option.Contains("save"))
            {

                await _contactService.UpdateAdmin(model, userId);

                if (HasErrors())
                    return View(model);

                return RedirectToAction(nameof(Index), new { userId = userId});
            }
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Create(int userId)
        {
            await GetPhoneTypes();
            TempData["userId"] = userId;
            return View(new EditContactViewModel());
        }


        [HttpPost]
        public async Task<ActionResult> Create(EditContactViewModel model, int userId, string option = "save")
        {
            await GetPhoneTypes();
            TempData["userId"] = userId;
            model = await EditPhones(model, userId, option);
            if (option.Contains("save"))
            {
                await _contactService.RegisterAdmin(model, userId);

                if (HasErrors())
                    return View(model);

                return RedirectToAction(nameof(Index), new {userId = userId});
            }
            return View(model);
        }


        private async Task<EditContactViewModel> EditPhones(EditContactViewModel model, int userId, string option)
        {
            
            if (option.Contains("AddPhone"))
            {
                userId = int.Parse(option.Split("|")[1]);
                TempData["userId"] = userId;
                ModelState.Clear();
                model.Phones.Add(new EditPhoneViewModel());
            }
            else if (option.Contains("RemovePhone"))
            {
                var split = option.Split("|");
                var index = int.Parse(split[1]);
                var id = int.Parse(split[2]);
                ModelState.Clear();
                model.Phones.Remove(model.Phones[index]);
                if(id > 0)
                    await _contactService.RemovePhoneAdmin(id, userId);
            }
            return model;
        }

        private async Task GetPhoneTypes()
        {
            var types = await _contactService.GetPhoneTypesAsync();
            var list = new SelectList(types, "Id", "Name");
            ViewBag.PhoneTypes = list;
        }
    }
}

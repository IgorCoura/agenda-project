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
        public async Task<ActionResult> Index(int userId)
        {
            var param = new ContactParams();
            param.SetParam("UserId", userId.ToString());
            param.SetParam("Take", null);
            param.SetParam("Skip", null);
            var result = await _contactService.GetAllAdmin(param);
            var response = new BaseAdminContactViewModel<IEnumerable<ContactViewModel>>()
            {
                UserId = userId,
                Contact = result
            };
            return View(response);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id, int userId)
        {
            await GetPhoneTypes();
            var contact = await _contactService.GetByIdAdmin(id, userId);
            var editContact = _mapper.Map<EditContactViewModel>(contact);
            var response = new BaseAdminContactViewModel<EditContactViewModel>()
            {
                UserId=userId,
                Contact = editContact
            };
            return View(response);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(BaseAdminContactViewModel<EditContactViewModel> viewModel,  string option = "save")
        {
            var model = viewModel.Contact;
            await GetPhoneTypes();
            model = await EditPhones(model, viewModel.UserId, option);
            if (option.Contains("save"))
            {

                await _contactService.UpdateAdmin(model, viewModel.UserId);

                if (HasErrors())
                    return View(model);

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Create(int userId)
        {
            await GetPhoneTypes();
            var response = new BaseAdminContactViewModel<EditContactViewModel>()
            {
                UserId = userId,
                Contact = new EditContactViewModel()
            };
            return View(response);
        }


        [HttpPost]
        public async Task<ActionResult> Create(BaseAdminContactViewModel<EditContactViewModel> viewModel, string option = "save")
        {
            await GetPhoneTypes();
            var model = viewModel.Contact;
            model = await EditPhones(model, viewModel.UserId, option);
            if (option.Contains("save"))
            {

                await _contactService.RegisterAdmin(model, viewModel.UserId);

                if (HasErrors())
                    return View(model);

                return RedirectToAction(nameof(Index), new {userId = viewModel.UserId});
            }
            return View(model);
        }


        private async Task<EditContactViewModel> EditPhones(EditContactViewModel model, int userId, string option)
        {
            
            if (option.Contains("AddPhone"))
            {
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

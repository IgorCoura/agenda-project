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
    public class ContactController : BaseController
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper, INotificator notificator): base(notificator)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var param = new ContactParams();
            param.SetParam("Take", null);
            param.SetParam("Skip", null);
            var result = await _contactService.GetAll(param);
            return View(result);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            await GetPhoneTypes();
            var contact = await _contactService.GetById((int)id);
            return View(_mapper.Map<EditContactViewModel>(contact));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditContactViewModel model, string option = "save")
        {
            await GetPhoneTypes();
            model = await EditPhones(model, option);
            if (option.Contains("save"))
            {

                await _contactService.Update(model);

                if (HasErrors())
                    return View(model);

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            await GetPhoneTypes();
            return View(new EditContactViewModel());
        }


        [HttpPost]
        public async Task<ActionResult> Create(EditContactViewModel model, string option = "save")
        {
            await GetPhoneTypes();
            model = await EditPhones(model, option);
            if (option.Contains("save"))
            {

                //await _contactService.Update(model);

                if (HasErrors())
                    return View(model);

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        private async Task<EditContactViewModel> EditPhones(EditContactViewModel model, string option)
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
                    await _contactService.RemovePhone(id);
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

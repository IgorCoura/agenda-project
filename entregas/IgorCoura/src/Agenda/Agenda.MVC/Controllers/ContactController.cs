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
        public async Task<ActionResult> Index(SearchViewModel<List<ContactViewModel>> model, int page = 1)
        {
            var param = new ContactParams();
            param.SetParam(model.Key, model.Value);
            param.SetParam("Take", model.Take.ToString());
            param.SetParam("Skip", (model.Take * (page - 1)).ToString());

            var result = await _contactService.GetAll(param);
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
                CurrentPage = page,
                TotalPages = totalPages

            };

            return View(response);
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

                await _contactService.Register(model);

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

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            await _contactService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}

using Agenda.MVC.Interfaces;
using Agenda.MVC.Params;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.MVC.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var result = await _contactService.GetAll(new ContactParams());
            return View(result);
        }
    }
}

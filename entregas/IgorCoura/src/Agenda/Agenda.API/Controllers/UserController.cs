using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers
{
    [Route("/api/[controller]")]
    public class UserController : MainController
    {
        [HttpPost]
        public IActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}

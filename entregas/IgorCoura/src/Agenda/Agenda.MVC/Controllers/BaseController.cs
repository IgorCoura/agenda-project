using Agenda.MVC.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.MVC.Controllers
{
    public class BaseController: Controller
    {
        private readonly INotificator _notificator;

        protected BaseController(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected bool HasErrors()
        {
            return _notificator.HasNotifications();
        }
    }
}

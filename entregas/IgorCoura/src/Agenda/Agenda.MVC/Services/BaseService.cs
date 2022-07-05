using Agenda.MVC.Interfaces;
using Agenda.MVC.Notifications;
using Agenda.MVC.ViewModel;
using Flurl.Http;

namespace Agenda.MVC.Services
{
    public class BaseService
    {
        private readonly INotificator _notificador;

        protected BaseService(INotificator notificador)
        {
            _notificador = notificador;
        }

        protected void Notify(string mensagem)
        {
            _notificador.Handle(new Notification(mensagem));
        }

        protected void Notify(IEnumerable<object> mensagens)
        {
            var notifications = mensagens.Select(x => new Notification(x.ToString() ?? "Ocorreu um erro, tente novamente."));
            _notificador.Handle(notifications);
        }

     
    }
}



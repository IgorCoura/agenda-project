using Agenda.MVC.Interfaces;
using Agenda.MVC.Notifications;
using Agenda.MVC.Options;
using Agenda.MVC.ViewModel;
using Flurl.Http;

namespace Agenda.MVC.Services
{
    public class BaseService
    {
        private readonly INotificator _notificador;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ApiSettings _apiSettings;
        protected BaseService(INotificator notificador, IHttpContextAccessor contextAccessor, ApiSettings apiSettings)
        {
            _notificador = notificador;
            _contextAccessor = contextAccessor;
            _apiSettings = apiSettings;
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

        protected IFlurlRequest GetAuthApiUrl()
        {
            if (_contextAccessor.HttpContext!.User.Identity!.IsAuthenticated)
            {
                var token = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "token") ?? throw new InvalidOperationException("O usuario está autenticado, mais com o valor do token null");

                return _apiSettings.Url.WithOAuthBearerToken(token.Value);

            }
            throw new InvalidOperationException("Usuario não está autenticado");
        }


    }
}



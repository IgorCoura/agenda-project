using Agenda.MVC.Interfaces;
using Agenda.MVC.ViewModel;
using Flurl.Http;


namespace Agenda.MVC.Services
{
    public class AuthService: BaseService, IAuthService
    {
        private readonly string _url = "https://localhost:55843/";

        public AuthService(INotificator notificator): base(notificator)
        {

        }

        public async Task<string?> Login(LoginViewModel viewModel)
        {
            var response = await _url.AllowAnyHttpStatus().AppendPathSegment("/api/v1/auth").PostJsonAsync(viewModel);
            var result = await response.GetJsonAsync();

            if (response.StatusCode == 400)
            {
                List<object> erros = result.errors;
                Notify(erros.Select(e => e.ToString()));
                return null;
            }

            return result.data as string;
        }
    }
}

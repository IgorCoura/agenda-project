using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Agenda.MVC.Interfaces;
using Agenda.MVC.ViewModel;
using Flurl.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Agenda.MVC.Options;
using Microsoft.Extensions.Options;

namespace Agenda.MVC.Services
{
    public class AuthService: BaseService, IAuthService
    {
        private readonly ApiSettings _apiSettings;

        public AuthService(INotificator notificator, IHttpContextAccessor contextAccessor, IOptions<ApiSettings> options): base(notificator, contextAccessor, options.Value)
        {
            _apiSettings = options.Value;
        }

        public async Task<string?> Login(LoginViewModel viewModel)
        {
            var response = await _apiSettings.Url.AllowHttpStatus("400-404").AppendPathSegment("/api/v1/auth").PostJsonAsync(viewModel);
            var result = await response.GetJsonAsync();

            if (response.StatusCode == 200)
            {
                return result.data as string;
            }

            Notify(result.errors);
            return null;
           
        }

    }
}

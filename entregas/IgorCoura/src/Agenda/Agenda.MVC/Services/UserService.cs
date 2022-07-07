using Agenda.MVC.Options;
using Agenda.MVC.ViewModel;
using Microsoft.Extensions.Options;
using Flurl.Http;
using Agenda.MVC.Interfaces;
using Agenda.MVC.Params;

namespace Agenda.MVC.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly ApiSettings _apiSettings;

        public UserService(INotificator notificator, IHttpContextAccessor contextAccessor, IOptions<ApiSettings> options) : base(notificator, contextAccessor, options.Value)
        {
            _apiSettings = options.Value;
        }

        public async Task<bool> Register(CreateUserViewModel viewModel)
        {
            await GetAll();
            var response = await  _apiSettings.Url.AllowHttpStatus("400-404").AppendPathSegment("/api/v1/User").PostJsonAsync(viewModel);

            if(response.StatusCode == 200)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> GetAll()
        {
            var parame = new UserParams()
            {
                Name = "Admin Root Application",
                Username = "admin",
                Email = "admin@api.com",
                Take = 1,
            };
            var response = await _apiSettings.Url.WithOAuthBearerToken("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCIsImN0eSI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zaWQiOiIxIiwiZW1haWwiOiJhZG1pbkBhcGkuY29tIiwidW5pcXVlX25hbWUiOiJBZG1pbiBSb290IEFwcGxpY2F0aW9uIiwicm9sZSI6IkFkbWluIiwibmJmIjoxNjU3MDUzMzcwLCJleHAiOjE2NTcwNTY5NzAsImlhdCI6MTY1NzA1MzM3MH0.6-Uj43vVAxy3dJl7Ro26UiDPZwuiAXtVIljEqls3eNg").AppendPathSegment("/api/v1/User/admin").SetQueryParams(parame.Query()).GetJsonAsync();

            return false;
        }
    }
}

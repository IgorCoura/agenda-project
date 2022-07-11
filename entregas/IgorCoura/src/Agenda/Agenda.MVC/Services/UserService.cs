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
            var response = await GetAuthApiUrl().AllowHttpStatus("400-404").AppendPathSegment("/api/v1/User").PostJsonAsync(viewModel);

            if(response.StatusCode == 200)
            {
                return true;
            }

            var result = await response.GetJsonAsync();
            Notify(result.errors);

            return false;
        }


        public async Task<bool> Edit(EditUserViewModel model)
        {
            var response = await GetAuthApiUrl().AllowHttpStatus("400").AppendPathSegment("/api/v1/User").PutJsonAsync(model);
            if(response.StatusCode == 200)
            {
                return true;
            }
            var result = await response.GetJsonAsync();
            Notify(result.errors);
            return false;
        }

        public async Task<bool> EditPassword(EditPasswordViewModel model)
        {
            var response = await GetAuthApiUrl().AllowHttpStatus("400").AppendPathSegment("/api/v1/User/password").PutJsonAsync(model);
            if (response.StatusCode == 200)
            {
                return true;
            }
            var result = await response.GetJsonAsync();
            Notify(result.errors);
            return false;
        }

        public async Task<UserViewModel> GetUser()
        {
            var response = await GetAuthApiUrl().AppendPathSegment("/api/v1/User").GetJsonAsync<BaseResponseViewModel<UserViewModel>>();
            return response.Data;
        }

        public async Task RemoverUser()
        {
            await GetAuthApiUrl().AppendPathSegment("/api/v1/User").DeleteAsync();
        }

        public async Task<bool> RegisterAdmin(CreateUserViewModel viewModel)
        {
            var response = await GetAuthApiUrl().AllowHttpStatus("400-404").AppendPathSegment("/api/v1/User/admin").PostJsonAsync(viewModel);

            if (response.StatusCode == 200)
            {
                return true;
            }

            var result = await response.GetJsonAsync();
            Notify(result.errors);

            return false;
        }

        public async Task<bool> EditAdmin(EditUserViewModel model)
        {
            var response = await GetAuthApiUrl().AllowHttpStatus("400").AppendPathSegment("/api/v1/User/admin/").AppendPathSegment(model.Id).PutJsonAsync(model);
            if (response.StatusCode == 200)
            {
                return true;
            }
            var result = await response.GetJsonAsync();
            Notify(result.errors);
            return false;
        }


        public async Task<UserViewModel> GetByIdAdmin(int id)
        {
            var response = await GetAuthApiUrl().AppendPathSegment("/api/v1/User/admin/").AppendPathSegment(id).GetJsonAsync<BaseResponseViewModel<UserViewModel>>();
            return response.Data;
        }

        public async Task<BasePageResponseViewModel<IEnumerable<UserViewModel>>> GetAllAdmin(UserParams param)
        {
            var response = await GetAuthApiUrl().AppendPathSegment("/api/v1/User/admin").SetQueryParams(param.Query()).GetJsonAsync<BasePageResponseViewModel<IEnumerable<UserViewModel>>>();
            return response;
        }

        public async Task RemoverByIdAdmin(int id)
        {
            await GetAuthApiUrl().AppendPathSegment("/api/v1/User/admin/").AppendPathSegment(id).DeleteAsync();
        }

    }
}

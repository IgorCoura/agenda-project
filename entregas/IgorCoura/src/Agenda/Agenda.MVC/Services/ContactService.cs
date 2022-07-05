using Agenda.MVC.Interfaces;
using Agenda.MVC.Options;
using Agenda.MVC.Params;
using Agenda.MVC.ViewModel;
using Flurl.Http;
using Microsoft.Extensions.Options;

namespace Agenda.MVC.Services
{
    public class ContactService: IContactService
    {
        private readonly ApiSettings _apiSettings;
        private readonly IHttpContextAccessor _contextAccessor;

        public ContactService(IOptions<ApiSettings> options, IHttpContextAccessor contextAccessor)
        {
            _apiSettings = options.Value;
            _contextAccessor = contextAccessor;
        }

        public async Task<IEnumerable<ContactViewModel>> GetAll(ContactParams contactParams)
        {
            var response = await GetAuthApiUrl().AppendPathSegment("/api/v1/Contact").SetQueryParams(contactParams.Query()).GetJsonAsync<BaseResponseViewModel<ContactViewModel>>();
            return response.Data;
        }

        private IFlurlRequest GetAuthApiUrl()
        {
            if (_contextAccessor.HttpContext!.User.Identity!.IsAuthenticated)
            {
                //TODO: Tratar essa exceçao de uma forma melhor 1
                var token = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "token") ?? throw new InvalidOperationException("O usuario está autenticado, mais com o valor do token null");

                return _apiSettings.Url.WithOAuthBearerToken(token.Value);

            }
            //TODO: Tratar essa exceçao de uma forma melhor 2
            throw new InvalidOperationException("Usuario não está autenticado");
        }
    }
}

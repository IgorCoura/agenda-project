using Agenda.MVC.Interfaces;
using Agenda.MVC.Options;
using Agenda.MVC.Params;
using Agenda.MVC.ViewModel;
using Flurl.Http;
using Microsoft.Extensions.Options;

namespace Agenda.MVC.Services
{
    public class ContactService: BaseService, IContactService
    {
        private readonly ApiSettings _apiSettings;
        private readonly IHttpContextAccessor _contextAccessor;

        public ContactService(INotificator notificator, IHttpContextAccessor contextAccessor, IOptions<ApiSettings> options) : base(notificator, contextAccessor, options.Value)
        {
            _apiSettings = options.Value;
            _contextAccessor = contextAccessor;
        }

        public async Task<IEnumerable<ContactViewModel>> GetAll(ContactParams contactParams)
        {
            var response = await GetAuthApiUrl().AppendPathSegment("/api/v1/Contact").SetQueryParams(contactParams.Query()).GetJsonAsync<BaseResponseViewModel<IEnumerable<ContactViewModel>>>();
            return response.Data;
        }

        public async Task<ContactViewModel> GetById(int id)
        {
            var response = await GetAuthApiUrl().AppendPathSegment("/api/v1/Contact/").AppendPathSegment(id).GetJsonAsync<BaseResponseViewModel<ContactViewModel>>();
            return response.Data;
        }

        public async Task Update(EditContactViewModel model)
        {
            var resposne = await GetAuthApiUrl().AppendPathSegment("/api/v1/Contact").AllowHttpStatus("400").PutJsonAsync(model);
            var result = await resposne.GetJsonAsync();
            if(resposne.StatusCode == 200)
            {
                return;
            }
            Notify(result.errors);
        }

        public async Task RemovePhone(int phoneId)
        {
            var resposne = await GetAuthApiUrl().AppendPathSegment("/api/v1/Contact/phone/").AppendPathSegment(phoneId).DeleteAsync();
        }

        public async Task<IEnumerable<EnumerationViewModel>> GetPhoneTypesAsync()
        {
            var response = await GetAuthApiUrl().AppendPathSegment("/api/v1/Contact/phoneTypes").GetJsonAsync<BaseResponseViewModel<IEnumerable<EnumerationViewModel>>>();
            return response.Data;
        }

    }
}

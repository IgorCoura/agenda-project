using Agenda.MVC.Params;
using Agenda.MVC.ViewModel;

namespace Agenda.MVC.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<ContactViewModel>> GetAll(ContactParams contactParams);
        Task<ContactViewModel> GetById(int id);
        Task Update(EditContactViewModel model);
        Task RemovePhone(int phoneId);
        Task<IEnumerable<EnumerationViewModel>> GetPhoneTypesAsync();
    }
}

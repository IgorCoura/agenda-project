using Agenda.MVC.Params;
using Agenda.MVC.ViewModel;

namespace Agenda.MVC.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<ContactViewModel>> GetAll(ContactParams contactParams);
        Task<ContactViewModel> GetById(int id);
        Task<bool> Update(EditContactViewModel model);
        Task<bool> Register(EditContactViewModel model);
        Task RemovePhone(int phoneId);
        Task<IEnumerable<EnumerationViewModel>> GetPhoneTypesAsync();
        Task<IEnumerable<ContactViewModel>> GetAllAdmin(ContactParams contactParams);
        Task<ContactViewModel> GetByIdAdmin(int id, int userId);
        Task<bool> UpdateAdmin(EditContactViewModel model, int userId);
        Task<bool> RegisterAdmin(EditContactViewModel model, int userId);
        Task RemovePhoneAdmin(int id, int userId);
    }
}

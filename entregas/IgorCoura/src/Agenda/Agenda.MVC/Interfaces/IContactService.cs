using Agenda.MVC.Params;
using Agenda.MVC.ViewModel.Base;
using Agenda.MVC.ViewModel.Contact;

namespace Agenda.MVC.Interfaces
{
    public interface IContactService
    {
        Task<BasePageResponseViewModel<IEnumerable<ContactViewModel>>> GetAll(ContactParams contactParams);
        Task<ContactViewModel> GetById(int id);
        Task<bool> Update(EditContactViewModel model);
        Task<bool> Register(EditContactViewModel model);
        Task RemovePhone(int phoneId);
        Task<IEnumerable<EnumerationViewModel>> GetPhoneTypesAsync();
        Task Remove(int contactId);
        Task<BasePageResponseViewModel<IEnumerable<ContactViewModel>>> GetAllAdmin(ContactParams contactParams);
        Task<ContactViewModel> GetByIdAdmin(int id, int userId);
        Task<bool> UpdateAdmin(EditContactViewModel model, int userId);
        Task<bool> RegisterAdmin(EditContactViewModel model, int userId);
        Task RemovePhoneAdmin(int id, int userId);
        Task RemoveContactAdmin(int contactId, int userId);
    }
}

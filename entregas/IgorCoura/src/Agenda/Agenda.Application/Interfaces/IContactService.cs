using Agenda.Application.Model;
using Agenda.Application.Params;
using Agenda.Domain.Interfaces;

namespace Agenda.Application.Interfaces
{
    public interface IContactService
    {
        Task<ContactModel> Register(CreateContactModel contact, int userId);
        Task<ContactModel> Edit(UpdateContactModel contactModel, int userId);
        Task<ContactModel> RecoverById(int id, int? userId = null);
        Task<IEnumerable<ContactModel>> RecoverAll(int? userId = null);
        Task<IEnumerable<ContactModel>> Recover(ContactParams query, int? userId = null);
        Task<ContactModel> Remove(int id, int userId);
        Task<ContactModel> RemovePhone(int id, int userId);
    }
}

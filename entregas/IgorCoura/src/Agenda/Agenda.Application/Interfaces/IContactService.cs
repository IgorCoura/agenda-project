using Agenda.Application.Model;
using Agenda.Application.Params;
using Agenda.Domain.Interfaces;

namespace Agenda.Application.Interfaces
{
    public interface IContactService
    {
        Task<ContactModel> Register(CreateContactModel contact);
        Task<ContactModel> Edit(UpdateContactModel contactModel);
        Task<ContactModel> RecoverById(int id);
        Task<IEnumerable<ContactModel>> RecoverAll();
        Task<IEnumerable<ContactModel>> Recover(ContactParams query);
        Task<ContactModel> Remove(int id);
        Task SaveChangesAsync();
    }
}

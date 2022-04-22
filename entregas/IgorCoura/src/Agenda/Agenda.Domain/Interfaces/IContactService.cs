using Agenda.Domain.Entities;
using Agenda.Domain.Model;
using Agenda.Domain.Params;

namespace Agenda.Domain.Interfaces
{
    public interface IContactService: IUnitOfWork
    {
        ContactModel Register(CreateContactModel contact);
        ContactModel Edit(UpdateContactModel contactModel);
        ContactModel RecoverById(int id);
        IEnumerable<ContactModel> RecoverAll();
        IEnumerable<ContactModel> Recover(ContactParams query);
        ContactModel Remove(int id);
    }
}

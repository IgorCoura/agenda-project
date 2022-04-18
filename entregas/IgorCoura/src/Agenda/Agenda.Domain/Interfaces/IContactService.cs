using Agenda.Domain.Entities;
using Agenda.Domain.Model;

namespace Agenda.Domain.Interfaces
{
    public interface IContactService: IUnitOfWork
    {
        ContactModel Register(CreateContactModel contact);
        ContactModel Edit(UpdateContactModel contactModel);
        ContactModel RecoverById(int id);
        IEnumerable<ContactModel> RecoverAll();
        IEnumerable<ContactModel> Recover(Func<Contact, bool> func);
        ContactModel Remove(int id);
    }
}

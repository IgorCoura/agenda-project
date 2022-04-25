using Agenda.Application.Model;
using Agenda.Application.Params;
using Agenda.Domain.Interfaces;

namespace Agenda.Application.Interfaces
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

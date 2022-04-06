using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaConsole.Entities;
using AgendaConsole.Model;

namespace AgendaConsole.Interfaces
{
    public interface IContactService: IUnitOfWork
    {
        ContactModel Register(CreateContactModel contact);
        ContactModel Edit(UpdateContactModel contactModel);

        ContactModel RecoverById(int id);
        IEnumerable<ContactModel> RecoverAll();
        public IEnumerable<ContactModel> Recover(Func<Contact, bool> func);
        ContactModel Remove(int id);
    }
}

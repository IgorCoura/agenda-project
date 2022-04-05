using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaConsole.Entities;
using AgendaConsole.Model;

namespace AgendaConsole.Interfaces
{
    public interface IContactService
    {
        Task<ContactModel> RegisterAsync(CreateContactModel contact);
        Task<ContactModel> EditAsync(UpdateContactModel contactModel);

        ContactModel RecoverById(int id);
        IEnumerable<ContactModel> RecoverAll();
        public IEnumerable<ContactModel> Recover(Func<Contact, bool> func);
        Task<ContactModel> Remove(int id);
    }
}

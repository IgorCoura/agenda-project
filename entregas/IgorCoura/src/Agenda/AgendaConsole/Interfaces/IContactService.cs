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
        public Task<Contact> RegisterAsync(CreateContactModel contact);
        public void Edit();

        public ContactModel RecoverById(int id);

        public void Remove();
    }
}

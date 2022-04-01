using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaConsole.Entities;
using AgendaConsole.Interfaces;

namespace AgendaConsole.Services
{
    public class ContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<Contact> RegisterAsync(Contact contact)
        {
            var result = await _contactRepository.CreateAsync(contact);
            return result;
        }

        public void Edit()
        {

        }

        public void RecoverById()
        {

        }

        public void Remove()
        {

        }
    }
}

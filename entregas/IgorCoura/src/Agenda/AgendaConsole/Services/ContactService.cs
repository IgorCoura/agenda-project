using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaConsole.Entities;
using AgendaConsole.Interfaces;
using AgendaConsole.Mapper;
using AgendaConsole.Model;

namespace AgendaConsole.Services
{
    public class ContactService: IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<ContactModel> RegisterAsync(CreateContactModel contactModel)
        {
            var contact = contactModel.ToEntity();
            var result = await _contactRepository.CreateAsync(contact);
            return result.ToModel();
        }

        public async Task<ContactModel> EditAsync(UpdateContactModel contactModel)
        {
            var contact = contactModel.ToEntity();
            var result = await _contactRepository.UpdateAsync(contact);
            return result.ToModel();
        }

        public ContactModel RecoverById(int id)
        {
            var result = _contactRepository.GetById(id);
            return result.ToModel();
        }

        public IEnumerable<ContactModel> Recover(Func<Contact, bool> func)
        {
            return _contactRepository.GetAll().Where(func).Select(c => c.ToModel());
        }

        public IEnumerable<ContactModel> RecoverAll()
        {
            return _contactRepository.GetAll().Select(c => c.ToModel());
        }

        public async Task<ContactModel> Remove(int id)
        {
            var result = await _contactRepository.Remove(id);
            return result.ToModel();
        }
    }
}

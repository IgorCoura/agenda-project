using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaConsole.Entities;
using AgendaConsole.Interfaces;
using AgendaConsole.Mapper;
using AgendaConsole.Model;
using AgendaConsole.Utils;

namespace AgendaConsole.Services
{
    public class ContactService: IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public ContactModel Register(CreateContactModel contactModel)
        {
            var contact = contactModel.ToEntity();
            var result = _contactRepository.Create(contact);
            return result.ToModel();
        }

        public ContactModel Edit(UpdateContactModel contactModel)
        {
            var contact = contactModel.ToEntity();
            var result = _contactRepository.Update(contact);
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

        public ContactModel Remove(int id)
        {
            var result = _contactRepository.Remove(id);
            return result.ToModel();
        }

        public async Task SaveChangesAsync()
        {
            await _contactRepository.SaveChangesAsync();
        }
    }
}

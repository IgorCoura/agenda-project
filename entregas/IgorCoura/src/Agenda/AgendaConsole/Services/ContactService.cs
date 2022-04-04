using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaConsole.Entities;
using AgendaConsole.Interfaces;
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

        public async Task<Contact> RegisterAsync(CreateContactModel contactModel)
        {
            var phones = contactModel.Phones.Select(p => new Phone(0, p.Description, p.FormattedPhone, 11, 11)).ToList();
            var contact = new Contact(0, contactModel.Name, phones, DateTime.Now, DateTime.Now);
            var result = await _contactRepository.CreateAsync(contact);
            return result;
        }

        public void Edit()
        {

        }

        public ContactModel RecoverById(int id)
        {
           var entity = _contactRepository.GetById(id);
            var phonesModel = entity.Phones.Select(p =>
            new PhoneModel
            {
                FormattedPhone = p.FormattedPhone,
                Description = p.Description
            }).ToList();
            var contactModel = new ContactModel
            {
                Name = entity.Name,
                Phones = phonesModel
            };
            return contactModel;
        }

        public void Remove()
        {

        }
    }
}

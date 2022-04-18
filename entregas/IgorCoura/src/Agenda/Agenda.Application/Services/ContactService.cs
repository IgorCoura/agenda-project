using Agenda.Application.Mapper;
using Agenda.Domain.Entities;
using Agenda.Domain.Interfaces;
using Agenda.Domain.Model;

namespace Agenda.Application.Services
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

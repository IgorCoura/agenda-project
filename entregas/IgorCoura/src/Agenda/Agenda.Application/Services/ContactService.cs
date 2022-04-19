using Agenda.Domain.Entities;
using Agenda.Domain.Interfaces;
using Agenda.Domain.Model;
using AutoMapper;

namespace Agenda.Application.Services
{
    public class ContactService: IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactService(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public ContactModel Register(CreateContactModel contactModel)
        {
            var contact = _mapper.Map<Contact>(contactModel);
            var result = _contactRepository.Create(contact);
            return _mapper.Map<ContactModel>(result);
        }

        public ContactModel Edit(UpdateContactModel contactModel)
        {
            var contact = _mapper.Map<Contact>(contactModel);
            var result = _contactRepository.Update(contact);
            return _mapper.Map<ContactModel>(result);
        }

        public ContactModel RecoverById(int id)
        {
            var result = _contactRepository.GetById(id);
            return _mapper.Map<ContactModel>(result);
        }

        public IEnumerable<ContactModel> Recover(Func<Contact, bool> func)
        {
            var results = _contactRepository.GetAll().Where(func);
            return _mapper.Map<IEnumerable<ContactModel>>(results);
        }

        public IEnumerable<ContactModel> RecoverAll()
        {
            var results = _contactRepository.GetAll();
            return _mapper.Map<IEnumerable<ContactModel>>(results);
        }

        public ContactModel Remove(int id)
        {
            var result = _contactRepository.Remove(id);
            return _mapper.Map<ContactModel>(result);
        }

        public async Task SaveChangesAsync()
        {
            await _contactRepository.SaveChangesAsync();
        }
    }
}

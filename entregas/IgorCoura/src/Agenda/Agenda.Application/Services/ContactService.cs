using Agenda.Application.Model;
using Agenda.Domain.Entities;
using Agenda.Domain.Interfaces;
using AutoMapper;
using Agenda.Application.Params;
using Agenda.Application.Interfaces;

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

        public async Task<ContactModel> Register(CreateContactModel contactModel)
        {
            var contact = _mapper.Map<Contact>(contactModel);
            //var contact = new Contact() {Name = "jose", Phones = new List<Phone>(), CreatedAt= DateTime.Now, UpdatedAt = DateTime.Now };
            var result = await _contactRepository.RegisterAsync(contact);
            return _mapper.Map<ContactModel>(result);
        }

        public async Task<ContactModel> Edit(UpdateContactModel contactModel)
        {
            var contact = _mapper.Map<Contact>(contactModel);
            var result = await _contactRepository.UpdateAsync(contact);
            return _mapper.Map<ContactModel>(result);
        }

        public async Task<ContactModel> RecoverById(int id)
        {
            var result = await _contactRepository.GetByIdAsync(id);
            return _mapper.Map<ContactModel>(result);
        }

        public async Task<IEnumerable<ContactModel>> Recover(ContactParams query)
        {
            var results = await _contactRepository.GetAllAsyncAsNoTracking(query.Filter());
            return _mapper.Map<IEnumerable<ContactModel>>(results);
        }

        public async Task<IEnumerable<ContactModel>> RecoverAll()
        {
            var results = await _contactRepository.GetAllAsyncAsNoTracking();
            return _mapper.Map<IEnumerable<ContactModel>>(results);
        }

        public async Task<ContactModel> Remove(int id)
        {
            var result = await _contactRepository.DeleteAsync(id);
            return _mapper.Map<ContactModel>(result);
        }

        public async Task SaveChangesAsync()
        {
            await _contactRepository.UnitOfWork.SaveChangesAsync();
        }
    }
}

using Agenda.Application.Model;
using Agenda.Domain.Entities;
using Agenda.Domain.Interfaces;
using AutoMapper;
using Agenda.Application.Params;
using Agenda.Application.Interfaces;
using Agenda.Domain.Interfaces.Repositories;
using Agenda.Domain.Entities.Enumerations;

namespace Agenda.Application.Services
{
    public class ContactService: IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        private readonly IInteractionRepository _interactionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ContactService(IContactRepository contactRepository, IMapper mapper, IInteractionRepository interactionRepository, IUnitOfWork unitOfWork)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
            _interactionRepository = interactionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ContactModel> Register(CreateContactModel contactModel)
        {
            var contact = _mapper.Map<Contact>(contactModel);
            var result = await _contactRepository.RegisterAsync(contact);
            await _interactionRepository.RegisterAsync(new Interaction(InteractionType.CreateContact.Id, $"Criando Contato {result.Name}"));
            await _unitOfWork.CommitAsync();
            return _mapper.Map<ContactModel>(result);
        }

        public async Task<ContactModel> Edit(UpdateContactModel contactModel)
        {
            var contact = _mapper.Map<Contact>(contactModel);
            var result = await _contactRepository.UpdateAsync(contact);
            await _interactionRepository.RegisterAsync(new Interaction(InteractionType.UpdateContact.Id, $"Atualizando Contato com id: {result.Id}"));
            await _unitOfWork.CommitAsync();
            return _mapper.Map<ContactModel>(result);
        }

        public async Task<ContactModel> RecoverById(int id)
        {
            Contact result = await _contactRepository.GetAsync(p => p.Id == id) ?? throw new ArgumentNullException($"Id: {id}, não existe");
            return _mapper.Map<ContactModel>(result);
        }

        public async Task<IEnumerable<ContactModel>> Recover(ContactParams query)
        {
            var results = await _contactRepository.GetAllAsync(query.Filter());
            return _mapper.Map<IEnumerable<ContactModel>>(results);
        }

        public async Task<IEnumerable<ContactModel>> RecoverAll()
        {
            var results = await _contactRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ContactModel>>(results);
        }

        public async Task<ContactModel> Remove(int id)
        {
            var result = await _contactRepository.DeleteAsync(id);
            await _interactionRepository.RegisterAsync(new Interaction(InteractionType.RemoveContact.Id, $"Removendo Contato com id: {result.Id}"));
            await _unitOfWork.CommitAsync();
            return _mapper.Map<ContactModel>(result);
        } 

    }
}

using Agenda.Application.Model;
using Agenda.Domain.Entities;
using Agenda.Domain.Interfaces;
using AutoMapper;
using Agenda.Application.Params;
using Agenda.Application.Interfaces;
using Agenda.Domain.Interfaces.Repositories;
using Agenda.Domain.Entities.Enumerations;
using Microsoft.EntityFrameworkCore;
using Agenda.Application.Exceptions;
using FluentValidation;

namespace Agenda.Application.Services
{
    public class ContactService: IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        private readonly IInteractionRepository _interactionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidatorFactory _validatorFactory;

        public ContactService(IContactRepository contactRepository, IMapper mapper, IInteractionRepository interactionRepository, IUnitOfWork unitOfWork, IValidatorFactory validatorFactory)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
            _interactionRepository = interactionRepository;
            _unitOfWork = unitOfWork;
            _validatorFactory = validatorFactory;
        }

        public async Task<ContactModel> Register(CreateContactModel contactModel)
        {
            var validation = await _validatorFactory.GetValidator<CreateContactModel>().ValidateAsync(contactModel);
            if (!validation.IsValid)
                throw new DomainException(validation);

            var contact = _mapper.Map<Contact>(contactModel);
            var result = await _contactRepository.RegisterAsync(contact);
            await _interactionRepository.RegisterAsync(new Interaction(InteractionType.CreateContact.Id, $"Criando Contato {result.Name}"));
            await _unitOfWork.CommitAsync();
            return _mapper.Map<ContactModel>(result);
        }

        public async Task<ContactModel> Edit(UpdateContactModel contactModel)
        {
            var validation = await _validatorFactory.GetValidator<UpdateContactModel>().ValidateAsync(contactModel);
            if (!validation.IsValid)
                throw new DomainException(validation);
            var entity = _mapper.Map<Contact>(contactModel);
            var result = await _contactRepository.UpdateAsync(entity);
            await _interactionRepository.RegisterAsync(new Interaction(InteractionType.UpdateContact.Id, $"Atualizando Contato {entity.Name}"));
            await _unitOfWork.CommitAsync();

            return _mapper.Map<ContactModel>(result);
        }

        public async Task<ContactModel> RecoverById(int id)
        {
            Contact result =  await _contactRepository.FirstAsync(filter: c => c.Id == id, include: q => q.Include(p => p.Phones)) ?? throw new DomainException("O id {0} não existe.");
            return _mapper.Map<ContactModel>(result);
        }

        public async Task<IEnumerable<ContactModel>> Recover(ContactParams query)
        {
            var results = await _contactRepository.GetDataAsync(filter: query.Filter(), include: q => q.Include(p => p.Phones));
            return _mapper.Map<IEnumerable<ContactModel>>(results);
        }

        public async Task<IEnumerable<ContactModel>> RecoverAll()
        {
            var results = await _contactRepository.GetDataAsync(include: q => q.Include(p => p.Phones));
            return _mapper.Map<IEnumerable<ContactModel>>(results);
        }

        public async Task<ContactModel> Remove(int id)
        {
            var result = await _contactRepository.DeleteAsync(id);
            await _interactionRepository.RegisterAsync(new Interaction(InteractionType.RemoveContact.Id, $"Removendo Contato {result.Name}"));
            await _unitOfWork.CommitAsync();
            return _mapper.Map<ContactModel>(result);
        }



    }
}

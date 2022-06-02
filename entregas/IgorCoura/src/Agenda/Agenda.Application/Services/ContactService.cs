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
using LinqKit;

namespace Agenda.Application.Services
{
    public class ContactService: IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        private readonly IInteractionRepository _interactionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidatorFactory _validatorFactory;
        private readonly IAuthUserService _authUserService;

        public ContactService(IContactRepository contactRepository, IAuthUserService authUserService, IMapper mapper, IInteractionRepository interactionRepository, IUnitOfWork unitOfWork, IValidatorFactory validatorFactory)
        {
            _authUserService = authUserService;
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
                throw new BadRequestException(validation);

            var contact = _mapper.Map<Contact>(contactModel);
            contact.UserId = _authUserService.GetUserId();
            var result = await _contactRepository.RegisterAsync(contact);

            await _interactionRepository.RegisterAsync(new Interaction(InteractionType.CreateContact.Id, $"Criando Contato {result.Name}"));
            await _unitOfWork.CommitAsync();
            return _mapper.Map<ContactModel>(result);
        }

        public async Task<ContactModel> Edit(UpdateContactModel contactModel)
        {
            var validation = await _validatorFactory.GetValidator<UpdateContactModel>().ValidateAsync(contactModel);
            if (!validation.IsValid)
                throw new BadRequestException(validation);

            var entity = _mapper.Map<Contact>(contactModel);
            entity.UserId = _authUserService.GetUserId();
            var result = await _contactRepository.UpdateAsync(entity);

            await _interactionRepository.RegisterAsync(new Interaction(InteractionType.UpdateContact.Id, $"Atualizando Contato {entity.Name}"));
            await _unitOfWork.CommitAsync();

            return _mapper.Map<ContactModel>(result);
        }

        public async Task<ContactModel> RecoverById(int id)
        {
            var userId = _authUserService.GetUserId();
            Contact result =  await _contactRepository.FirstAsync(filter: c => c.Id == id && c.UserId == userId, include: q => q.Include(p => p.Phones)) ?? throw new NotFoundRequestException($"Contato com id: {id} não encontrado.");
            return _mapper.Map<ContactModel>(result);
        }

        public async Task<IEnumerable<ContactModel>> Recover(ContactParams query)
        {
            var userId = _authUserService.GetUserId();
            var filter = query.Filter().And(x => x.UserId == userId);
            var results = await _contactRepository.GetDataAsync(filter: filter, include: q => q.Include(p => p.Phones));
            return _mapper.Map<IEnumerable<ContactModel>>(results);
        }

        public async Task<IEnumerable<ContactModel>> RecoverAll()
        {
            var userId = _authUserService.GetUserId();
            var results = await _contactRepository.GetDataAsync(filter: c=> c.UserId == userId, include: q => q.Include(p => p.Phones));
            return _mapper.Map<IEnumerable<ContactModel>>(results);
        }

        public async Task<ContactModel> Remove(int id)
        {
            var userId = _authUserService.GetUserId();
            var contact = await _contactRepository.FirstAsync(c => c.Id == id && c.UserId == userId) ?? throw new NotFoundRequestException($"Contato com id: {id} não encontrado.");

            await _contactRepository.DeleteAsync(contact);

            await _interactionRepository.RegisterAsync(new Interaction(InteractionType.RemoveContact.Id, $"Removendo Contato {contact.Name}"));
            await _unitOfWork.CommitAsync();

            return _mapper.Map<ContactModel>(contact);
        }



    }
}

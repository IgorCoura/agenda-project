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


        public ContactService(IContactRepository contactRepository, IMapper mapper, IInteractionRepository interactionRepository, IUnitOfWork unitOfWork, IValidatorFactory validatorFactory)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
            _interactionRepository = interactionRepository;
            _unitOfWork = unitOfWork;
            _validatorFactory = validatorFactory;
        }

        public async Task<ContactModel> Register(CreateContactModel contactModel, int? userId = null)
        {
            var contextValidation = new ValidationContext<CreateContactModel>(contactModel);
            contextValidation.RootContextData["userId"] = userId;
            var validation = await _validatorFactory.GetValidator<CreateContactModel>().ValidateAsync(contextValidation);
            if (!validation.IsValid)
                throw new BadRequestException(validation);

            var contact = _mapper.Map<Contact>(contactModel);
            if (userId is not null)
            {
                contact.UserId = (int)userId;
                
            }
                

            var result = await _contactRepository.RegisterAsync(contact);

            await _interactionRepository.RegisterAsync(new Interaction(InteractionType.CreateContact.Id, $"Criando Contato {result.Name}"));
            await _unitOfWork.CommitAsync();
            return _mapper.Map<ContactModel>(result);
        }

        public async Task<ContactModel> Edit(UpdateContactModel contactModel, int? userId = null)
        {
            var entity = await _contactRepository.FirstAsync(e => e.Id == contactModel.Id) ?? throw new NotFoundRequestException($"Contato com id: {contactModel.Id} não encontrado.");
            var contextValidation = new ValidationContext<UpdateContactModel>(contactModel);
            contextValidation.RootContextData["userId"] = userId;
            var validation = await _validatorFactory.GetValidator<UpdateContactModel>().ValidateAsync(contextValidation);
            if (!validation.IsValid)
                throw new BadRequestException(validation);

            _mapper.Map<UpdateContactModel, Contact>(contactModel, entity);
            if (userId is not null)
                entity.UserId = (int)userId;
            var result = await _contactRepository.UpdateAsync(entity);

            await _interactionRepository.RegisterAsync(new Interaction(InteractionType.UpdateContact.Id, $"Atualizando Contato {entity.Name}"));
            await _unitOfWork.CommitAsync();

            return _mapper.Map<ContactModel>(result);
        }

        public async Task<ContactModel> RecoverById(int id, int? userId = null)
        {
            var predicate = PredicateBuilder.New<Contact>();
            if (userId is not null)
                predicate = predicate.And(x => x.UserId == userId);
            predicate = predicate.And(x => x.Id == id);
            Contact result =  await _contactRepository.FirstAsync(filter: predicate, include: q => q.Include(p => p.Phones)) ?? throw new NotFoundRequestException($"Contato com id: {id} não encontrado.");
            return _mapper.Map<ContactModel>(result);
        }

        public async Task<IEnumerable<ContactModel>> Recover(ContactParams query, int? userId)
        {
            var filter = query.Filter();
            if (userId is not null)
                filter = filter.And(x => x.UserId == userId);
            var results = await _contactRepository.GetDataAsync(filter: filter, include: q => q.Include(p => p.Phones));
            return _mapper.Map<IEnumerable<ContactModel>>(results);
        }

        public async Task<IEnumerable<ContactModel>> RecoverAll(int? userId = null)
        {
            ExpressionStarter<Contact>? predicate = null;
            if (userId is not null)
            {
                predicate = PredicateBuilder.New<Contact>();
                predicate = predicate.And(x => x.UserId == userId);
            }
                
            var results = await _contactRepository.GetDataAsync(filter: predicate, include: q => q.Include(p => p.Phones));
            return _mapper.Map<IEnumerable<ContactModel>>(results);
        }

        public async Task<ContactModel> Remove(int id, int? userId = null)
        {
            var predicate = PredicateBuilder.New<Contact>();
            if (userId is not null)
                predicate = predicate.And(x => x.UserId == userId);
            predicate = predicate.And(x => x.Id == id);
            var contact = await _contactRepository.FirstAsync(predicate) ?? throw new NotFoundRequestException($"Contato com id: {id} não encontrado.");

            await _contactRepository.DeleteAsync(contact);

            await _interactionRepository.RegisterAsync(new Interaction(InteractionType.RemoveContact.Id, $"Removendo Contato {contact.Name}"));
            await _unitOfWork.CommitAsync();

            return _mapper.Map<ContactModel>(contact);
        }

        public async Task<ContactModel> RemovePhone(int id, int? userId = null)
        {
            var predicate = PredicateBuilder.New<Contact>();
            if (userId is not null)
                predicate = predicate.And(x => x.UserId == userId);
            predicate = predicate.And(x => x.Phones.Any(p => p.Id == id));

            var contact = await _contactRepository.FirstAsyncAsTracking(predicate, include: q => q.Include(p => p.Phones)) ?? throw new NotFoundRequestException($"Phone com id: {id} não encontrado.");

            var phones = contact.Phones.ToList();
            phones.RemoveAll(p => p.Id == id);
            contact.Phones = phones;

            await _interactionRepository.RegisterAsync(new Interaction(InteractionType.UpdateContact.Id, $"Atualizando Contato {contact.Name}"));
            await _unitOfWork.CommitAsync();

            return _mapper.Map<ContactModel>(contact);
        }



    }
}

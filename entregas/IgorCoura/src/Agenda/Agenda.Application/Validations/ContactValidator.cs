using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Application.Model;
using FluentValidation;
using Agenda.Domain.Interfaces;
using Agenda.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Agenda.Application.Interfaces;
using Agenda.Application.Exceptions;
using System.Text.RegularExpressions;
using Agenda.Application.Utils;

namespace Agenda.Application.Validations
{
    public class BaseContactValidator<T, TPhone>: AbstractValidator<T> where T: BaseContactModel<TPhone> where TPhone : BasePhoneModel
    {
        private readonly IContactRepository _contactRepository;
        public BaseContactValidator(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(200);
            
            RuleFor(x => x.Phones)
                .Must(phones => phones.GroupBy(x => x.FormattedPhone).All(group => group.Count() == 1))
                .WithMessage("Existem telefones duplicados na lista.");
            RuleFor(x => x.Phones)
            .MustAsync(async (contact, phones, context, cancellationToken) =>
            {
                var userId = context.RootContextData["userId"] as int? ?? throw new ArgumentNullException("userId não pode ser null na validação do BaseContactValidator");
                return await VerifyExistingPhones(phones, userId);
            }).WithMessage("Telefone já existe.");
        }

        public async Task<bool> VerifyExistingPhones(
            IEnumerable<TPhone> phones,
            int userId)
        {
            var phoneDB = await _contactRepository.QueryData<Task<IEnumerable<Phone>>>(queryParm: async x => await x.SelectMany(x => x.Phones).ToListAsync(), filter: u => u.UserId == userId);
            foreach(var phone in phones)
            {
                var numberPhone = PhoneUtils.splitFormattedPhone(phone.FormattedPhone);
                if (numberPhone == null)
                    return true;
                if(phone is UpdatePhoneModel)
                {
                    var updatePhoneModel = phone as UpdatePhoneModel;
                    if (phoneDB.Where(x => x.DDD == numberPhone.DDD && x.Number == numberPhone.Number && x.Id != updatePhoneModel!.Id).Any())
                        return false;
                }
                else
                {
                    if (phoneDB.Where(x => x.DDD == numberPhone.DDD && x.Number == numberPhone.Number).Any())
                        return false;
                }
                
            }
            return true;
        }
    }

    public class CreateContactValidator : BaseContactValidator<CreateContactModel, CreatePhoneModel>
    {
        public CreateContactValidator(IContactRepository contactRepository) : base(contactRepository)
        {
            RuleForEach(x => x.Phones)
                .SetValidator(new CreatePhoneValidator());
        }
    }

    public class UpdateContactValidator : BaseContactValidator<UpdateContactModel, UpdatePhoneModel>
    {
        public UpdateContactValidator(IContactRepository contactRepository) : base(contactRepository)
        {
            RuleForEach(x => x.Phones)
                .SetValidator(new UpdatePhoneValidator());
        }
    }
}

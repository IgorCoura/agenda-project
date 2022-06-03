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
                    return await VerifyExistingPhones(phones.Select(x => x.FormattedPhone), userId);
                }).WithMessage("Telefone já existe {PropertyName}: {PropertyValue}");
        }

        public async Task<bool> VerifyExistingPhones(
            IEnumerable<string> phones,
            int userId)
        {
            var correctFormatedPhone = phones.Select(p =>
            {
               var entity = new Phone();
               entity.SetPhone(p);
               return entity.FormattedPhone;
            });
            var response = await _contactRepository.QueryData<Task<IEnumerable<string>>>(queryParm: async x => await x.SelectMany(x => x.Phones).Select(x => x.FormattedPhone).ToListAsync(), filter: u => u.UserId == userId);
            return !response.Any(x => correctFormatedPhone.Contains(x));
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

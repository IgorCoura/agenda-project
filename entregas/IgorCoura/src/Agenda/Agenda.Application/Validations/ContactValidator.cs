using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Application.Model;
using FluentValidation;
using Agenda.Application.Utils;
using Agenda.Domain.Interfaces;

namespace Agenda.Application.Validations
{
    public class BaseContactValidator<T>: AbstractValidator<T> where T: BaseContactModel
    {
        public BaseContactValidator()
        {
            RuleFor(x => x.Name)
                            .NotEmpty()
                            .MaximumLength(200);
        }

        public static async Task<bool> VerifyExistingPhones(
            IEnumerable<string> phones,
            CancellationToken cancellationToken = default)
        {
            var result = false;

            return !result;
        }
    }

    public class CreateContactValidator : BaseContactValidator<CreateContactModel>
    {
        public CreateContactValidator()
        {
            RuleForEach(x => x.Phones)
                .SetValidator(new CreatePhoneValidator());
            RuleFor(x => x.Phones)
                .Must(phones => phones.GroupBy(x => x.FormattedPhone).All(group => group.Count() == 1))
                .WithMessage("Existem telefones duplicados na lista.");

            RuleFor(x => x.Phones)
                .MustAsync((phones, cancellationToken) => VerifyExistingPhones(phones.Select(x => x.FormattedPhone), cancellationToken))
                .WithMessage("Telefone já existe {PropertyName}: {PropertyValue}");
        }
    }

    public class UpdateContactValidator : BaseContactValidator<UpdateContactModel>
    {
        public UpdateContactValidator()
        {
            RuleForEach(x => x.Phones)
                .SetValidator(new UpdatePhoneValidator());
            RuleFor(x => x.Phones)
                .Must(phones => phones.GroupBy(x => x.FormattedPhone).All(group => group.Count() == 1))
                .WithMessage("Existem telefones duplicados na lista.");

            RuleFor(x => x.Phones)
                .MustAsync((phones, cancellationToken) => VerifyExistingPhones(phones.Select(x => x.FormattedPhone), cancellationToken))
                .WithMessage("Telefone já existe {PropertyName}: {PropertyValue}");
        }
    }
}

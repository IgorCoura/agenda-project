using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Application.Model;
using Agenda.Application.Utils;
using Agenda.Domain.Core;
using Agenda.Domain.Entities.Enumerations;
using FluentValidation;

namespace Agenda.Application.Validations
{
    public class BasePhoneValidator<T> : AbstractValidator<T> where T: BasePhoneModel
    {
        public BasePhoneValidator()
        {
            RuleFor(x => x.Description)
                .MinimumLength(2)
                .MaximumLength(200);

            RuleFor(x => x.PhoneTypeId)
                .Must(type => Enumeration.GetAll<PhoneType>().Any(x => x.Id == type))
                .WithMessage("{PropertyName} Tipo de telefone inválido");

            RuleFor(x => x.FormattedPhone)
                .Must(x => PhoneNumberUtils.IsValid(x))
                .WithMessage("{PropertyName}: {PropertyValue} - Formato de telefone inválido: (xx) x?xxxx-xxxx");
        }
    }
    public class CreatePhoneValidator : BasePhoneValidator<CreatePhoneModel>
    {
        public CreatePhoneValidator()
        {
        }
    }

    public class UpdatePhoneValidator : BasePhoneValidator<UpdatePhoneModel>
    {
        public UpdatePhoneValidator()
        {
        }
    }
}

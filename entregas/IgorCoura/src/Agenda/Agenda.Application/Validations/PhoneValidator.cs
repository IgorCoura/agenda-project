using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Agenda.Application.Model;
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
                .WithMessage("Tipo de telefone inválido");

            RuleFor(x => x.FormattedPhone)
                .Must((phone, formatted, context) =>
                {
                    if (phone.PhoneTypeId == 2)
                    {
                        return new Regex(@"^\(?[1-9][0-9]\)? ?(9[0-9])[0-9]{3}\-?[0-9]{4}$").IsMatch(formatted);
                    }
                    else
                    {
                        return new Regex(@"^\(?[1-9][0-9]\)? ?([1-9])[0-9]{3}\-?[0-9]{4}$").IsMatch(formatted);
                    }
                })
                .WithMessage("Formato de telefone inválido. (xx) 9xxxx-xxxx para celular e (xx) xxxx-xxxx para residencial");
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Application.Model;
using Agenda.Domain.Core;
using Agenda.Domain.Entities.Enumerations;
using Agenda.Domain.Interfaces.Repositories;
using FluentValidation;

namespace Agenda.Application.Validations
{
    public class BaseUserValidator<T> : AbstractValidator<T> where T : BaseUserModel
    {
        public BaseUserValidator(IUserRepository userRepository)
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty();

            RuleFor(x => x.Email)
                .MustAsync(async (email, cancellationToken) =>  !(await userRepository.HasAnyAsync(u => u.Email == email, cancellationToken)))
                .WithMessage("Email Já existe um usuário com e-mail informado.");

            RuleFor(x => x.UserName)
                .MinimumLength(3)
                .MaximumLength(50)
                .NotEmpty();

            RuleFor(x => x.UserName)
                .MustAsync(async (username, cancellationToken) => !(await userRepository.HasAnyAsync(u => u.Username == username, cancellationToken)))
                .WithMessage("UserName Já existe um usuário com username informado.");

            RuleFor(x => x.Name)
                .MinimumLength(3)
                .MaximumLength(200)
                .NotEmpty();

            RuleFor(x => x.UserRoleId)
                .Must(type => Enumeration.GetAll<UserRole>().Any(x => x.Id == type))
                .WithMessage("USerRoleId Cargo de usuário inválido");
        }
    }

    public class CreateUserValidator: BaseUserValidator<CreateUserModel>
    {
        public CreateUserValidator(IUserRepository userRepository): base(userRepository)
        {
            RuleFor(x => x.Password)
                .MinimumLength(3)
                .MaximumLength(200)
                .NotEmpty();
            RuleFor(x => x.Password)
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$_!%*?&-])[A-Za-z\d@$!_%*?&-]{8,}$")
                .WithMessage("Senha deve conter o mínimo de oito caracteres, pelo menos uma letra maiúscula, uma letra minúscula, um número e um caractere especial.");
            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password)
                .WithMessage("As senhas devem ser iguais.");
        }
    }

    public class UpdateUserValidator: BaseUserValidator<UpdateUserModel>
    {
        public UpdateUserValidator(IUserRepository userRepository): base(userRepository)
        {

        }
    }
}

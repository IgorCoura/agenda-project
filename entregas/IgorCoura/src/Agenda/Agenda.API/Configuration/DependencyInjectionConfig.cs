using Agenda.Application.Interfaces;
using Agenda.Application.Services;
using Agenda.Application.Validations;
using Agenda.Domain.Entities;
using Agenda.Domain.Interfaces;
using Agenda.Domain.Interfaces.Repositories;
using Agenda.Infrastructure.Repositories;
using Agenda.Infrastructure.Storage;
using Agenda.Infrastructure.UnitOfWork;
using FluentValidation.AspNetCore;

namespace Agenda.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection service)
        {

            service.AddSingleton<IJsonStorage<Interaction>, JsonStorage<Interaction>>();

            service.AddScoped<IUnitOfWork, UnitOfWork>();

            service.AddScoped<IContactRepository, ContactRepository>();
            service.AddScoped<IInteractionRepository, InteractionRepository>();
            service.AddScoped<IUserRepository, UserRepository>();

            service.AddScoped<IAuthService, AuthService>();
            service.AddScoped<IInteractionService, InteractionService>();
            service.AddScoped<IContactService, ContactService>();
            service.AddScoped<IUserService, UserService>();

            service.AddFluentValidation(fv =>
            {
                fv.AutomaticValidationEnabled = false;
                fv.RegisterValidatorsFromAssemblyContaining<CreateContactValidator>();
            });

            return service;
        }
    }
}

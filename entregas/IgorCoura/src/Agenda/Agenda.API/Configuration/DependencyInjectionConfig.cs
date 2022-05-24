using Agenda.Application.Interfaces;
using Agenda.Application.Services;
using Agenda.Domain.Entities;
using Agenda.Domain.Interfaces;
using Agenda.Domain.Interfaces.Repositories;
using Agenda.Infrastructure.Repositories;
using Agenda.Infrastructure.Storage;
using Agenda.Infrastructure.UnitOfWork;

namespace Agenda.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection service)
        {
            


            service.AddSingleton<IJsonStorage<Interaction>, JsonStorage<Interaction>>();

            service.AddTransient<IUnitOfWork, UnitOfWork>();

            service.AddTransient<IContactRepository, ContactRepository>();
            service.AddTransient<IInteractionRepository, InteractionRepository>();
            service.AddTransient<IInteractionService, InteractionService>();
            service.AddTransient<IContactService, ContactService>();


            

            return service;
        }
    }
}

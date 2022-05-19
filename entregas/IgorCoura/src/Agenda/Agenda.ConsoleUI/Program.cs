using Agenda.Application.Mappers;
using Agenda.Application.Services;
using Agenda.ConsoleUI;
using Agenda.ConsoleUI.Views;
using Agenda.Domain.Entities;
using Agenda.Domain.Interfaces;
using Agenda.ConsoleUI.Interfaces;
using Agenda.Application.Interfaces;
using Agenda.Infrastructure.Repositories;
using Agenda.Infrastructure.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Agenda.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Agenda.Domain.Interfaces.Repositories;
using Agenda.Infrastructure.UnitOfWork;

var builder = Host.CreateDefaultBuilder(args);


builder.ConfigureServices((hostContext, services) =>
{
    ConfigureServices(services);
});


builder.Build().Run();


static void ConfigureServices(IServiceCollection service)
{
    service.Configure<JsonStorageOptions>(config =>
    {
        config.FilePath = "\\default_storage.json";
    });

    service.AddDbContext<ApplicationContext>(options =>
       {
           options
               .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AgendaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
               .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution)
               .EnableDetailedErrors()
               .EnableSensitiveDataLogging();
           
       },
       ServiceLifetime.Singleton
    );


    service.AddSingleton<IJsonStorage<Interaction>, JsonStorage<Interaction>>();

    service.AddTransient<IUnitOfWork, UnitOfWork>();

    service.AddTransient<IContactRepository, ContactRepository>();
    service.AddTransient<IInteractionRepository, InteractionRepository>();
    service.AddTransient<IInteractionService, InteractionService>();
    service.AddTransient<IContactService, ContactService>();

    service.AddTransient<RemoveContactView>();
    service.AddTransient<EditContactView>();
    service.AddTransient<QueryContactView>();
    service.AddTransient<CreateContactView>();

    service.AddTransient<ViewsAccessor>(
           serviceProvider => key =>
           {
                switch (key)
               {
                   case "1": return serviceProvider.GetRequiredService<CreateContactView>();
                   case "2": return serviceProvider.GetRequiredService<EditContactView>();
                   case "3": return serviceProvider.GetRequiredService<QueryContactView>();
                   case "4": return serviceProvider.GetRequiredService<RemoveContactView>();
                   default: throw new KeyNotFoundException($"Opção {key} não existe.");
               }
           });

    service.AddAutoMapper(typeof(EntityToModelProfile), typeof(ModelToEntityProfile), typeof(ModelToModelProfile));

    service.AddTransient<MainView>();

    service.AddHostedService<ConsoleHostedService>();

}

public delegate IView ViewsAccessor(string key);

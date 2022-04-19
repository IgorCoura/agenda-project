using Agenda.Application.Mappers;
using Agenda.Application.Services;
using Agenda.ConsoleUI;
using Agenda.ConsoleUI.Views;
using Agenda.Domain.Entities;
using Agenda.Domain.Interfaces;
using Agenda.Infrastructure.Repositories;
using Agenda.Infrastructure.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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

    service.AddSingleton<IJsonStorage<Contact>, JsonStorage<Contact>>();
    service.AddScoped<IContactRepository, ContactRepository>();
    service.AddScoped<IContactService, ContactService>();
   
    service.AddScoped<RemoveContactView>();
    service.AddScoped<EditContactView>();
    service.AddScoped<QueryContactView>();
    service.AddScoped<CreateContactView>();

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
 
    service.AddScoped<MainView>();

    service.AddHostedService<ConsoleHostedService>();

}

public delegate IView ViewsAccessor(string key);

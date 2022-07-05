using Agenda.MVC.Interfaces;
using Agenda.MVC.Notifications;
using Agenda.MVC.Options;
using Agenda.MVC.Services;

namespace Agenda.MVC.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection service, ConfigurationManager configuration)
        {
            service.Configure<ApiSettings>(configuration.GetSection("Api"));

            service.AddScoped<IAuthService, AuthService>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IContactService, ContactService>();
            service.AddHttpContextAccessor();
            service.AddScoped<INotificator, Notificator>();
            return service;
        }
    }
}

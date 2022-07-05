using Microsoft.AspNetCore.Authentication.Cookies;

namespace Agenda.MVC.Configurations
{
    public static class AuthConfiguration
    {
        public static IServiceCollection AddAuthConfiguration(this IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opts =>
            {
                opts.LoginPath = "/Login";
                opts.LogoutPath = "/Logout";
                opts.AccessDeniedPath = "/Home";
            });

            return services;
        }
    }
}

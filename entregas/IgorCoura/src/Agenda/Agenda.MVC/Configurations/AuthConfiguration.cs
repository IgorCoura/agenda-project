using Microsoft.AspNetCore.Authentication.Cookies;

namespace Agenda.MVC.Configurations
{
    public static class AuthConfiguration
    {
        public static IServiceCollection AddAuthConfiguration(this IServiceCollection services)
        {
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            })
            .AddAuthorization()
            .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opts =>
            {
                opts.LoginPath = "/Login";
                opts.LogoutPath = "/Logout";
                opts.AccessDeniedPath = "/erro/403";
            });

            return services;
        }
    }
}

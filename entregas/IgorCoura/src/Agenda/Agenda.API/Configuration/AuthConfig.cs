using System.Text;
using Agenda.Application.Constants;
using Agenda.Application.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Agenda.API.Configuration
{
    public static class AuthConfig
    {
        public static IServiceCollection AddAuthConfig(this IServiceCollection services, ConfigurationManager configuration)
        {
            var settings = configuration.GetSection("Jwt").Get<TokenGeneratorOptions>();

            // authentication
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(settings.SecurityKey)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true
                    };
                });

            // authorization
            services.AddAuthorization(opt =>
            {
                opt.AddPolicy(Roles.Admin, policy => policy.RequireRole(Roles.Admin));
                opt.AddPolicy(Roles.Common, policy => policy.RequireRole(Roles.Common));
            });

            return services;

        }
        
    }
}

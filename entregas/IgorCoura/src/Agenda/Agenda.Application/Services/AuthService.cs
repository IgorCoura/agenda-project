using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Agenda.Application.Exceptions;
using Agenda.Application.Interfaces;
using Agenda.Application.Model;
using Agenda.Application.Options;
using Agenda.Domain.Core;
using Agenda.Domain.Entities.Enumerations;
using Agenda.Domain.Interfaces.Repositories;
using Agenda.Infrastructure.utils;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Agenda.Application.Services
{
    public class AuthService: IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly TokenGeneratorOptions _options;

        public AuthService(IUserRepository userRepository, IOptions<TokenGeneratorOptions> options)
        {
            _userRepository = userRepository;
            _options = options.Value;
        }

        public async Task<string> Login(LoginModel model)
        {
            var user = await _userRepository.FirstAsync(filter: x => x.Username == model.Username) ?? throw new NotFoundRequestException("Username ou senha incorreta.");
            

            if (!PasswordHasher.Verify(model.Password, user.Password))
                throw new BadRequestException(nameof(model.Password), "Username ou senha incorreta.");

            var clains = new List<Claim>()
                {
                    new Claim(ClaimTypes.Sid, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, Enumeration.FromId<UserRole>(user.UserRoleId).Name),
                };

            return await GenerateToken(clains);

        }

        public Task<string> GenerateToken(IEnumerable<Claim> claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_options.SecurityKey);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_options.ExpirationMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            });
            return Task.FromResult(tokenHandler.WriteToken(token));
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Agenda.Application.Model;

namespace Agenda.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string> Login(LoginModel model);

        Task<string> GenerateToken(IEnumerable<Claim> claims);
    }
}

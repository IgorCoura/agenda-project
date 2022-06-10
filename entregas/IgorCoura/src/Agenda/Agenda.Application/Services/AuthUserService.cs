using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Agenda.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Agenda.Application.Services
{
    public class AuthUserService: IAuthUserService
    {
        private readonly ClaimsPrincipal _principal;

        public AuthUserService(IHttpContextAccessor accessor)
        {
            _principal = accessor.HttpContext.User;
        }
        public int GetUserId() =>  IsAuthenticated() ? int.Parse(_principal.FindFirst(ClaimTypes.Sid)!.Value) : 0 ;

        public string GetUserName() => IsAuthenticated() ? _principal.FindFirst(ClaimTypes.Name)!.Value : "";

        public string GetUserEmail() => IsAuthenticated() ? _principal.FindFirst(ClaimTypes.Email)!.Value : "";

        public bool IsAuthenticated() => _principal.Identity!.IsAuthenticated;

    }


}

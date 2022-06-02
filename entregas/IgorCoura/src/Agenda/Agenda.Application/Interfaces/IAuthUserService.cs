using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Application.Interfaces
{
    public interface IAuthUserService
    {
        int GetUserId();

        string GetUserName();

        string GetUserEmail();

        bool IsAuthenticated();
    }
}

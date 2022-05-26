using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Domain.Core;

namespace Agenda.Domain.Entities.Enumerations
{
    public class UserRole: Enumeration
    {
        public static UserRole Admin = new UserRole(1, nameof(Admin));
        public static UserRole Commom = new UserRole(2, nameof(Commom));

        private UserRole() { }
        private UserRole(int id, string name): base(id, name) { }

    }
}

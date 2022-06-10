using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Domain.Core;
using Agenda.Domain.Entities.Enumerations;

namespace Agenda.Domain.Entities
{
    public class User: Register
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserRoleId { get; set; }
        public UserRole UserRole { get; set; }

        public User(){}
        public User(string name, string username, string email, string password, int userRoleId)
        {
            Name = name;
            Username = username;
            Email = email;
            Password = password;
            UserRoleId = userRoleId;
        }

        
    }
}

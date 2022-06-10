using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Application.Model
{
    public record UserModel: BaseUserModel
    {
        public int Id { get; set; }
       
    }
}

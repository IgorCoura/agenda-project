using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaConsole.Model
{
    public class CreateContactModel
    {
        public string Name { get; set; } = string.Empty;
        public IEnumerable<CreatePhoneModel> Phones { get; set; }

    }
}

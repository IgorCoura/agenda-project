using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaConsole.Model
{
    public class ContactModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PhoneModel> Phones { get; set; }
    }
}


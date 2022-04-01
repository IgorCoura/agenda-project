using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaConsole.Entities
{
    public class Contact: Register 
    {
        public Contact(int id, string name, List<Phone> phones, DateTime createdAt, DateTime updatedAt ): base(id, createdAt, updatedAt)
        {
            Name = name;
            Phones = phones;
        }

        public string Name { get; private set; }
        public List<Phone> Phones { get; set; }
    }
}

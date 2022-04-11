using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaConsole.Entities
{
    public class Contact: Register 
    {
        public Contact(string name, List<Phone> phones)
        {
            Name = name;
            Phones = phones;
        }

        public Contact(int id, string name, List<Phone> phones, DateTime createdAt, DateTime updatedAt) : base(id, createdAt, updatedAt)
        {
            Name = name;
            Phones = phones;
        }

        public Contact() { }

        public string Name { get; set; } = string.Empty;
        public IEnumerable<Phone> Phones { get; set; }
    }
}

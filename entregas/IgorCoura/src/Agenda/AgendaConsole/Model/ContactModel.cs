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
        public string Name { get; set; } = string.Empty;
        public List<PhoneModel> Phones { get; set; } = new();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaConsole.Model
{
    public class UpdateContactModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<UpdatePhoneModel> Phones { get; set; } = new();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

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
        public IEnumerable<UpdatePhoneModel> Phones { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

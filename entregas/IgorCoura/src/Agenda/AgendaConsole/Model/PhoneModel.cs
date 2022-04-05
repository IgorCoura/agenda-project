using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaConsole.Model
{
    public class PhoneModel
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string FormattedPhone { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

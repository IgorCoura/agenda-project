using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Application.Model
{
    public record InteractionModel
    {
        public int InteractionTypeId { get; set; }
        public string InteractionType { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}

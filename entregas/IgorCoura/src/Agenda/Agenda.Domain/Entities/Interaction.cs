using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Domain.Core;
using Agenda.Domain.Entities.Enumerations;

namespace Agenda.Domain.Entities
{
    public class Interaction : Register
    {
        public int InteractionTypeId { get; set; }
        public InteractionType InteractionType { get; set; }
        public string Message { get; set; }
        private Interaction() { }
        public Interaction(int interactionTypeId, string message)
        {
            InteractionTypeId = interactionTypeId;
            Message = message;
        }

    }
}

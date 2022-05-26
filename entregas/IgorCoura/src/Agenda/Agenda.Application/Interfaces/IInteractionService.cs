using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Application.Model;

namespace Agenda.Application.Interfaces
{
    public interface IInteractionService
    {
        Task<IEnumerable<InteractionModel>> RecoverAll();

        Task<IEnumerable<InteractionTypeModel>> RecoverTypes();
        Task SaveJsonInteractionsAsync();
    }
}

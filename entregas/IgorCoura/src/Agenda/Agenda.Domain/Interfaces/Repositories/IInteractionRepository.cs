using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Domain.Entities;

namespace Agenda.Domain.Interfaces.Repositories
{
    public interface IInteractionRepository: IBaseRepository<Interaction>
    {
        Task SaveJsonInteractionsAsync();
    }
}

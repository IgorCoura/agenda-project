using System.Linq.Expressions;
using Agenda.Domain.Core;
using Agenda.Domain.Entities;

namespace Agenda.Domain.Interfaces
{
    public interface IContactRepository: IBaseRepository<Contact>
    {
    }
}

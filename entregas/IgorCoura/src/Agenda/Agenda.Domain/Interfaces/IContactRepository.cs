using System.Linq.Expressions;
using Agenda.Domain.Entities;

namespace Agenda.Domain.Interfaces
{
    public interface IContactRepository: IUnitOfWork
    {
        Contact Create(Contact entity);

        Contact Update(Contact entity);

        IEnumerable<Contact> GetAll(Expression<Func<Contact, bool>> filter = null);

        Contact GetById(int id);

        Contact Remove(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaConsole.Entities;

namespace AgendaConsole.Interfaces
{
    public interface IContactRepository: IUnitOfWork
    {
        Contact Create(Contact entity);

        Contact Update(Contact entity);

        IEnumerable<Contact> GetAll();

        Contact GetById(int id);

        Contact Remove(int id);
    }
}

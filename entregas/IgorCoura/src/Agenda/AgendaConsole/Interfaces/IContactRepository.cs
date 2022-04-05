using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaConsole.Entities;

namespace AgendaConsole.Interfaces
{
    public interface IContactRepository
    {
        Task<Contact> CreateAsync(Contact entity);

        Task<Contact> UpdateAsync(Contact entity);

        IEnumerable<Contact> GetAll();

        Contact GetById(int id);

        Task<Contact> Remove(int id);
    }
}

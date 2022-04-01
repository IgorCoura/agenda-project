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
        public Task<Contact> CreateAsync(Contact entity);

        public Task<Contact> UpdateAsync(Contact entity);

        public IEnumerable<Contact> GetAll();

        public Contact GetById(int id);

        public Contact Remove(int id);
    }
}

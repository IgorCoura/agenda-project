using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaConsole.Entities;

namespace AgendaConsole.Interfaces
{
    public interface IJsonStorage<T> where T : Register 
    {
        T Create(T model);
        T Update(T model);
        T Remove(int id);
        IEnumerable<T> GetAll();
        T GetById(int id);
        Task SaveAsync();
    }
}

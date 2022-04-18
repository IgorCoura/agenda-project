using Agenda.Domain.Entities;

namespace Agenda.Domain.Interfaces
{
    public interface IJsonStorage<T> where T : Register 
    {
        int CreateId();
        T Create(T model);
        T Update(T model);
        T Remove(int id);
        IEnumerable<T> GetAll();
        T GetById(int id);
        Task SaveAsync();
    }
}

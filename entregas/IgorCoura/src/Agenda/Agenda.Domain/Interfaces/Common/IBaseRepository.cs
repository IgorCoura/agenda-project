using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Agenda.Domain.Core;

namespace Agenda.Domain.Interfaces
{
    public interface IBaseRepository<T>: IRepository<T> where T : Register
    {
        Task<T> RegisterAsync(T model);
        Task<T> UpdateAsync(T model);
        Task<T> DeleteAsync(int id);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>>? filter = null);
        Task<IEnumerable<T>> GetAllAsyncAsNoTracking(
            Expression<Func<T, bool>>? filter = null);
    }
}

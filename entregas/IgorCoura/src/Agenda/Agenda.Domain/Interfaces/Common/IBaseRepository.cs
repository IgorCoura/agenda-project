using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Agenda.Domain.Core;
using Microsoft.EntityFrameworkCore.Query;

namespace Agenda.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : Register
    {
        Task<T> RegisterAsync(T model);
        Task<T> UpdateAsync(T model);
        Task DeleteAsync(T model);
        Task<T?> FirstAsync(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
        Task<T?> FirstAsyncAsTracking(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
        Task<IEnumerable<T>> GetDataAsync(
            Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>,
            IIncludableQueryable<T, object>>? include = null,
            int? skip = null, int? take = null);
        Task<IEnumerable<T>> GetManyDataAsync(Expression<Func<T, IEnumerable<T>>>? filter = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
        Task<bool> HasAnyAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default(CancellationToken));
    }
}


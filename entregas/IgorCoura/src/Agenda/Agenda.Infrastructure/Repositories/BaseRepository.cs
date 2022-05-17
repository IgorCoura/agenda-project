using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Agenda.Domain.Core;
using Agenda.Domain.Interfaces;
using Agenda.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Register
    {
        protected readonly ApplicationContext _context;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
        }

        public virtual async Task<T> RegisterAsync(T model)
        {
            model.CreatedAt = DateTime.Now;
            model.UpdatedAt = DateTime.Now;
            var result = _context.Set<T>().Add(model).Entity;
            return await Task.FromResult(result);
        }

        public virtual async Task<T> UpdateAsync(T model)
        {
            model.UpdatedAt = DateTime.Now;
            var result = _context.Set<T>().Update(model).Entity;
            return await Task.FromResult(result);
        }

        public virtual async Task<T> DeleteAsync(int id)
        {
            var obj = await _context.Set<T>().FirstOrDefaultAsync(p => p.Id == id);
            if (obj == null)
                throw new InvalidOperationException($"Id: {id} para remover {typeof(T).Name} é invalido");

            var result = _context.Set<T>().Remove(obj);
            return await Task.FromResult(result.Entity);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>>? filter = null)
        {
            if (filter == null)
                return await _context.Set<T>().ToListAsync();
            return await _context.Set<T>().Where(filter).ToListAsync();
        }

        public virtual async Task<T?> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(filter);
        }


    }
}

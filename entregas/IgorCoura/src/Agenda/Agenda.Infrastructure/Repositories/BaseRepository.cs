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
        private readonly ApplicationContext _context;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public virtual async Task<T> RegisterAsync(T model)
        {
            model.CreatedAt = DateTime.Now;
            model.UpdatedAt = DateTime.Now;
            var result = _context.Set<T>().Add(model);
            return await Task.FromResult(result.Entity);
        }

        public virtual async Task<T> UpdateAsync(T model)
        {
            model.UpdatedAt = DateTime.Now;
            var result = _context.Set<T>().Update(model);
            return await Task.FromResult(result.Entity);
        }

        public virtual async Task<T> DeleteAsync(int id)
        {
            var obj = await _context.Set<T>().FirstOrDefaultAsync(p => p.Id == id);
            if (obj == null)
                throw new InvalidOperationException($"Id: {id} para remover {typeof(T).Name} é invalido");

            var result = _context.Set<T>().Remove(obj);
            return await Task.FromResult(result.Entity);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsyncAsNoTracking(
            Expression<Func<T, bool>>? filter = null)
        {
            if (filter == null)
                return await _context.Set<T>().AsNoTracking().ToListAsync();
            return await _context.Set<T>().AsNoTracking().Where(filter).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>>? filter = null)
        {
            if (filter == null)
                return await _context.Set<T>().ToListAsync();
            return await _context.Set<T>().Where(filter).ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(p => p.Id == id) ?? throw new InvalidOperationException($"Id: {id} não encontrado.");
        }
    }
}

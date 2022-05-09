using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Agenda.Domain.Entities;
using Agenda.Domain.Entities.Enumerations;
using Agenda.Domain.Interfaces;
using Agenda.Infrastructure.Context;

namespace Agenda.Infrastructure.Repositories
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(ApplicationContext context) : base(context)
        {
            
        }

        public override async Task<Contact> RegisterAsync(Contact model)
        {
            if (model.Phones.ToList().Any())
                model.Phones.ToList().ForEach(x => { x.CreatedAt = DateTime.Now; x.UpdatedAt = DateTime.Now; });

            return await base.RegisterAsync(model);
        }

        public override async Task<Contact> UpdateAsync(Contact model)
        {
            if (model.Phones.ToList().Any())
                model.Phones.ToList().ForEach(x => {x.UpdatedAt = DateTime.Now; });
            return await base.UpdateAsync(model);
        }

        public override async Task<IEnumerable<Contact>> GetAllAsync(
            Expression<Func<Contact, bool>>? filter = null)
        {
            if (filter == null)
                return await _context.Set<Contact>().Include(p => p.Phones).ThenInclude(p => p.PhoneType).ToListAsync();
            return await _context.Set<Contact>().Where(filter).Include(p => p.Phones).ThenInclude(p => p.PhoneType).ToListAsync();
        }

        public override async Task<Contact?> GetAsync(Expression<Func<Contact, bool>> filter)
        {
            return await _context.Set<Contact>().Include(p => p.Phones).ThenInclude(p => p.PhoneType).FirstOrDefaultAsync(filter);
        }


    }
}

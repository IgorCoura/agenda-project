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
                model.Phones.ToList().ForEach(x => {
                    x.UpdatedAt = DateTime.Now;
                    if (x.Id == 0)
                        x.CreatedAt = DateTime.Now;
                });
            return await base.UpdateAsync(model);
        }


    }
}

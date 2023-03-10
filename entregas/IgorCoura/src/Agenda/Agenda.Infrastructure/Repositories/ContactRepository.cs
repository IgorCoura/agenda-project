using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Agenda.Domain.Entities;
using Agenda.Domain.Entities.Enumerations;
using Agenda.Domain.Interfaces;
using Agenda.Infrastructure.Context;
using System.Text.RegularExpressions;

namespace Agenda.Infrastructure.Repositories
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(ApplicationContext context) : base(context)
        {
            
        }

    }
}

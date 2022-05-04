using Agenda.Domain.Core;
using Agenda.Domain.Entities;
using Agenda.Domain.Entities.Enumerations;
using Agenda.Domain.Interfaces;
using Agenda.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Infrastructure.Context
{
    public class ApplicationContext : DbContext, IUnitOfWork
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<PhoneType> PhoneTypes { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(GetType().Assembly);

            modelBuilder.ApplyConfiguration(new EnumerationMap<PhoneType>());

            modelBuilder
                .Entity<PhoneType>()
                .HasData(Enumeration.GetAll<PhoneType>());
        }

 
    }
}

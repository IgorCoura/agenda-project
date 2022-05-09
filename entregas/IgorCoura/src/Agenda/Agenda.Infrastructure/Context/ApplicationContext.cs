using Agenda.Domain.Core;
using Agenda.Domain.Entities;
using Agenda.Domain.Entities.Enumerations;
using Agenda.Domain.Interfaces;
using Agenda.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Agenda.Infrastructure.Context
{
    public class ApplicationContext : DbContext, IUnitOfWork
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<PhoneType> PhoneTypes { get; set; }
        public DbSet<Interaction> Interactions { get; set; }
        public DbSet<InteractionType> InteractionTypes { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(GetType().Assembly);

            modelBuilder.ApplyConfiguration(new EnumerationMap<PhoneType>());
            modelBuilder.ApplyConfiguration(new EnumerationMap<InteractionType>());

            modelBuilder
                .Entity<PhoneType>()
                .HasData(Enumeration.GetAll<PhoneType>());

            modelBuilder
                .Entity<InteractionType>()
                .HasData(Enumeration.GetAll<InteractionType>());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}

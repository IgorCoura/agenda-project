
using Microsoft.EntityFrameworkCore;
using Agenda.Domain.Core;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infrastructure.Mappings
{
    internal class EnumerationMap<T> : IEntityTypeConfiguration<T> where T : Enumeration
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .ValueGeneratedNever();

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}

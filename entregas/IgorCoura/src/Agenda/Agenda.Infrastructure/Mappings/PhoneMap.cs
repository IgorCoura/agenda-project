using Agenda.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infrastructure.Mappings
{
    public  class PhoneMap: RegisterMap<Phone>
    {
        public override void Configure(EntityTypeBuilder<Phone> builder)
        {
            base.Configure(builder);

            builder
                .HasIndex(x => new {x.DDD, x.Number});


            builder
                .Property(x => x.DDD)
                .IsRequired();


            builder
                .Property(x => x.Number)
                .IsRequired()
                .HasMaxLength(9);

            builder
                .Property(x => x.FormattedPhone)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .HasOne(x => x.PhoneType)
                .WithMany()
                .HasForeignKey(x => x.PhoneTypeId)
                .IsRequired()
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}


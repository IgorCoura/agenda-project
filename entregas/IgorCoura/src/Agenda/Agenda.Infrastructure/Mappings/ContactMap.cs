using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infrastructure.Mappings
{
    public class ContactMap: RegisterMap<Contact>
    {
        public override void Configure(EntityTypeBuilder<Contact> builder)
        {
            base.Configure(builder);
            builder
                .Property(x => x.Name)
                .IsUnicode(false)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .HasMany(x => x.Phones)
                .WithOne(x => x.Contact)
                .HasForeignKey(x => x.ContactId)
                .IsRequired()
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

        }
    }
}

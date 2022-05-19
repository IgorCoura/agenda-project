using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infrastructure.Mappings
{
    public class InteractionMap : RegisterMap<Interaction>
    {
        public override void Configure(EntityTypeBuilder<Interaction> builder)
        {
            base.Configure(builder);

            builder
                .Property(x => x.Message)
                .IsRequired(false)
                .HasMaxLength(200);

            builder
                .HasOne(x => x.InteractionType)
                .WithMany()
                .HasForeignKey(x => x.InteractionTypeId)
                .IsRequired();

        }
    }
}

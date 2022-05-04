using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infrastructure.Mappings
{
    public class RegisterMap<T> : IEntityTypeConfiguration<T> where T : Register
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasIndex(x => x.Id);
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.UpdatedAt).IsRequired();
        }
    }
}

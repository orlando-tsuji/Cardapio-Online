using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Models.Configurations
{
    public class DescontoConfiguration : IEntityTypeConfiguration<Desconto>
    {
        public void Configure(EntityTypeBuilder<Desconto> builder)
        {
            builder.ToTable("Descontos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasMaxLength(150).IsRequired();

            builder.Property(x => x.Percentual).IsRequired();
        }
    }
}
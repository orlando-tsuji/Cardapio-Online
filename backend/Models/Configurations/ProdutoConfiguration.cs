using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Models.Configurations 
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CategoriaId)
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Descricao)
                .HasMaxLength(500)
                .IsRequired();

            builder.HasOne(x => x.Categoria)
                .WithMany()
                .HasForeignKey(x => x.CategoriaId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Property(x => x.Preco)
                .IsRequired();

            builder.Property(x => x.Imagem)
                .HasColumnType("nvarchar(max)");

            builder.Property(x => x.Destaque)
                .IsRequired();

            builder.Property(x => x.Disponivel)
                .IsRequired();

            builder.Property(x => x.Avaliacao)
                .IsRequired();

            builder.Property(x => x.Ingredientes)
                .HasMaxLength(500);

        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using backend.Models;


namespace backend.Data
{
    public class CardapioDbContext : DbContext
    {
        public CardapioDbContext(DbContextOptions<CardapioDbContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Desconto> Descontos { get; set; }
    }
}
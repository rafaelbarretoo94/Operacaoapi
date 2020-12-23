using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Infra
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {

        }
        public DbSet<Venda> Venda { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<ItemVenda> ItensVenda { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Venda>()
                    .HasMany(r => r.ItensVenda);

            modelBuilder.Entity<Venda>()
                .HasOne(r => r.Vendedor);
        }
    }
}


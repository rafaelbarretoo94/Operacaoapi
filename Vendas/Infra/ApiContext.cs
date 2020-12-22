using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {

        }

        public DbSet<Venda> Venda{get;set;}
        public DbSet<ItemVenda> ItemVenda { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }       
        
    }
}
using Microsoft.EntityFrameworkCore;
using TechTestPaymentApi.Entities;

namespace TechTestPaymentApi.Context
{
    public class LojinhaContext : DbContext
    {
        public LojinhaContext(DbContextOptions<LojinhaContext> options ) : base( options ) 
        {
        
        }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }   
    }
}

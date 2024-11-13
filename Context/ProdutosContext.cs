using Microsoft.EntityFrameworkCore;
using backend_thorin.Models;

namespace backend_thorin.Context
{
    public class ProdutosContext : DbContext
    {
        public ProdutosContext(DbContextOptions<ProdutosContext> options) : base(options) { }

        public DbSet<Produto> Produto { get; set; }
        
    }
}
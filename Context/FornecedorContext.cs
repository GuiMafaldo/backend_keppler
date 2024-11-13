using Microsoft.EntityFrameworkCore;
using backend_thorin.Models;

namespace backend_thorin.Context
{
    public class FornecedorContext : DbContext
    {
        public FornecedorContext(DbContextOptions<FornecedorContext> options)
            : base(options)
            {
                
            }

            public DbSet<Fornecedores> Fornecedores { get; set; }
    }
}
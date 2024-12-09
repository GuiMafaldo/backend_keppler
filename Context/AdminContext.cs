using Microsoft.EntityFrameworkCore;
using backend_thorin.Models;

namespace backend_thorin.Context
{
    public class AdminContext : DbContext
    {
        public AdminContext(DbContextOptions<AdminContext> options) : base(options) { }

        public DbSet<Administracao> Administracao { get; set; }
        public DbSet<Colaborador> Colaborador { get; set; }
        
    }
}
using Microsoft.EntityFrameworkCore;
using backend_thorin.Models;

namespace backend_thorin.Context
{
    public class ColaboradorContext : DbContext
    {
        public ColaboradorContext(DbContextOptions<ColaboradorContext> options) : base(options){ }
        
        public DbSet<Colaborador> Colaborador { get; set; }
    }
}
using Microsoft.EntityFrameworkCore;
using backend_thorin.Models;

namespace backend_thorin.Context
{
    public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> options) : base(options) { }

        public DbSet<Clientes> Clientes { get; set; }
    }
}
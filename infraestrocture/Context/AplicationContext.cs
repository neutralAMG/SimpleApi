using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace infraestrocture.Context
{
    public class AplicationContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public AplicationContext(DbContextOptions<AplicationContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-QCIUVPFJ;Database=SimpleApi;User ID=sa;Password=Alejandro23@#; TrustServerCertificate=true;");
        }

    }
}

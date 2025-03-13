using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TasksBackend.Entidades;

namespace TasksBackend
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Llaves primarias compuestas de la tabla intermedia ClienteEquipo
            modelBuilder.Entity<ClientesEquipos>().HasKey(x => new { x.ClienteId, x.EquipoId });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cliente> Clientes { get;set; }
        public DbSet<Equipo> Equipos { get;set; }
        public DbSet<ClientesEquipos> ClientesEquipos { get;set; }

        
    }
}

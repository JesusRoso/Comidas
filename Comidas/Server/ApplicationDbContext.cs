using Comidas.Shared.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Comidas.Server
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComidaPersona>().HasKey(x => new { x.ComidaRapidaId, x.PersonaId });//crear llave primaria compuesta
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<ComidaPersona> ComidasPersonas { get; set; }
    }
}

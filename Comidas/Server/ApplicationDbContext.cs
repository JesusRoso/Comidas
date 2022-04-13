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
            modelBuilder.Entity<ComidasRapidas>().ToTable("ComidasRapidas");
            modelBuilder.Entity<Persona>().ToTable("Persona");
            modelBuilder.Entity<ComidaPersona>().HasKey(x => new { x.ComidaRapidaId, x.PersonaId });//crear llave primaria compuesta
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<ComidaPersona> ComidasPersonas { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public virtual DbSet<ComidasRapidas> ComidasRapidas { get; set; }
    }
}

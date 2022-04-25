using Comidas.Shared.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Comidas.Server
{
    public class ApplicationDbContext : IdentityDbContext
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

            var roleAdminId = "89086180-b978-4f90-9dbd-a7040bc93f41";
            var usuarioAdminId = "cf5fae49-64dc-4da9-8757-52f1e5664c29";


            var roleAdmin = new IdentityRole()
            { Id = roleAdminId, Name = "admin", NormalizedName = "admin" };

            var hasher = new PasswordHasher<IdentityUser>();
            var usuarioAdmin = new IdentityUser()
            { 
                Id = usuarioAdminId, 
                Email = "jdrosof@gmail.com", 
                UserName = "jdrosof@gmail.com", 
                NormalizedUserName = "jdrosof@gmail.com",
                NormalizedEmail = "jdrosof@gmail.com",
                EmailConfirmed = true,
                PasswordHash=hasher.HashPassword(null, "88917be8-cb36-47c5-b072-Cca7ee8d9!ee")};

            //modelBuilder.Entity<IdentityUser>().HasData(usuarioAdmin);
            //modelBuilder.Entity<IdentityUserRole<string>>()
            //    .HasData(new IdentityUserRole<string>() { RoleId = roleAdminId, UserId = usuarioAdminId });
            modelBuilder.Entity<IdentityRole>().HasData(roleAdmin);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<ComidaPersona> ComidasPersonas { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Notificacion> Notificaciones { get; set; }
        public virtual DbSet<ComidasRapidas> ComidasRapidas { get; set; }
    }
}

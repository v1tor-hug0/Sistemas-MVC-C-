using Microsoft.EntityFrameworkCore;
using SistemaAnimal.Models;

namespace SistemaAnimal.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Animal> TabelaAnimal { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>()
            .HasDiscriminator<string>("TipoAnimal")
            .HasValue<Leao>("Leao")
            .HasValue<Elefante>("Elefante");
            base.OnModelCreating(modelBuilder);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using SistemaJogo.Models;

namespace SistemaJogo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Personagem> TabelaPersonagen { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personagem>()
                .HasDiscriminator<string>("Classe")
                .HasValue<Guerreiro>("Guerreiro")
                .HasValue<Mago>("Mago");
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
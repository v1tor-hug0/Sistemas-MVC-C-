using Microsoft.EntityFrameworkCore;
using SistemaFuncionario.Models;

namespace SistemaFuncionario.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }  //Recebe as opcoes de configuracao do banco

        //Direciona a classe curso para a tabela Curso no banco de dados
        public DbSet<Curso> TabelaCurso { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>()
            .HasDiscriminator<string>("TipoCurso")
            .HasValue<Tecnico>("Tecnico")
            .HasValue<Superior>("Superior");
            base.OnModelCreating(modelBuilder);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using MVC_3.Models;

namespace MVC_3.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        // recebe as opções de configuração do banco

        // direciona a classe (Funcionario) para a tabela (TabelaFuncionario)
        public DbSet<Veiculo> TabelaVeiculo { get; set; }

        // sobrescrever o mapeamento do modelo (uma unica tabela para funcionários)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Veiculo>() // começa a configurar a entidade base Funcionario
            .HasDiscriminator<string>("Tipo") // cria uma única tabela, diferenciando Gerente e Vendedor por cargo
            .HasValue<Carro>("Carro") // quando a instancia for gerente, grava "gerente" em cargo
            .HasValue<Moto>("Moto"); // quando a instancia for vendedor, grava "vendedor" em cargo
        }
    }
}
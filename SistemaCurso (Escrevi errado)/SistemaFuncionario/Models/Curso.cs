using System.ComponentModel.DataAnnotations;

namespace SistemaFuncionario.Models
{
    public abstract class Curso
    {
        [Key]
        public int Id { get; set; }
        public string nome { get; set; } = string.Empty;
        public int horas { get; set; }

        public Curso() { }

        public Curso(string nomeC, int horasC)
        {
            this.nome = nomeC;
            this.horas = horasC;
        }

        public abstract double CalcularPreco();
        public void ExibirResumo()
        {
            Console.WriteLine($"Nome do curso: {nome}");
            Console.WriteLine($"Horas Semanais: {horas}");
            CalcularPreco();
        }
    }
}
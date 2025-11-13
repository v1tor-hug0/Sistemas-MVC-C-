using System.ComponentModel.DataAnnotations;

namespace SistemaJogo.Models
{
    public abstract class Personagem
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Nivel { get; set; }
         public int Poder { get; set; }

        public Personagem() { }
         
        public Personagem(string nomeC, int nivelC)
        {
            Nome = nomeC;
            Nivel = nivelC;
        }
      
        public abstract double CalcularPoder();

        public void ExibirStatus()
        {
            CalcularPoder();
            Console.WriteLine("*** STATUS ***");
            Console.WriteLine($"Nome: {Nome} \n Nivel: {Nivel} \n Poder: {Poder}");
        }
    }
}
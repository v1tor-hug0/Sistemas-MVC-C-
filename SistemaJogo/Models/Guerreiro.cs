namespace SistemaJogo.Models
{
     public class Guerreiro : Personagem
    {

        public Guerreiro() {}

        public Guerreiro(string nomeC, int nivelC)
        {
            Nome = nomeC;
            Nivel = nivelC;
        }

        public override double CalcularPoder()
        {
          return  Poder = Nivel * 10;
        }
        
    }
}
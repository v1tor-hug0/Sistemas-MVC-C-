namespace SistemaJogo.Models
{
    public class Mago : Personagem
    {

        public Mago() {}

        public Mago (string nomeC, int nivelC)
        {
            Nome = nomeC;
            Nivel = nivelC;
        }

        public override double CalcularPoder()
        {
           return Poder = Nivel * 8 + 20;
        }
    }
}
namespace SistemaAnimal.Models
{
    public class Leao : Animal
    {
        public Leao()
        {
        }

        public Leao(string Cnome)
        {
            nome = Cnome;
        }

        public override String Alimentacao()
        {
           return(" Carnivoro");
        }

        public override String EmitirSom()
        {
           return(" Rugido");
        }
    }
}
namespace SistemaAnimal.Models
{
    public class Elefante : Animal
    {

        public Elefante()
        {
        }

        public Elefante(string Cnome)
        {
            nome = Cnome;
        }

         public override String Alimentacao()
        {
            return (" Herbivoro");
        }

        public override String EmitirSom()
        {
           return (" Barrito");
        }
    }
}
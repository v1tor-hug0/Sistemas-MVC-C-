namespace SistemaAnimal.Models
{
    public abstract class Animal
    {
        public int id { get; set; }
        public string nome { get; set; } = string.Empty;

        public Animal()
        {
        }

        public Animal(string Cnome)
        {
            nome = Cnome;
        }

        public abstract String EmitirSom();
        public abstract String Alimentacao();
    }
}
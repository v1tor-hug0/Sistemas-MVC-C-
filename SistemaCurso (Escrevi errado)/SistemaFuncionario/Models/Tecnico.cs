namespace SistemaFuncionario.Models
{
    public class Tecnico : Curso
    {

        //Metodo de sobrecarga
        public Tecnico() { }


        public Tecnico(string nomeC, int horasC) : base(nomeC, horasC)
        {
            nome = nomeC;
            horas = horasC;
        }

        //Metodo sobrescrito
        public override double CalcularPreco()
        {
           return horas * 20;
        }           
    }
}
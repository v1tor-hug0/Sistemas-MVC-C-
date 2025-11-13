namespace SistemaFuncionario.Models
{
    public class Superior : Curso
    {

        public Superior() { }

        public Superior(string nomeC, int horasC) : base(nomeC, horasC)
        {
            nome = nomeC;
            horas = horasC;
        }

        public override double CalcularPreco()
        {
           return horas * 40;
        }     
    }
}
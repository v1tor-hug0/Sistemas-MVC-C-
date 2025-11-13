namespace MVC_3.Models
{
    public class Carro : Veiculo
    {
        public double custo;

        public Carro() : base() // ← IMPORTANTE
    {
    }

        public Carro (string CModelo, int CAno) : base (CModelo, CAno)
        {
            
        }

        public override string CalcularRevisao()
        {
            custo = 500;
            return$"Custo da revisao: {custo}";
        }



    }
}
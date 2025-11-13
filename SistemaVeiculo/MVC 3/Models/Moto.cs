namespace MVC_3.Models
{
     public class Moto : Veiculo
    {
        public double custo;

        public Moto() : base()
        {} // ← IMPORTANTE

        public Moto (string CModelo, int CAno) : base (CModelo, CAno)
        {
            
        }

        public override string CalcularRevisao()
        {
            custo = 300;
            return$"Custo da revisao: {custo}";
        }

    }
}
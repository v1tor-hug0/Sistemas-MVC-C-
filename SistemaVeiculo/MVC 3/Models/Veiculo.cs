namespace MVC_3.Models
{
    public abstract class Veiculo
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }

        public Veiculo() { }

        public Veiculo (string CModelo, int CAno)
        {
            Modelo = CModelo;
            Ano = CAno;
        }

        public abstract string CalcularRevisao();

        public void ExibirResumo()
        {
            Console.WriteLine($" *** Resumo ***");
            Console.WriteLine($"Modelo: {Modelo} \n Ano: {Ano}");
            CalcularRevisao();
        }
        
    }
}
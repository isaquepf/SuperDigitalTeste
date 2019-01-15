namespace SuperDigital.InternetBanking.application.Resources
{
    public class OperacaoResource
    {
        public ContaResource Origem { get; set; }

        public ContaResource Destino { get; set; }

        public decimal Valor { get; set; }
    }


}

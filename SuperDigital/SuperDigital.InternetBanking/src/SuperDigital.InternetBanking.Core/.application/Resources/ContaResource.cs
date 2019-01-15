namespace SuperDigital.InternetBanking.application.Resources
{
    public class ContaResource
    {
        public string Banco { get; set; }

        public int Agencia { get; set; }

        public string Numero { get; set; }

        public int Digito { get; set; }

        /// <summary>
        /// Pré supondo que o ATM controlará o saldo.
        /// </summary>
        public decimal Saldo { get; set; }
    }


}

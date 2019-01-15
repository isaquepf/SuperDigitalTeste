using System;

namespace SuperDigital.InternetBanking.Core.domain.bounded_context.Contas
{
    public abstract class Conta
    {
        public Guid Id { get; protected set; }

        public string Banco { get; protected set; }

        public int Agencia { get; protected set; }

        public string Numero { get; protected set; }

        public int Digito { get; protected set; }

        public TipoConta Tipo { get; protected set; }

        public decimal Saldo { get; protected set; }

        public abstract void Debitar(decimal valor);

        public abstract void Creditar(decimal valor);

        public abstract Conta ComSaldoInicial(decimal valor);

    }
}

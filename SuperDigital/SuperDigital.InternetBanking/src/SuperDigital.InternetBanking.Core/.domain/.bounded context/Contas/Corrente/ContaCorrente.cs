using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.InternetBanking.Core.domain.bounded_context.Contas.Corrente
{
    public class ContaCorrente : Conta
    {
        private ContaCorrente() { }


        public static ContaCorrente Criar(string banco, int agencia, string numero, int digito)
        {
            if (string.IsNullOrEmpty(banco))
                throw new ArgumentException("O nome do banco deve ser preenchido.");

            if (agencia.ToString().Length < 3)
                throw new ArgumentException("Agência inválida por favor preencha corretamente.");

            if (numero.Length < 6)
                throw new ArgumentException("Número de conta inválida por favor preencha corretamente.");

            var conta = new ContaCorrente
            {
                Banco = banco,
                Agencia = agencia,
                Numero = numero,
                Digito = digito,
                Tipo = TipoConta.CORRENTE
            };

            return conta;
        }



        public override void Creditar(decimal valor)
        {
            if (valor < 0)
                throw new ArgumentException("Não é permitido depósito de valor negativo.");

            Saldo += valor;            
        }

        public override void Debitar(decimal valor)
        {
            if (valor < 0)
                throw new ArgumentException("Não é permitido creditar valor negativo.");

            if (Saldo <= 0 || Saldo < valor)
                throw new ArgumentException("Saldo insuficiente");

            Saldo -= valor;            
        }

        public override Conta ComSaldoInicial(decimal valor)
        {
            Saldo = valor;

            return this;
        }
    }
}

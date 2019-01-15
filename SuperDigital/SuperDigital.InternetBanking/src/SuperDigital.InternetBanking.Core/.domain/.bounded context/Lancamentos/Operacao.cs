using SuperDigital.InternetBanking.Core.domain.bounded_context.Contas;
using SuperDigital.InternetBanking.Core.domain.bounded_context.Lancamentos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.InternetBanking.Core.domain.bounded_context
{
    public class Operacao
    {
        public Conta ContaOrigem { get; private set; }

        public Conta ContaDestino { get; private set; }

        public TipoOperacao Tipo { get; private set; }

        public DateTime DateCriacao { get; private set; }

        private Operacao() { }

        public static Operacao EfetuarOperacao(Conta origem, Conta destino, decimal valor
            , TipoOperacao tipo)
        {
            if (tipo == TipoOperacao.Credito)
            {
                origem.Creditar(valor);
                destino.Debitar(valor);
            }

            if (tipo == TipoOperacao.Debito)
            {
                origem.Debitar(valor);
                destino.Creditar(valor);
            }
            
            var operacao = new Operacao
            {
                ContaOrigem = origem,
                ContaDestino = destino,
                Tipo = tipo,
                DateCriacao = DateTime.Now
            };

            Lancamento.Registrar(operacao);

            return operacao;
        }
    }
}

using SuperDigital.InternetBanking.Core.domain.bounded_context;
using SuperDigital.InternetBanking.Core.domain.bounded_context.Contas.Corrente;
using SuperDigital.InternetBanking.Core.domain.bounded_context.Lancamentos;
using System;
using Xunit;

namespace SuperDigital.InternetBanking.Tests
{
    public class ContaCorrenteTeste
    {
        [Fact]
        public void Deve_Realizar_Uma_Operacao_De_Debito_Na_ContaOrigem_E_Credito_Na_ContaDestino()
        {
            var origem = ContaCorrente.Criar("Santander", 0354, "0147071", 0)
                                      .ComSaldoInicial(500);

            var destino = ContaCorrente.Criar("Santander", 2565, "1016280", 7)
                                       .ComSaldoInicial(20); 

           
            var operacao = Operacao.EfetuarOperacao(origem, destino, 500, TipoOperacao.Debito);

            Assert.Equal(520, destino.Saldo);
        }
    }
}

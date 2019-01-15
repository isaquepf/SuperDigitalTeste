using SuperDigital.InternetBanking.application.Resources;
using SuperDigital.InternetBanking.Core.domain.bounded_context;
using SuperDigital.InternetBanking.Core.domain.bounded_context.Contas.Corrente;
using SuperDigital.InternetBanking.Core.domain.bounded_context.Lancamentos;
using System.Threading.Tasks;

namespace SuperDigital.InternetBanking.Core.application
{
    public class OperacaoApplicationService
    {
        public async Task RealizarOperacao(OperacaoResource operacao)
        {
            await Task.Run(() =>
            {
                var origem = ContaCorrente.Criar(operacao.Origem.Banco
                                               , operacao.Origem.Agencia
                                               , operacao.Origem.Numero
                                               , operacao.Origem.Digito)
                                      .ComSaldoInicial(operacao.Origem.Saldo);

                var destino = ContaCorrente.Criar(operacao.Destino.Banco
                                                , operacao.Destino.Agencia
                                                , operacao.Destino.Numero
                                                , operacao.Destino.Digito)
                                           .ComSaldoInicial(operacao.Destino.Saldo);

                Operacao.EfetuarOperacao(origem, destino, 500, TipoOperacao.Debito);
            });
        }

    }
}

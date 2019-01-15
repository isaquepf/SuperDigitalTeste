using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.InternetBanking.Core.domain.bounded_context.Lancamentos
{
    public class Lancamento
    {
        public static List<Operacao> Operacoes { get; set; }

        public static void Registrar(Operacao operacao)
        {
            if (Operacoes == null)
                Operacoes = new List<Operacao>();

            Operacoes.Add(operacao);            
        }
    }
}

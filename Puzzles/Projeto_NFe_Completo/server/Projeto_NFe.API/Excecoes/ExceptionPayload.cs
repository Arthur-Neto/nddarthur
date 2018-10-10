using Projeto_NFe.Domain.Excecoes;
using System;

namespace Projeto_NFe.API.Excecoes
{
    public class ExceptionPayload
    {
        public int CodigoErro { get; set; }

        public string MensagemErro { get; set; }

        public static ExceptionPayload Novo<T>(T excecao) where T : Exception
        {
            int codigoErro;
            if (excecao is ExcecaoDeNegocio)
                codigoErro = (excecao as ExcecaoDeNegocio).CodigoErros.GetHashCode();
            else
                codigoErro = CodigosErros.Unhandled.GetHashCode();
            return new ExceptionPayload
            {
                CodigoErro = codigoErro,
                MensagemErro = excecao.Message,
            };
        }
    }
}
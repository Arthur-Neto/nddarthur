using System;

namespace Projeto_NFe.Domain.Excecoes
{
    public class ExcecaoDeNegocio : Exception
    {
        public ExcecaoDeNegocio(CodigosErros codigo, string message) : base(message)
        {
            CodigoErros = codigo;
        }

        public CodigosErros CodigoErros { get; }
    }
}

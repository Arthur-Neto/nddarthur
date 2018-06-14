using System;
using System.Diagnostics.CodeAnalysis;

namespace NFe.Dominio.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class CnpjInvalidoException : Exception
    {
        public CnpjInvalidoException() : base("O Cnpj informado é inválido")
        {

        }
    }
}

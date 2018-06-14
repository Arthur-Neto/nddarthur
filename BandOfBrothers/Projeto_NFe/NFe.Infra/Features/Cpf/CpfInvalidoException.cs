using System;
using System.Diagnostics.CodeAnalysis;

namespace NFe.Dominio.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class CpfInvalidoException : Exception
    {
        public CpfInvalidoException() : base("O Cpf informado é inválido")
        {

        }
    }
}

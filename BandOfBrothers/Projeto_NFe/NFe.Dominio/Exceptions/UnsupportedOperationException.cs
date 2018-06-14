using System;
using System.Diagnostics.CodeAnalysis;

namespace NFe.Dominio.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class UnsupportedOperationException : Exception
    {
        public UnsupportedOperationException() : base("Operação não suportada")
        {

        }
    }
}

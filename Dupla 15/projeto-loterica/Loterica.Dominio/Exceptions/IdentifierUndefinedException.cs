using System;
using System.Diagnostics.CodeAnalysis;

namespace Loterica.Dominio.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class IdentifierUndefinedException : Exception
    {
        public IdentifierUndefinedException() : base("O Id não pode ser zero")
        {
        }
    }
}

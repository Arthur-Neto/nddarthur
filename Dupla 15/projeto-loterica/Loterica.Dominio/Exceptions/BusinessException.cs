using System;
using System.Diagnostics.CodeAnalysis;

namespace Loterica.Dominio.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class BusinessException : Exception
    {
        public BusinessException() : base("Erro na validação")
        {
        }

        public BusinessException(string message) : base(message)
        {
        }
    }
}

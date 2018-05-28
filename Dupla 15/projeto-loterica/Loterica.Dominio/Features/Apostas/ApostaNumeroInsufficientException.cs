using Loterica.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace Loterica.Dominio.Features.Apostas
{
    [ExcludeFromCodeCoverage]
    public class ApostaNumeroInsufficientException : BusinessException
    {
        public ApostaNumeroInsufficientException() : base("A aposta deve conter pelo menos seis numeros")
        {
        }
    }
}
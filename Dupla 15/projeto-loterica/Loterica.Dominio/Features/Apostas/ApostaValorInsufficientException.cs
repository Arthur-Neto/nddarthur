using Loterica.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace Loterica.Dominio.Features.Apostas
{
    [ExcludeFromCodeCoverage]
    public class ApostaValorInsufficientException : BusinessException
    {
        public ApostaValorInsufficientException() : base("O valor deve ser maior que R$3,50")
        {
        }
    }
}
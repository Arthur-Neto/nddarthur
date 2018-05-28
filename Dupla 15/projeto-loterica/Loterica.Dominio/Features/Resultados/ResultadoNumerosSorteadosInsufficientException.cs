using Loterica.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace Loterica.Dominio.Features.Resultados
{
    [ExcludeFromCodeCoverage]
    public class ResultadoNumerosSorteadosInsufficientException : BusinessException
    {
        public ResultadoNumerosSorteadosInsufficientException() : base("O resultado deve conter pelo menos 6 numeros")
        {
        }
    }
}
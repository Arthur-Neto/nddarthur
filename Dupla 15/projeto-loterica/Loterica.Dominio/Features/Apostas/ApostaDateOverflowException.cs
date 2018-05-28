using Loterica.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace Loterica.Dominio.Features.Apostas
{
    [ExcludeFromCodeCoverage]
    public class ApostaDateOverflowException : BusinessException
    {
        public ApostaDateOverflowException() : base("A data da aposta não pode ser menor que a data do concurso")
        {
        }
    }
}
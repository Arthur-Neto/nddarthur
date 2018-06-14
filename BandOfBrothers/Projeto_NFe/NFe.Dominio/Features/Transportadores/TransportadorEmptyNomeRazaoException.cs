using NFe.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace NFe.Dominio.Features.Transportadores
{
    [ExcludeFromCodeCoverage]
    public class TransportadorEmptyNomeRazaoException : BusinessException
    {
        public TransportadorEmptyNomeRazaoException() : base("Transportador com razão social ou nome vazios")
        {
        }
    }
}
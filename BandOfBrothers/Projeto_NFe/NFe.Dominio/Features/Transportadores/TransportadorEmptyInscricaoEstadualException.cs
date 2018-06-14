using NFe.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace NFe.Dominio.Features.Transportadores
{
    [ExcludeFromCodeCoverage]
    public class TransportadorEmptyInscricaoEstadualException : BusinessException
    {
        public TransportadorEmptyInscricaoEstadualException() : base("Transportador com inscricao estadual vazio")
        {
        }
    }
}
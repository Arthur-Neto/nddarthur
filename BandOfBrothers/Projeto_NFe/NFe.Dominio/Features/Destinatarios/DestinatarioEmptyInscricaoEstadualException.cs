using NFe.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace NFe.Dominio.Features.Destinatarios
{
    [ExcludeFromCodeCoverage]
    public class DestinatarioEmptyInscricaoEstadualException : BusinessException
    {
        public DestinatarioEmptyInscricaoEstadualException() : base("Destinatario com inscricao estadual vazio")
        {
        }
    }
}
using NFe.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace NFe.Dominio.Features.Emitentes
{
    [ExcludeFromCodeCoverage]
    public class EmitenteEmptyInscricaoEstadualException : BusinessException
    {
        public EmitenteEmptyInscricaoEstadualException() : base("Emitente com inscricao estadual vazio")
        {
        }
    }
}
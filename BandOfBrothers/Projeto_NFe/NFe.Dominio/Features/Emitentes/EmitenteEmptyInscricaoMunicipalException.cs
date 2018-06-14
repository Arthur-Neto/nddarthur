using NFe.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace NFe.Dominio.Features.Emitentes
{
    [ExcludeFromCodeCoverage]
    public class EmitenteEmptyInscricaoMunicipalException : BusinessException
    {
        public EmitenteEmptyInscricaoMunicipalException() : base("Emitente com inscricao municipal vazio")
        {
        }
    }
}
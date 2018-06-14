using NFe.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace NFe.Dominio.Features.Emitentes
{
    [ExcludeFromCodeCoverage]
    public class EmitenteEmptyRazaoSocialException : BusinessException
    {
        public EmitenteEmptyRazaoSocialException() : base("Emitente com razao social vazio")
        {
        }
    }
}
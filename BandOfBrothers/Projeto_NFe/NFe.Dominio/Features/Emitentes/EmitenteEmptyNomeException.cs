using NFe.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace NFe.Dominio.Features.Emitentes
{
    [ExcludeFromCodeCoverage]
    public class EmitenteEmptyNomeException : BusinessException
    {
        public EmitenteEmptyNomeException() : base("Emitente com nome vazio")
        {
        }
    }
}
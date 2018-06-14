using NFe.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace NFe.Dominio.Features.Notas_Fiscais
{
    [ExcludeFromCodeCoverage]
    public class NotaFiscalEmitenteEqualsDestinatarioException : BusinessException
    {
        public NotaFiscalEmitenteEqualsDestinatarioException() : base("O emitente é igual o destinatario")
        {
        }
    }
}
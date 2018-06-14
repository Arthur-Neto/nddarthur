using NFe.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace NFe.Dominio.Features.Notas_Fiscais
{
    [ExcludeFromCodeCoverage]
    public class NotaFiscalEmitenteVazioException : BusinessException
    {
        public NotaFiscalEmitenteVazioException() : base("Emitente não pode ser vazio")
        {
        }
    }
}
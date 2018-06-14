using NFe.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace NFe.Dominio.Features.Notas_Fiscais
{
    [ExcludeFromCodeCoverage]
    public class NotaFiscalDestinatarioVazioException : BusinessException
    {
        public NotaFiscalDestinatarioVazioException() : base("O destinatario não deve ser vazio")
        {
        }
    }
}
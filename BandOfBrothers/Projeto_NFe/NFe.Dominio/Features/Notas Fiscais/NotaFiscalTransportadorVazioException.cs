using NFe.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace NFe.Dominio.Features.Notas_Fiscais
{
    [ExcludeFromCodeCoverage]
    public class NotaFiscalTransportadorVazioException : BusinessException
    {
        public NotaFiscalTransportadorVazioException() : base("O transportador não deve ser vazio")
        {
        }
    }
}
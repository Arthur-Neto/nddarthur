using NFe.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace NFe.Dominio.Features.Notas_Fiscais
{
    [ExcludeFromCodeCoverage]
    public class NotaFiscalDataEntradaOverflowException : BusinessException
    {
        public NotaFiscalDataEntradaOverflowException() : base("A data de entrada maior que a data de emissão")
        {
        }
    }
}
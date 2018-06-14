using NFe.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace NFe.Dominio.Features.Transportadores
{
    [ExcludeFromCodeCoverage]
    public class TransportadorEmptyCpfCnpjException : BusinessException
    {
        public TransportadorEmptyCpfCnpjException() : base("Transportador com cpf ou cpnj vazios")
        {
        }
    }
}
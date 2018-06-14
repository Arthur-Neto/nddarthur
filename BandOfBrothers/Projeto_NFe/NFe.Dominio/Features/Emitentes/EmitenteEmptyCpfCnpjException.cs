using NFe.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace NFe.Dominio.Features.Emitentes
{
    [ExcludeFromCodeCoverage]
    public class EmitenteEmptyCpfCnpjException : BusinessException
    {
        public EmitenteEmptyCpfCnpjException() : base("Emitente com cpf ou cpnj vazios")
        {
        }
    }
}
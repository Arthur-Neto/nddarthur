using NFe.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace NFe.Dominio.Features.Destinatarios
{
    [ExcludeFromCodeCoverage]
    public class DestinatarioEmptyCpfCnpjException : BusinessException
    {

        public DestinatarioEmptyCpfCnpjException() : base("Destinatario com cpf ou cpnj vazios")
        {
        }
    }
}
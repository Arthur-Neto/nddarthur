using NFe.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace NFe.Dominio.Features.Enderecos
{
    [ExcludeFromCodeCoverage]
    public class EnderecoEmptyPaisException : BusinessException
    {
        public EnderecoEmptyPaisException() : base("Endereco com país vazio")
        {
        }
    }
}
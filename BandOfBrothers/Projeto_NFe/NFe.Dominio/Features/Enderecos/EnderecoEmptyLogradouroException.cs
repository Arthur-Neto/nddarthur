using NFe.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace NFe.Dominio.Features.Enderecos
{
    [ExcludeFromCodeCoverage]
    public class EnderecoEmptyLogradouroException : BusinessException
    {
        public EnderecoEmptyLogradouroException() : base("Endereco com logradouro vazio")
        {
        }
    }
}
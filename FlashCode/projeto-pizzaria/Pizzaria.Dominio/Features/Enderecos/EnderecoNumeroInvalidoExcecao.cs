using Pizzaria.Dominio.Exceptions;

namespace Pizzaria.Dominio.Features.Enderecos
{
    public class EnderecoNumeroInvalidoExcecao : BusinessException
    {
        public EnderecoNumeroInvalidoExcecao() : base("Endereço com número inválido")
        {
        }
    }
}

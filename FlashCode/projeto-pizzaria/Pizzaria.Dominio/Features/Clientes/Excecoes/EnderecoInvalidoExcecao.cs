using Pizzaria.Dominio.Exceptions;

namespace Pizzaria.Dominio.Features.Clientes.Excecoes
{
    public class EnderecoInvalidoExcecao : BusinessException
    {
        public EnderecoInvalidoExcecao() : base("Endereço inválido")
        {
        }
    }
}

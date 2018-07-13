using Pizzaria.Dominio.Exceptions;

namespace Pizzaria.Dominio.Features.Pedidos.Excecoes
{
    public class ClienteInvalidoExcecao : BusinessException
    {
        public ClienteInvalidoExcecao() : base("Cliente não informado")
        {
        }
    }
}

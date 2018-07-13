using Pizzaria.Dominio.Exceptions;

namespace Pizzaria.Dominio.Features.Pedidos.Excecoes
{
    public class DataInvalidaExcecao : BusinessException
    {
        public DataInvalidaExcecao() : base("A data do pedido é inválida")
        {
        }
    }
}

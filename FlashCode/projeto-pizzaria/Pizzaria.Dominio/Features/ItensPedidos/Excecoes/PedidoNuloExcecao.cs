using Pizzaria.Dominio.Exceptions;

namespace Pizzaria.Dominio.Features.ItensPedidos.Excecoes
{
    public class PedidoNuloExcecao : BusinessException
    {
        public PedidoNuloExcecao() : base("Pedido inválido!")
        {
        }
    }
}

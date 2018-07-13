using Pizzaria.Dominio.Features.ItensPedidos;
using Pizzaria.Infra.Data.Base;

namespace Pizzaria.Infra.Data.Features.ItensPedido
{
    public class ItemPedidoRepositorio : RepositorioGenerico<ItemPedido>, IItemPedidoRepositorio
    {
        public ItemPedidoRepositorio(PizzariaContext context) : base(context)
        {
        }
    }
}

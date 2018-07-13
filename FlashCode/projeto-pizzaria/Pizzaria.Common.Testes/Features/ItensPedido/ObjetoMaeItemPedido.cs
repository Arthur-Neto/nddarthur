using Pizzaria.Dominio.Features.ItensPedidos;
using Pizzaria.Dominio.Features.Pedidos;
using Pizzaria.Dominio.Features.Produtos;

namespace Pizzaria.Common.Testes.Features
{
    public static partial class ObjetoMae
    {
        public static ItemPedido ObterItemComUmaPizza(Pedido pedido)
        {
            var item = new ItemPedido();
            item.Adicionar(ObterPizza(TamanhoEnum.GRANDE));
            item.Pedido = pedido;
            return item;
        }

        public static ItemPedido ObterItemComDuasPizzasMaisBorda(Pedido pedido)
        {
            var item = new ItemPedido();
            item.Adicionar(ObterPizza(TamanhoEnum.GRANDE), ObterPizza(TamanhoEnum.GRANDE), ObterAdicional(TamanhoEnum.GRANDE));
            item.Pedido = pedido;
            return item;
        }
    }
}

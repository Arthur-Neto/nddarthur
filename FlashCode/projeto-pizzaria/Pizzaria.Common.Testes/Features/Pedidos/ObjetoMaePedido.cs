using Pizzaria.Dominio.Features.ItensPedidos;
using Pizzaria.Dominio.Features.Pedidos;
using System;
using System.Collections.Generic;

namespace Pizzaria.Common.Testes.Features
{
    public static partial class ObjetoMae
    {
        public static Pedido ObterPedidoValido()
        {
            var pedido = new Pedido();
            pedido.Cliente = ObterClienteValidoComCpf();
            pedido.Data = DateTime.Now;
            pedido.Itens = new List<ItemPedido>();
            pedido.TipoPagamento = TipoPagamentoEnum.Dinheiro;
            pedido.AdicionarItems(ObterItemComUmaPizza(pedido));
            return pedido;
        }

        public static Pedido ObterPedidoValidoComPizzaDoisSaboresMaisBorda()
        {
            var pedido = new Pedido();
            pedido.Cliente = ObterClienteValidoComCpf();
            pedido.Data = DateTime.Now;
            pedido.Itens = new List<ItemPedido>();
            pedido.TipoPagamento = TipoPagamentoEnum.Dinheiro;
            pedido.AdicionarItems(ObterItemComDuasPizzasMaisBorda(pedido));
            return pedido;
        }
    }
}

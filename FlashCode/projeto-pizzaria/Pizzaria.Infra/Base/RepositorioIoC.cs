using Pizzaria.Dominio.Features.Clientes;
using Pizzaria.Dominio.Features.ItensPedidos;
using Pizzaria.Dominio.Features.Pedidos;
using Pizzaria.Dominio.Features.Produtos;
using Pizzaria.Infra.Data.Base;
using Pizzaria.Infra.Data.Features.Clientes;
using Pizzaria.Infra.Data.Features.ItensPedido;
using Pizzaria.Infra.Data.Features.Pedidos;
using Pizzaria.Infra.Data.Features.Produtos;

namespace Pizzaria.Infra.Base
{
    public static class RepositorioIoC
    {
        public static IPedidoRepositorio RepositorioPedido { get; internal set; }
        public static IItemPedidoRepositorio RepositorioItemPedido { get; internal set; }
        public static IProdutoRepositorio RepositorioProduto { get; internal set; }
        public static IClienteRepositorio RepositorioCliente { get; internal set; }

        private static PizzariaContext contexto;

        static RepositorioIoC()
        {
            contexto = new PizzariaContext();
            RepositorioProduto = new ProdutoRepositorio(contexto);
            RepositorioItemPedido = new ItemPedidoRepositorio(contexto);
            RepositorioPedido = new PedidoRepositorio(contexto);
            RepositorioCliente = new ClienteRepositorio(contexto);
        }
    }
}

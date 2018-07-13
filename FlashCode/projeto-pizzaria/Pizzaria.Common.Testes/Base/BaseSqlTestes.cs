using Pizzaria.Common.Testes.Features;
using Pizzaria.Dominio.Features.Produtos;
using Pizzaria.Infra.Data.Base;
using System.Data.Entity;

namespace Pizzaria.Common.Testes.Base
{
    public class BaseSqlTestes : DropCreateDatabaseAlways<PizzariaContext>
    {
        protected override void Seed(PizzariaContext context)
        {
            context.Produtos.Add(ObjetoMae.ObterPizza(TamanhoEnum.GRANDE));
            var pedido = context.Pedidos.Add(ObjetoMae.ObterPedidoValido());
            context.ItensPedido.Add(ObjetoMae.ObterItemComUmaPizza(pedido));

            context.SaveChanges();
            base.Seed(context);
        }
    }
}

using Pizzaria.Dominio.Features.Pedidos;
using Pizzaria.Infra.Data.Base;
using System.Data.Entity;
using System.Linq;

namespace Pizzaria.Infra.Data.Features.Pedidos
{
    public class PedidoRepositorio : RepositorioGenerico<Pedido>, IPedidoRepositorio
    {
        public PedidoRepositorio(PizzariaContext context) : base(context)
        {
        }

        public override Pedido ObterPorId(long id)
        {
            return _contexto.Pedidos.Where(p => p.Id == id).Include(i => i.Itens).FirstOrDefault();
        }
    }
}

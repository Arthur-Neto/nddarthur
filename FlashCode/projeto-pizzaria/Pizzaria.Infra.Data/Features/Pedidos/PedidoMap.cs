using Pizzaria.Dominio.Features.Pedidos;
using System.Data.Entity.ModelConfiguration;

namespace Pizzaria.Infra.Data.Features.Pedidos
{
    public class PedidoMap : EntityTypeConfiguration<Pedido>
    {
        public PedidoMap()
        {
            ToTable("TBPedido");

            HasKey(x => x.Id);

            Property(x => x.Data).IsRequired();
            Property(x => x.ValorTotal).IsRequired();

            HasRequired(x => x.Cliente).WithMany().Map(m => { m.MapKey("ClienteId"); m.ToTable("TBPedido"); });
            HasMany(x => x.Itens).WithRequired(x => x.Pedido).Map(m => { m.MapKey("PedidoId"); m.ToTable("TBItemPedido"); }).WillCascadeOnDelete();
        }
    }
}

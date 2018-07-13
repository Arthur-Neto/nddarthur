using Pizzaria.Dominio.Features.ItensPedidos;
using System.Data.Entity.ModelConfiguration;

namespace Pizzaria.Infra.Data.Features.ItensPedido
{
    public class ItemPedidoMap : EntityTypeConfiguration<ItemPedido>
    {
        public ItemPedidoMap()
        {
            ToTable("TBItemPedido");

            HasKey(x => x.Id);

            Property(x => x.ValorParcial).IsRequired();

            HasMany(x => x.Produtos).WithMany().Map(m => { m.MapLeftKey("ItemPedidoId"); m.MapRightKey("ProdutoId"); m.ToTable("TBItemPedido_Produto"); });
        }
    }
}

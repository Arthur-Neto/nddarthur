using Pizzaria.Dominio.Features.Produtos;
using System.Data.Entity.ModelConfiguration;

namespace Pizzaria.Infra.Data.Features.Produtos
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            ToTable("TBProduto");

            HasKey(x => x.Id);

            Property(x => x.Sabor).IsRequired();
            Property(x => x.Valor).IsRequired();
            Property(x => x.Tamanho).IsRequired();
        }
    }
}

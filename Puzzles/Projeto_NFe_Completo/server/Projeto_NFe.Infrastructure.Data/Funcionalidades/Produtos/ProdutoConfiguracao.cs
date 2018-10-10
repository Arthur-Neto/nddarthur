using Projeto_NFe.Domain.Funcionalidades.Produtos;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Data.Funcionalidades.Produtos
{
    public class ProdutoConfiguracao : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguracao()
        {
            ToTable("TBPRODUTO");
            HasKey(p => p.Id);
            Property(p => p.Id).HasColumnName("IdProduto");

            Property(p => p.Descricao).HasColumnName("Descricao").HasColumnType("varchar").HasMaxLength(100).IsRequired();
            Property(p => p.Codigo).HasColumnName("Codigo").HasColumnType("varchar").HasMaxLength(100).IsRequired();
            Property(p => p.Valor).HasColumnName("Valor").HasColumnType("float").IsRequired();
        }
    }
}

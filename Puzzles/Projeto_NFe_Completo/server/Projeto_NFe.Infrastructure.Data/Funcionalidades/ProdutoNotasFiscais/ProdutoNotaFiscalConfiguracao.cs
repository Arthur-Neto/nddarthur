using Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Data.Funcionalidades.Produtos
{
    public class ProdutoNotaFiscalConfiguracao : EntityTypeConfiguration<ProdutoNotaFiscal>
    {
        public ProdutoNotaFiscalConfiguracao()
        {
            ToTable("TBPRODUTONOTAFISCAL");
            HasKey(p => p.Id);
            Property(p => p.Id).HasColumnName("IdProdutoNotaFiscal");

            HasRequired(p => p.Produto).WithMany().HasForeignKey(p => p.ProdutoId).WillCascadeOnDelete(false);
            HasRequired(p => p.NotaFiscal).WithMany().HasForeignKey(p => p.NotaFiscalId).WillCascadeOnDelete(false);
            Property(p => p.Quantidade).HasColumnName("Quantidade").HasColumnType("INTEGER").IsRequired();
            Property(p => p.Quantidade).HasColumnName("Quantidade").HasColumnType("INTEGER").IsRequired();
            Property(p => p.ValorICMS).HasColumnName("ValorICMS").HasColumnType("DECIMAL").IsRequired();
            Property(p => p.ValorIPI).HasColumnName("ValorIPI").HasColumnType("DECIMAL").IsRequired();
            Property(p => p.ValorTotal).HasColumnName("ValorTotal").HasColumnType("DECIMAL").IsRequired();
        }
    }
}

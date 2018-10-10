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
            HasRequired(p => p.NotaFiscal).WithMany(nf => nf.Produtos).HasForeignKey(p => p.NotaFiscalId).WillCascadeOnDelete(true);
            Property(p => p.Quantidade).HasColumnName("Quantidade").HasColumnType("int").IsRequired();
            Property(p => p.Quantidade).HasColumnName("Quantidade").HasColumnType("int").IsRequired();

            Ignore(p => p.ValorICMS);
            Ignore(p => p.ValorIPI);
            Ignore(p => p.ValorTotal);
        }
    }
}

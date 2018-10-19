using Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais;
using System.Data.Entity.ModelConfiguration;

namespace Projeto_NFe.Infrastructure.Data.Funcionalidades.Produtos
{
    public class ProdutoNotaFiscalConfiguracao : EntityTypeConfiguration<ProdutoNotaFiscal>
    {
        public ProdutoNotaFiscalConfiguracao()
        {
            ToTable("TBPRODUTONOTAFISCAL");
            HasKey(p => new { p.Id, p.NotaFiscalId, p.ProdutoId });
            Property(p => p.Id).HasColumnName("IdProdutoNotaFiscal");
            Property(p => p.NotaFiscalId).HasColumnName("NotaFiscalId");
            Property(p => p.ProdutoId).HasColumnName("ProdutoId");

            Property(p => p.Quantidade).HasColumnName("Quantidade").HasColumnType("int").IsRequired();
            HasRequired(p => p.Produto).WithMany().HasForeignKey(p => p.ProdutoId);
            HasRequired(p => p.NotaFiscal).WithMany(nf => nf.Produtos).HasForeignKey(p => p.NotaFiscalId);

            Ignore(p => p.ValorICMS);
            Ignore(p => p.ValorIPI);
            Ignore(p => p.ValorTotal);
        }
    }
}

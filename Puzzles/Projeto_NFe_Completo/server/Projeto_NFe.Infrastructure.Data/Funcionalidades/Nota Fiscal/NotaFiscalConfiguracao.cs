using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Data.Funcionalidades.Nota_Fiscal
{
    public class NotaFiscalConfiguracao : EntityTypeConfiguration<NotaFiscal>
    {
        public NotaFiscalConfiguracao()
        {
            ToTable("TBNOTAFISCAL");
            HasKey(nf => nf.Id);
            Property(nf => nf.Id).HasColumnName("IdNotaFiscal");

            Property(nf => nf.NaturezaOperacao).HasColumnName("NaturezaOperacao").HasColumnType("varchar").IsRequired();
            Property(nf => nf.DataEntrada).HasColumnName("DataEntrada").HasColumnType("datetime").IsRequired();
            HasRequired(nf => nf.Destinatario).WithMany().HasForeignKey(nf => nf.DestinatarioId).WillCascadeOnDelete(false);
            HasRequired(nf => nf.Emitente).WithMany().HasForeignKey(nf => nf.EmitenteId).WillCascadeOnDelete(false);
            HasRequired(nf => nf.Transportador).WithMany().HasForeignKey(nf => nf.TransportadorId).WillCascadeOnDelete(false);
            HasOptional(nf => nf.Produtos).WithRequired();
        }
    }
}

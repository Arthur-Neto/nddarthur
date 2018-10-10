using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Data.Funcionalidades.Destinatarios
{
    public class DestinatarioConfiguracao : EntityTypeConfiguration<Destinatario>
    {
        public DestinatarioConfiguracao()
        {
            ToTable("TBDESTINATARIO");
            HasKey(d => d.Id);
            Property(d => d.Id).HasColumnName("IdDestinatario");

            Property(d => d.NomeRazaoSocial).HasColumnName("NomeRazaoSocial").HasColumnType("varchar").HasMaxLength(100).IsRequired();
            Property(d => d.InscricaoEstadual).HasColumnName("InscricaoEstadual").HasColumnType("varchar").HasMaxLength(15).IsOptional();

            HasRequired(d => d.Documento).WithMany().HasForeignKey(d => d.DocumentoId);
            HasRequired(d => d.Endereco).WithMany().HasForeignKey(d => d.EnderecoId);
        }
    }
}

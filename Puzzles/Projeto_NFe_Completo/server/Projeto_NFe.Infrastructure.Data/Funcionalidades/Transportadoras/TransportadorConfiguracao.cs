using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using System.Data.Entity.ModelConfiguration;

namespace Projeto_NFe.Infrastructure.Data.Funcionalidades.Transportadoras
{
    public class TransportadorConfiguracao : EntityTypeConfiguration<Transportador>
    {
        public TransportadorConfiguracao()
        {
            ToTable("TBTRANSPORTADOR");
            HasKey(t => t.Id);
            Property(t => t.Id).HasColumnName("IdTransportador");

            Property(t => t.NomeRazaoSocial).HasColumnName("NomeRazaoSocial").HasColumnType("varchar").HasMaxLength(100).IsRequired();
            Property(t => t.ResponsabilidadeFrete).HasColumnName("ResponsabilidadeFrete").HasColumnType("bit").IsRequired();
            Property(t => t.InscricaoEstadual).HasColumnName("InscricaoEstadual").HasColumnType("varchar").HasMaxLength(15).IsOptional();

            HasRequired(d => d.Documento).WithMany().HasForeignKey(d => d.DocumentoId);
            HasRequired(d => d.Endereco).WithMany().HasForeignKey(d => d.EnderecoId);
        }
    }
}

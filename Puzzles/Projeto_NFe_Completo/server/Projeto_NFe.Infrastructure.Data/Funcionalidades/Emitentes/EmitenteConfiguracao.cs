using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Data.Funcionalidades.Emitentes
{
    public class EmitenteConfiguracao : EntityTypeConfiguration<Emitente>
    {
        public EmitenteConfiguracao()
        {
            ToTable("TBEMITENTE");
            HasKey(e => e.Id);
            Property(e => e.Id).HasColumnName("IdEmitente");

            Property(e => e.NomeFantasia).HasColumnName("NomeFantasia").HasColumnType("varchar").HasMaxLength(100).IsRequired();
            Property(e => e.RazaoSocial).HasColumnName("RazaoSocial").HasColumnType("varchar").HasMaxLength(100).IsRequired();
            Property(e => e.InscricaoMunicipal).HasColumnName("InscricaoMunicipal").HasColumnType("varchar").IsRequired();
            Property(e => e.InscricaoEstadual).HasColumnName("InscricaoEstadual").HasColumnType("varchar").HasMaxLength(15).IsRequired();
            Property(e => e.CNPJ.Numero);
            HasRequired(e => e.Endereco).WithMany().WillCascadeOnDelete(true);
        }
    }
}

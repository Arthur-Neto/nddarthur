using Projeto_NFe.Domain.Funcionalidades.Documentos;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Data.Funcionalidades.Documentos
{
    public class DocumentoConfiguracao : EntityTypeConfiguration<Documento>
    {
        public DocumentoConfiguracao()
        {
            ToTable("TBDOCUMENTO");
            HasKey(d => d.Id);
            Property(d => d.Numero).HasColumnName("Número").HasColumnType("varchar").HasMaxLength(18).IsRequired();
            Property(d => d.Tipo).HasColumnName("Tipo").IsRequired();
        }
    }
}

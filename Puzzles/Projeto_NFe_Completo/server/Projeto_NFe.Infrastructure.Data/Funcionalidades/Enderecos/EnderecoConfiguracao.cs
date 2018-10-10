using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Data.Funcionalidades.Enderecos
{
    public class EnderecoConfiguracao : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfiguracao()
        {
            ToTable("TBENDERECO");
            HasKey(e => e.Id);
            Property(e => e.Id).HasColumnName("IdEndereco");

            Property(e => e.Bairro).HasColumnName("Bairro").HasColumnType("varchar").IsRequired();
            Property(e => e.Estado).HasColumnName("Estado").HasColumnType("varchar").IsRequired();
            Property(e => e.Logradouro).HasColumnName("Logradouro").HasColumnType("varchar").IsRequired();
            Property(e => e.Municipio).HasColumnName("Municipio").HasColumnType("varchar").IsRequired();
            Property(e => e.Pais).HasColumnName("Pais").HasColumnType("varchar").IsRequired();
            Property(e => e.Numero).HasColumnName("Numero").HasColumnType("int").IsRequired();
        }
    }
}

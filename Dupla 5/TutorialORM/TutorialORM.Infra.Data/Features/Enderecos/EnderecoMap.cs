using System.Data.Entity.ModelConfiguration;
using TutorialORM.Dominio.Features.Enderecos;

namespace TutorialORM.Infra.Data.Features.Enderecos
{
    public class EnderecoMap : EntityTypeConfiguration<Endereco>
    {
        public EnderecoMap()
        {
            ToTable("TBEndereco");

            HasKey(x => x.Id);

            Property(x => x.Bairro).HasMaxLength(35).IsRequired();
            Property(x => x.Cidade).HasMaxLength(35).IsRequired();
            Property(x => x.Complemento).HasMaxLength(100);
            Property(x => x.Logradouro).HasMaxLength(100).IsRequired();
            Property(x => x.Numero).IsRequired();
            Property(x => x.UF).HasMaxLength(25).IsRequired();
        }
    }
}

using Pizzaria.Dominio.Features.Enderecos;
using System.Data.Entity.ModelConfiguration;

namespace Pizzaria.Infra.Data.Features.Enderecos
{
    public class EnderecoMap : EntityTypeConfiguration<Endereco>
    {
        public EnderecoMap()
        {
            ToTable("TBEndereco");

            HasKey(x => x.Id);

            Property(x => x.Bairro).IsRequired();
            Property(x => x.Cep).IsRequired();
            Property(x => x.Cidade).IsRequired();
            Property(x => x.Estado).IsRequired();
            Property(x => x.Numero).IsRequired();
            Property(x => x.Rua).IsRequired();
        }
    }
}

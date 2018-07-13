using Pizzaria.Dominio.Features.Clientes;
using System.Data.Entity.ModelConfiguration;

namespace Pizzaria.Infra.Data.Features.Clientes
{
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            ToTable("TBCliente");

            HasKey(x => x.Id);

            Property(x => x.CNPJ).IsOptional();
            Property(x => x.CPF).IsOptional();
            Property(x => x.DataDeNascimento).IsRequired();
            Property(x => x.Nome).IsRequired();
            Property(x => x.Telefone).IsRequired();

            HasRequired(x => x.Endereco).WithMany().Map(m => { m.MapKey("EnderecoId"); m.ToTable("TBCliente"); });
        }
    }
}

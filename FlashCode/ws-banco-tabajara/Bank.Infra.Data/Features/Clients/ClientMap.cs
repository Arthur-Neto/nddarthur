using Bank.Domain.Features.Clients;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics.CodeAnalysis;

namespace Bank.Infra.Data.Features.Clients
{
    [ExcludeFromCodeCoverage]
    public class ClientMap : EntityTypeConfiguration<Client>
    {
        public ClientMap()
        {
            HasKey(c => c.Id);

            Property(c => c.Birthday).IsRequired();
            Property(c => c.Cpf).HasMaxLength(25).IsRequired();
            Property(c => c.Name).HasMaxLength(100).IsRequired();
            Property(c => c.Rg).HasMaxLength(25).IsRequired();
        }
    }
}

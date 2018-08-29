using Bank.Domain.Features.Users;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics.CodeAnalysis;

namespace Bank.Infra.Data.Features.Users
{
    [ExcludeFromCodeCoverage]
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            HasKey(t => t.Id);

            Property(t => t.Username).HasMaxLength(50).IsRequired();
            Property(t => t.Password).HasMaxLength(50).IsRequired();
        }
    }
}

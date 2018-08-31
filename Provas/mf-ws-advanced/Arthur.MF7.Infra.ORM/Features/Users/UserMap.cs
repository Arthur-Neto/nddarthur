using Arthur.MF7.Domain.Features.Users;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics.CodeAnalysis;

namespace Arthur.MF7.Infra.ORM.Features.Users
{
    [ExcludeFromCodeCoverage]
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            HasKey(u => u.Id);

            Property(u => u.Username).HasMaxLength(50).IsRequired();
            Property(u => u.Password).HasMaxLength(50).IsRequired();
        }
    }
}

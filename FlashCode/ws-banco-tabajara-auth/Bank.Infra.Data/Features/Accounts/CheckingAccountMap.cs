using Bank.Domain.Features.Accounts;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics.CodeAnalysis;

namespace Bank.Infra.Data.Features.Accounts
{
    [ExcludeFromCodeCoverage]
    public class CheckingAccountMap : EntityTypeConfiguration<CheckingAccount>
    {
        public CheckingAccountMap()
        {
            HasKey(c => c.Id);

            HasRequired(c => c.Client)
                .WithMany()
                .Map(m => m.MapKey("ClientId"))
                .WillCascadeOnDelete(true);

            Property(c => c.Balance).IsRequired();
            Property(c => c.IsActive).IsRequired();
            Property(c => c.Limit).IsRequired();
            Property(c => c.Number).IsRequired();
            Ignore(c => c.TotalBalance);

            HasMany(f => f.Transactions).WithMany().Map(m =>
            {
                m.MapLeftKey("AccountId"); m.MapRightKey("TransactionId"); m.ToTable("Transactions_Accounts");
            });
        }
    }
}

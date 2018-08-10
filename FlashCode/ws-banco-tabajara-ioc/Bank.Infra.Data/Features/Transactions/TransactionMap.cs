using Bank.Domain.Features.Transactions;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics.CodeAnalysis;

namespace Bank.Infra.Data.Features.Transactions
{
    [ExcludeFromCodeCoverage]
    public class TransactionMap : EntityTypeConfiguration<Transaction>
    {
        public TransactionMap()
        {
            HasKey(t => t.Id);

            Property(t => t.Data).IsRequired();
            Property(t => t.Type).IsRequired();
            Property(t => t.Value).IsRequired();
        }
    }
}

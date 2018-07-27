using Bank.Domain.Features.Transactions;
using Bank.Infra.Data.Base;

namespace Bank.Infra.Data.Features.Transactions
{
    public class TransactionRepository : AbstractRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(BankContext context) : base(context)
        {
        }
    }
}

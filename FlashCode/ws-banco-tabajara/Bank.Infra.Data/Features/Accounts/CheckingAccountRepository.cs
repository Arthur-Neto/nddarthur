using Bank.Domain.Exceptions;
using Bank.Domain.Features.Accounts;
using Bank.Infra.Data.Base;
using System.Linq;

namespace Bank.Infra.Data.Features.Accounts
{
    public class CheckingAccountRepository : AbstractRepository<CheckingAccount>, ICheckingAccountRepository
    {
        public CheckingAccountRepository(BankContext context) : base(context)
        {
        }

        public new IQueryable<CheckingAccount> GetAll(int? quantity = null)
        {
            if (quantity != null)
                return _context.CheckingAccounts.Include("Transactions").Include("Client").Take((int)quantity);
            else
                return _context.CheckingAccounts.Include("Transactions").Include("Client");
        }

        public new CheckingAccount GetById(long id)
        {
            return _context.CheckingAccounts.Include("Transactions").Include("Client").FirstOrDefault(e => e.Id == id);
        }

        public new bool Remove(CheckingAccount account)
        {
            account = _context.CheckingAccounts.Where(x => x.Id == account.Id).FirstOrDefault() ?? throw new NotFoundException();

            _context.Transactions.RemoveRange(account.Transactions);
            _context.CheckingAccounts.Remove(account);
            return _context.SaveChanges() > 0;
        }
    }
}

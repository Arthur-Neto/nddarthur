using Bank.Application.Base;
using Bank.Domain.Features.Accounts;

namespace Bank.Application.Features.Accounts
{
    public interface ICheckingAccountService : IService<CheckingAccount>
    {
        bool UpdateStatus(long id);

        bool Withdraw(AccountTransactionModel accountModel);

        bool Deposit(AccountTransactionModel accountModel);

        bool Transfer(AccountTransactionModel accountModel);

        object GetExtract(long id);
    }
}

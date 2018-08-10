using Bank.Application.Features.Accounts.Commands;
using Bank.Application.Features.Accounts.Queries;
using Bank.Domain.Features.Accounts;
using System.Linq;

namespace Bank.Application.Features.Accounts
{
    public interface ICheckingAccountService 
    {
        long Add(CheckingAccountRegisterCommand cmd);

        bool Update(CheckingAccountUpdateCommand cmd);

        CheckingAccount GetById(long id);

        IQueryable<CheckingAccount> GetAll(CheckingAccountQuery query);

        bool Remove(CheckingAccountRemoveCommand cmd);

        bool UpdateStatus(long id);

        bool Withdraw(CheckingAccountTransactionCommand cmd);

        bool Deposit(CheckingAccountTransactionCommand cmd);

        bool Transfer(CheckingAccountTransactionCommand cmd);

        CheckingAccount GetExtract(long id);
    }
}

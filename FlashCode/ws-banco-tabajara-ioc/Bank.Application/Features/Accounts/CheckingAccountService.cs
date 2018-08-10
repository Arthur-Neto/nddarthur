using Bank.Domain.Exceptions;
using Bank.Domain.Features.Accounts;
using Bank.Domain.Features.Clients;
using Bank.Domain.Features.Transactions;
using System;
using System.Linq;

namespace Bank.Application.Features.Accounts
{
    public class CheckingAccountService : ICheckingAccountService
    {
        private ICheckingAccountRepository _checkingAccountRepository;
        private IClientRepository _clientRepository;

        public CheckingAccountService(ICheckingAccountRepository checkingAccountRepository, IClientRepository clientRepository)
        {
            _checkingAccountRepository = checkingAccountRepository;
            _clientRepository = clientRepository;
        }

        public long Add(CheckingAccount checkingAccount)
        {
            checkingAccount.Client = _clientRepository.GetById(checkingAccount.Client.Id) ?? throw new NotFoundException();

            checkingAccount = _checkingAccountRepository.Add(checkingAccount);

            return checkingAccount.Id;
        }

        public IQueryable<CheckingAccount> GetAll(int? quantity = null)
        {
            return _checkingAccountRepository.GetAll(quantity);
        }

        public CheckingAccount GetById(long id)
        {
            if (id < 1)
                throw new NotFoundException();
            return _checkingAccountRepository.GetById(id) ?? throw new NotFoundException();
        }

        public bool Remove(CheckingAccount checkingAccount)
        {
            var account = _checkingAccountRepository.GetById(checkingAccount.Id) ?? throw new NotFoundException();

            var removed = _checkingAccountRepository.Remove(checkingAccount);

            return removed;
        }

        public bool Update(CheckingAccount checkingAccount)
        {
            var accountDb = _checkingAccountRepository.GetById(checkingAccount.Id) ?? throw new NotFoundException();

            //a linha que tirou nosso 10 /:
            var clientdb = _clientRepository.GetById(checkingAccount.Client.Id) ?? throw new NotFoundException();

            accountDb.Balance = checkingAccount.Balance;
            accountDb.Client = clientdb;
            accountDb.Limit = checkingAccount.Limit;
            accountDb.Transactions = checkingAccount.Transactions;

            return _checkingAccountRepository.Update(accountDb);
        }

        public bool UpdateStatus(long id)
        {
            var account = _checkingAccountRepository.GetById(id) ?? throw new NotFoundException();

            if (account.IsActive)
                account.IsActive = false;
            else
                account.IsActive = true;

            var returns = _checkingAccountRepository.Update(account);

            return returns;
        }

        public bool Withdraw(AccountTransactionModel accountModel)
        {
            var account = _checkingAccountRepository.GetById(accountModel.AccountOriginId) ?? throw new NotFoundException();
            var withdrawValue = accountModel.Value;

            if (withdrawValue < 0)
                throw new InvalidObjectException();

            account.Withdraw(withdrawValue);

            return _checkingAccountRepository.Update(account);
        }

        public bool Deposit(AccountTransactionModel accountModel)
        {
            var account = _checkingAccountRepository.GetById(accountModel.AccountOriginId) ?? throw new NotFoundException();
            var depositValue = accountModel.Value;

            if (depositValue < 0)
                throw new InvalidObjectException();

            account.Deposit(depositValue);

            return _checkingAccountRepository.Update(account);
        }

        public bool Transfer(AccountTransactionModel accountModel)
        {
            var transfeValue = accountModel.Value;

            if (accountModel.AccountOriginId == accountModel.AccountDestinationId || transfeValue < 0)
                throw new InvalidObjectException();

            var accountOriginDb = _checkingAccountRepository.GetById(accountModel.AccountOriginId) ?? throw new NotFoundException();
            var accountDestinationDb = _checkingAccountRepository.GetById(accountModel.AccountDestinationId) ?? throw new NotFoundException();

            accountOriginDb.Transfer(transfeValue, accountDestinationDb);

            _checkingAccountRepository.Update(accountDestinationDb);
            return _checkingAccountRepository.Update(accountOriginDb);
        }

        public object GetExtract(long id)
        {
            if (id < 1)
                throw new NotFoundException();

            var account = _checkingAccountRepository.GetById(id) ?? throw new NotFoundException();

            var extrato = new
            {
                NameClient = account.Client.Name,
                NumberAccount = account.Number,
                account.Balance,
                account.Limit,
                DateEmission = DateTime.Now,
                account.Transactions
            };

            return extrato;
        }
    }
}

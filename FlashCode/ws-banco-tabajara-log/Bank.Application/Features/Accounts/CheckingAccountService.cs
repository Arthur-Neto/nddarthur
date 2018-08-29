using AutoMapper;
using Bank.Application.Features.Accounts.Commands;
using Bank.Application.Features.Accounts.Queries;
using Bank.Domain.Exceptions;
using Bank.Domain.Features.Accounts;
using Bank.Domain.Features.Clients;
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

        public long Add(CheckingAccountRegisterCommand cmd)
        {
            var checkingAccount = Mapper.Map<CheckingAccountRegisterCommand, CheckingAccount>(cmd);

            checkingAccount.Client = _clientRepository.GetById(cmd.Client.Id) ?? throw new NotFoundException();

            var newCheckingAccount = _checkingAccountRepository.Add(checkingAccount);

            return newCheckingAccount.Id;
        }

        public IQueryable<CheckingAccount> GetAll(CheckingAccountQuery query)
        {
            IQueryable<CheckingAccount> result;

            if (query == null)
                result = _checkingAccountRepository.GetAll(null);
            else
                result = _checkingAccountRepository.GetAll(query.Quantity);

            return result;
        }

        public CheckingAccount GetById(long id)
        {
            if (id < 1)
                throw new NotFoundException();

            var checkingAccount = _checkingAccountRepository.GetById(id) ?? throw new NotFoundException();

            return checkingAccount;
        }

        public bool Remove(CheckingAccountRemoveCommand cmd)
        {
            var account = _checkingAccountRepository.GetById(cmd.Id) ?? throw new NotFoundException();

            return _checkingAccountRepository.Remove(account);
        }

        public bool Update(CheckingAccountUpdateCommand cmd)
        {
            var accountDb = _checkingAccountRepository.GetById(cmd.Id) ?? throw new NotFoundException();

            var account = Mapper.Map(cmd, accountDb);

            return _checkingAccountRepository.Update(account);
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

        public bool Withdraw(CheckingAccountTransactionCommand cmd)
        {
            var account = _checkingAccountRepository.GetById(cmd.AccountOriginId) ?? throw new NotFoundException();
            var withdrawValue = cmd.Value;

            if (withdrawValue < 0)
                throw new InvalidObjectException();

            account.Withdraw(withdrawValue);

            return _checkingAccountRepository.Update(account);
        }

        public bool Deposit(CheckingAccountTransactionCommand cmd)
        {
            var account = _checkingAccountRepository.GetById(cmd.AccountOriginId) ?? throw new NotFoundException();
            var depositValue = cmd.Value;

            if (depositValue < 0)
                throw new InvalidObjectException();

            account.Deposit(depositValue);

            return _checkingAccountRepository.Update(account);
        }

        public bool Transfer(CheckingAccountTransactionCommand cmd)
        {
            var transfeValue = cmd.Value;

            if (cmd.AccountOriginId == cmd.AccountDestinationId || transfeValue < 0)
                throw new InvalidObjectException();

            var accountOriginDb = _checkingAccountRepository.GetById(cmd.AccountOriginId) ?? throw new NotFoundException();
            var accountDestinationDb = _checkingAccountRepository.GetById(cmd.AccountDestinationId) ?? throw new NotFoundException();

            accountOriginDb.Transfer(transfeValue, accountDestinationDb);

            _checkingAccountRepository.Update(accountDestinationDb);
            return _checkingAccountRepository.Update(accountOriginDb);
        }

        public CheckingAccount GetExtract(long id)
        {
            if (id < 1)
                throw new NotFoundException();

            var account = _checkingAccountRepository.GetById(id) ?? throw new NotFoundException();

            return account;
        }
    }
}

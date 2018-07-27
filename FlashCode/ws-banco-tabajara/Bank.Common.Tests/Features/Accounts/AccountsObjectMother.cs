using Bank.Domain.Features.Accounts;
using Bank.Domain.Features.Clients;
using Bank.Domain.Features.Transactions;
using System;

namespace Bank.Common.Tests.Features.ObjectMothers
{
    public static partial class ObjectMother
    {
        public static CheckingAccount GetCheckingAccountValid()
        {
            CheckingAccount account = new CheckingAccount();

            account.Id = 1;
            account.Balance = 150;
            account.Client = new Client()
            {
                Id = 1,
                Birthday = DateTime.Now,
                Cpf = "123456789",
                Name = "José",
                Rg = "123456789"
            };
            account.IsActive = true;
            account.Limit = 50;
            account.Number = 1234567;
            account.Transactions.Add(new Transaction() { Id = 0, Type = TransactionType.CREDIT, Value = 100 });
            return account;
        }
        public static CheckingAccount GetCheckingAccountDestination()
        {
            CheckingAccount account = new CheckingAccount();

            account.Id = 2;
            account.Balance = 150;
            account.Client = new Client()
            {
                Id = 1,
                Birthday = DateTime.Now,
                Cpf = "123456789",
                Name = "José",
                Rg = "123456789"
            };
            account.IsActive = true;
            account.Limit = 50;
            account.Number = 1234567;
            account.Transactions.Add(new Transaction() { Id = 0, Type = TransactionType.CREDIT, Value = 100 });
            return account;
        }
    }
}

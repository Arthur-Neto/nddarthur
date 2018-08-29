using Bank.Domain.Base;
using Bank.Domain.Features.Accounts.Exceptions;
using Bank.Domain.Features.Clients;
using Bank.Domain.Features.Transactions;
using System.Collections.Generic;

namespace Bank.Domain.Features.Accounts
{
    public class CheckingAccount : Entity
    {
        public int Number { get; set; }
        public decimal Balance { get; set; }
        public bool IsActive { get; set; }
        public decimal Limit { get; set; }
        public decimal TotalBalance { get { return Balance + Limit; } }
        public virtual Client Client { get; set; }
        public virtual List<Transaction> Transactions { get; set; }

        public CheckingAccount()
        {
            Transactions = new List<Transaction>();
        }

        public void Withdraw(decimal value)
        {
            if (this.IsActive)
                if (value > this.TotalBalance)
                {
                    throw new ShortBalanceException();
                }
                else
                {
                    this.Balance -= value;
                    this.SaveTransaction(TransactionType.DEBT, value);
                }

            else
                throw new AccountInactiveException();

        }
        public void Deposit(decimal value)
        {
            if (this.IsActive)
            {
                this.Balance += value;
                this.SaveTransaction(TransactionType.CREDIT, value);
            }
            else
                throw new AccountInactiveException();
        }

        private void SaveTransaction(TransactionType type, decimal value)
        {
            Transaction transaction = new Transaction();
            transaction.Type = type;
            transaction.Value = value;
            this.Transactions.Add(transaction);
        }


        public void Transfer(decimal value, CheckingAccount accountDestination)
        {
            if (this.IsActive)
                if (value > this.TotalBalance)
                {
                    throw new ShortBalanceException();
                }
                else
                {
                    this.Balance -= value;
                    accountDestination.Deposit(value);
                    this.SaveTransaction(TransactionType.TRANSFER, value);
                }
            else
                throw new AccountInactiveException();
        }
    }
}

using Bank.Domain.Base;
using System;

namespace Bank.Domain.Features.Transactions
{
    public class Transaction : Entity
    {
        public decimal Value { get; set; }
        public TransactionType Type { get; set; }
        public DateTime Data { get; set; }
        public string Description { get => string.Format("{0} value: {1} data: {2}", Type.ToString(), Value, Data); }

        public Transaction()
        {
            Data = DateTime.Now;
        }

    }
}

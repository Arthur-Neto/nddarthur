using Bank.Domain.Features.Transactions;
using System;

namespace Bank.Application.Features.Transactions.ViewModels
{
    public class TransactionViewModel
    {
        public decimal Value { get; set; }
        public TransactionType Type { get; set; }
        public DateTime Data { get; set; }
        public string Description { get => string.Format("{0} value: {1} data: {2}", Type.ToString(), Value, Data); }
    }
}

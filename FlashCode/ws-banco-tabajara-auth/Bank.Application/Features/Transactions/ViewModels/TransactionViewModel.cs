using Bank.Domain.Features.Transactions;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Bank.Application.Features.Transactions.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class TransactionViewModel
    {
        public decimal Value { get; set; }
        public TransactionType Type { get; set; }
        public DateTime Data { get; set; }
        public string Description { get => string.Format("{0} value: {1} data: {2}", Type.ToString(), Value, Data); }
    }
}

using Bank.Application.Features.Clients.ViewModels;
using Bank.Application.Features.Transactions.ViewModels;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Bank.Application.Features.Accounts.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class CheckingAccountViewModel
    {
        public long Id { get; set; }
        public int Number { get; set; }
        public decimal Balance { get; set; }
        public bool IsActive { get; set; }
        public decimal Limit { get; set; }
        public decimal TotalBalance { get { return Balance + Limit; } }
        public ClientViewModel Client { get; set; }
        public List<TransactionViewModel> Transactions { get; set; }
    }
}

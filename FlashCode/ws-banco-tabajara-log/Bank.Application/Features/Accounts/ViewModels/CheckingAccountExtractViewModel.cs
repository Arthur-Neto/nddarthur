using Bank.Domain.Features.Transactions;
using System;
using System.Collections.Generic;

namespace Bank.Application.Features.Accounts.ViewModels
{
    public class CheckingAccountExtractViewModel
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public decimal Balance { get; set; }
        public decimal Limit { get; set; }
        public DateTime DateEmission { get; set; }
        public List<Transaction> Transactions{ get; set; }
    }
}

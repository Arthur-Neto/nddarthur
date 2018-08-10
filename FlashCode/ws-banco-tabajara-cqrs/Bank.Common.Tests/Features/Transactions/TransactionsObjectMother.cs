using Bank.Domain.Features.Transactions;
using System;

namespace Bank.Common.Tests.Features.ObjectMothers
{
    public static partial class ObjectMother
    {
        public static Transaction GetTransactionCredit()
        {
            return new Transaction()
            {
                Data = DateTime.Now,
                Type = TransactionType.CREDIT,
                Value = 50
            };
        }

        public static Transaction GetTransactionDebt()
        {
            return new Transaction()
            {
                Data = DateTime.Now,
                Type = TransactionType.DEBT,
                Value = 50
            };
        }
    }
}

using Arthur.MF7.Domain.Features.Employees;
using Arthur.MF7.Domain.Features.Spendings;
using System;

namespace Arthur.MF7.Common.Tests.Features
{
    public static partial class ObjectMother
    {
        public static Spending GetValidSpending()
        {
            return new Spending()
            {
                Date = DateTime.Now,
                Description = "asd",
                Price = 50,
                Type = "dsa",
                Employee = GetValidEmployee()
            };
        }
    }
}

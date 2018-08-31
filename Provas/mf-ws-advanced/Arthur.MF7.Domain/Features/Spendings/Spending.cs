using Arthur.MF7.Domain.Base;
using Arthur.MF7.Domain.Features.Employees;
using System;

namespace Arthur.MF7.Domain.Features.Spendings
{
    public class Spending : Entity
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public Employee Employee { get; set; }
        public decimal Price { get; set; }
    }
}

using System;

namespace Prova1.Domain.Products
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public virtual double Sale { get; set; }
        public virtual double Expense { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime Manufacture { get; set; }
        public DateTime Expiration { get; set; }
    }
}

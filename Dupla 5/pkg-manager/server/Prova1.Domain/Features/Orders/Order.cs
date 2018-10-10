using Prova1.Domain.Products;

namespace Prova1.Domain.Orders
{
    public class Order : Entity
    {
        public string Customer { get; set; }

        public int Quantity { get; set; }

        public Product Product { get; set; }

        public int ProductId { get; set; }

        public double Total
        {
            get
            {
                return Product != null ? (Product.Sale - Product.Expense) * Quantity : 0;
            }
        }
    }
}

namespace Prova1.Application.Features.Products.ViewModels
{
    public class ProductViewModel
    {
        public virtual int Id { get; set; }
        public string Name { get; set; }
        public double Sale { get; set; }
        public double Expense { get; set; }
        public bool IsAvailable { get; set; }
        public string Manufacture { get; set; }
        public string Expiration { get; set; }
    }
}

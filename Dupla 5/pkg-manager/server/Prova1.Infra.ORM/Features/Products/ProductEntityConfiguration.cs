using Prova1.Domain.Products;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics.CodeAnalysis;

namespace Prova1.Infra.ORM.Features.Products
{
    [ExcludeFromCodeCoverage]
    public class ProductEntityConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductEntityConfiguration()
        {
            this.HasKey(p => p.Id);
            this.Property(p => p.Name).HasMaxLength(50).IsRequired();
            this.Property(p => p.Sale).IsRequired();
            this.Property(p => p.Expense).IsRequired();
            this.Property(p => p.IsAvailable).IsRequired();
            this.Property(p => p.Manufacture).IsRequired();
            this.Property(p => p.Expiration).IsRequired();
        }
    }
}

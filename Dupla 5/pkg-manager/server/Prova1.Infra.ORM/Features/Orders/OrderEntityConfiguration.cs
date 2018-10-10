
using Prova1.Domain.Orders;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics.CodeAnalysis;

namespace Prova1.Infra.ORM.Features.Orders
{
    [ExcludeFromCodeCoverage]
    public class OrderEntityConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderEntityConfiguration()
        {
            this.HasKey(o => o.Id);

            this.HasRequired(o => o.Product)
                    .WithMany()
                    .HasForeignKey(o => o.ProductId)
                    .WillCascadeOnDelete(true);

            this.Property(o => o.Customer).HasMaxLength(50);
            this.Property(o => o.Quantity).IsRequired();
            this.Ignore(o => o.Total);
        }
    }
}

using Arthur.MF7.Domain.Features.Spendings;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics.CodeAnalysis;

namespace Arthur.MF7.Infra.ORM.Features.Spendings
{
    [ExcludeFromCodeCoverage]
    public class SpendingMap : EntityTypeConfiguration<Spending>
    {
        public SpendingMap()
        {
            HasKey(s => s.Id);

            Property(s => s.Date).IsRequired();
            Property(s => s.Description).HasMaxLength(50).IsRequired();
            Property(s => s.Type).HasMaxLength(50).IsRequired();
            Property(s => s.Price).IsRequired();

            HasRequired(s => s.Employee).WithMany().Map(m => m.MapKey("EmployeeId"));
        }
    }
}

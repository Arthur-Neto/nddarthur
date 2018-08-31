using Arthur.MF7.Domain.Features.Employees;
using System.Data.Entity.ModelConfiguration;
using System.Diagnostics.CodeAnalysis;

namespace Arthur.MF7.Infra.ORM.Features.Employees
{
    [ExcludeFromCodeCoverage]
    public class EmployeeMap : EntityTypeConfiguration<Employee>
    {
        public EmployeeMap()
        {
            HasKey(e => e.Id);

            Property(e => e.FirstName).HasMaxLength(50).IsRequired();
            Property(e => e.LastName).HasMaxLength(50).IsRequired();
            Property(e => e.Position).HasMaxLength(50).IsRequired();
            Property(e => e.IsActive).IsRequired();

            HasRequired(e => e.User).WithMany().Map(m => m.MapKey("UserId"));
        }
    }
}

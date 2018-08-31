using System.Diagnostics.CodeAnalysis;

namespace Arthur.MF7.Application.Features.Employees.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class EmployeeViewModel
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Position { get; set; }
        public bool IsActive { get; set; }
    }
}

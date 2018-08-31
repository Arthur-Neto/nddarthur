using System;
using System.Diagnostics.CodeAnalysis;

namespace Arthur.MF7.Application.Features.Spendings.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class SpendingViewModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string EmployeeName { get; set; }
    }
}

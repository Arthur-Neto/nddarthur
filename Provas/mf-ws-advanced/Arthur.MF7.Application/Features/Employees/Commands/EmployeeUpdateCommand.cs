using FluentValidation;
using FluentValidation.Results;
using System.Diagnostics.CodeAnalysis;

namespace Arthur.MF7.Application.Features.Employees.Commands
{
    [ExcludeFromCodeCoverage]
    public class EmployeeUpdateCommand
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public bool IsActive { get; set; }

        public virtual ValidationResult Validate()
        {
            Validator validator = new Validator();

            return validator.Validate(this);
        }

        private class Validator : AbstractValidator<EmployeeUpdateCommand>
        {
            public Validator()
            {
                RuleFor(e => e.Id).GreaterThan(0);
                RuleFor(e => e.FirstName).NotEmpty();
                RuleFor(e => e.IsActive).NotNull();
                RuleFor(e => e.LastName).NotEmpty();
                RuleFor(e => e.Position).NotEmpty();
            }
        }
    }
}
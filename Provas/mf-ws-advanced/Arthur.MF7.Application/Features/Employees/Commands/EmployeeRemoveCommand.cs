using FluentValidation;
using FluentValidation.Results;
using System.Diagnostics.CodeAnalysis;

namespace Arthur.MF7.Application.Features.Employees.Commands
{
    [ExcludeFromCodeCoverage]
    public class EmployeeRemoveCommand
    {
        public long Id { get; set; }

        public virtual ValidationResult Validate()
        {
            Validator validator = new Validator();

            return validator.Validate(this);
        }

        private class Validator : AbstractValidator<EmployeeRemoveCommand>
        {
            public Validator()
            {
                RuleFor(c => c.Id).NotNull().NotEmpty().GreaterThan(0);
            }
        }
    }
}
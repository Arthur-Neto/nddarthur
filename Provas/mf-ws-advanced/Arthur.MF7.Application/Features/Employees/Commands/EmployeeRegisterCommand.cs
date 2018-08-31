using FluentValidation;
using FluentValidation.Results;
using System.Diagnostics.CodeAnalysis;

namespace Arthur.MF7.Application.Features.Employees.Commands
{
    [ExcludeFromCodeCoverage]
    public class EmployeeRegisterCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Position { get; set; }
        public bool IsActive { get; set; }

        public virtual ValidationResult Validate()
        {
            Validator validator = new Validator();

            return validator.Validate(this);
        }

        private class Validator : AbstractValidator<EmployeeRegisterCommand>
        {
            public Validator()
            {
                RuleFor(e => e.FirstName).NotEmpty();
                RuleFor(e => e.IsActive).NotNull();
                RuleFor(e => e.LastName).NotEmpty();
                RuleFor(e => e.Password).NotEmpty().MinimumLength(8);
                RuleFor(e => e.Position).NotEmpty();
                RuleFor(e => e.Username).NotEmpty().MinimumLength(8);
            }
        }
    }
}
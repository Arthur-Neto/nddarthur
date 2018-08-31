using FluentValidation;
using FluentValidation.Results;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Arthur.MF7.Application.Features.Spendings.Commands
{
    [ExcludeFromCodeCoverage]
    public class SpendingRegisterCommand
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public long EmployeeId { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }

        public virtual ValidationResult Validate()
        {
            Validator validator = new Validator();

            return validator.Validate(this);
        }

        private class Validator : AbstractValidator<SpendingRegisterCommand>
        {
            public Validator()
            {
                RuleFor(e => e.Date).NotEmpty();
                RuleFor(e => e.Description).NotNull();
                RuleFor(e => e.EmployeeId).GreaterThan(0);
                RuleFor(e => e.Price).NotEmpty();
                RuleFor(e => e.Type).NotEmpty();
            }
        }
    }
}
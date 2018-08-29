using FluentValidation;
using FluentValidation.Results;
using System.Diagnostics.CodeAnalysis;

namespace Bank.Application.Features.Accounts.Commands
{
    [ExcludeFromCodeCoverage]
    public class CheckingAccountRemoveCommand
    {
        public long Id { get; set; }

        public virtual ValidationResult Validate()
        {
            var validator = new Validator();

            return validator.Validate(this);
        }

        private class Validator : AbstractValidator<CheckingAccountRemoveCommand>
        {
            public Validator()
            {
                RuleFor(c => c.Id).NotNull().NotEmpty().GreaterThan(0);
            }
        }
    }
}

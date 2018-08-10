using FluentValidation;
using FluentValidation.Results;

namespace Bank.Application.Features.Accounts.Commands
{
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

using FluentValidation;
using FluentValidation.Results;

namespace Bank.Application.Features.Clients.Commands
{
    public class ClientRemoveCommand
    {
        public long Id { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        private class Validator : AbstractValidator<ClientRemoveCommand>
        {
            public Validator()
            {
                RuleFor(c => c.Id).NotNull().NotEmpty().GreaterThan(0);
            }
        }
    }
}

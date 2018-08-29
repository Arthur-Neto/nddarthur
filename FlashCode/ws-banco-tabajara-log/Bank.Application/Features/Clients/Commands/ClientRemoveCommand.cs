using FluentValidation;
using FluentValidation.Results;
using System.Diagnostics.CodeAnalysis;

namespace Bank.Application.Features.Clients.Commands
{
    [ExcludeFromCodeCoverage]
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

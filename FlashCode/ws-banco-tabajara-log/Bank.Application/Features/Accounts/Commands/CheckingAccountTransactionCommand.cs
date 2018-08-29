using Bank.Domain.Features.Transactions;
using FluentValidation;
using FluentValidation.Results;
using System.Diagnostics.CodeAnalysis;

namespace Bank.Application.Features.Accounts.Commands
{
    [ExcludeFromCodeCoverage]
    public class CheckingAccountTransactionCommand
    {
        public long AccountOriginId { get; set; }
        public long AccountDestinationId { get; set; }
        public decimal Value { get; set; }

        public virtual ValidationResult Validate(TransactionType type)
        {
            return new Validator(type).Validate(this);
        }

        private class Validator : AbstractValidator<CheckingAccountTransactionCommand>
        {
            public Validator(TransactionType type)
            {
                RuleFor(c => c.Value).NotNull().NotEmpty().GreaterThan(0);
                RuleFor(c => c.AccountOriginId).NotNull().NotEmpty().GreaterThan(0);
                if (type == TransactionType.TRANSFER)
                {
                    RuleFor(c => c.AccountDestinationId).NotNull().NotEmpty().GreaterThan(0);
                }
            }
        }
    }
}

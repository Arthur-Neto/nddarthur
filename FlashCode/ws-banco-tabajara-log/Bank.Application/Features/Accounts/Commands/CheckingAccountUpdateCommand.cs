using Bank.Application.Features.Clients.Commands;
using Bank.Domain.Features.Transactions;
using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Bank.Application.Features.Accounts.Commands
{
    [ExcludeFromCodeCoverage]
    public class CheckingAccountUpdateCommand
    {
        public long Id { get; set; }
        public decimal Balance { get; set; }
        public bool IsActive { get; set; }
        public decimal Limit { get; set; }
        public decimal TotalBalance { get; set; }
        public List<Transaction> Transactions { get; set; }

        public virtual ValidationResult Validate()
        {
            var validator = new Validator();

            return validator.Validate(this);
        }

        private class Validator : AbstractValidator<CheckingAccountUpdateCommand>
        {
            public Validator()
            {
                RuleFor(c => c.Id).NotNull().NotEmpty().GreaterThan(0);
                RuleFor(c => c.Balance).NotNull().GreaterThanOrEqualTo(0);
                RuleFor(c => c.IsActive).NotNull();
                RuleFor(c => c.Limit).NotNull().GreaterThanOrEqualTo(0);
                RuleFor(c => c.TotalBalance).NotNull();
                RuleForEach(c => c.Transactions).NotNull();
            }
        }
    }
}

using Bank.Application.Features.Clients.ViewModels;
using Bank.Domain.Features.Transactions;
using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Bank.Application.Features.Accounts.Commands
{
    [ExcludeFromCodeCoverage]
    public class CheckingAccountRegisterCommand
    {
        public int Number { get; set; }
        public decimal Balance { get; set; }
        public bool IsActive { get; set; }
        public decimal Limit { get; set; }
        public decimal TotalBalance { get; set; }
        public ClientViewModel Client { get; set; }
        public List<Transaction> Transactions { get; set; }

        public virtual ValidationResult Validate()
        {
            var validator = new Validator();

            return validator.Validate(this);
        }

        private class Validator : AbstractValidator<CheckingAccountRegisterCommand>
        {
            public Validator()
            {
                RuleFor(c => c.Balance).NotNull().GreaterThanOrEqualTo(0);
                RuleFor(c => c.IsActive).NotNull();
                RuleFor(c => c.Limit).NotNull().GreaterThanOrEqualTo(0);
                RuleFor(c => c.Number).NotNull().GreaterThanOrEqualTo(0);
                RuleFor(c => c.TotalBalance).NotNull();
                RuleFor(c => c.Client).NotNull().NotEmpty();
                RuleForEach(c => c.Transactions).NotNull();
            }
        }
    }
}

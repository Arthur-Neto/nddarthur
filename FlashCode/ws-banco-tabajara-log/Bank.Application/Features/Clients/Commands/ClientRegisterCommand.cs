using FluentValidation;
using FluentValidation.Results;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Bank.Application.Features.Clients.Commands
{
    [ExcludeFromCodeCoverage]
    public class ClientRegisterCommand
    {
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string Rg { get; set; }
        public DateTime Birthday { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        private class Validator : AbstractValidator<ClientRegisterCommand>
        {
            public Validator()
            {
                RuleFor(c => c.Birthday).NotNull().NotEmpty();
                RuleFor(c => c.Cpf).NotNull().Length(1,15);
                RuleFor(c => c.Name).NotNull().Length(1,50);
                RuleFor(c => c.Rg).NotNull().Length(1,15);
            }
        }
    }
}

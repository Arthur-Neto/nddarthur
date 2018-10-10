using FluentValidation;
using FluentValidation.Results;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Prova1.Application.Features.Products.Commands
{
    [ExcludeFromCodeCoverage]
    public class ProductRegisterCommand
    {
        public string Name { get; set; }
        public double Sale { get; set; }
        public double Expense { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime Manufacture { get; set; }
        public DateTime Expiration { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<ProductRegisterCommand>
        {
            public Validator()
            {
                RuleFor(p => p.Name).NotNull().NotEmpty();
                RuleFor(p => p.Manufacture).NotNull().NotEmpty();
                RuleFor(p => p.Expiration).NotNull().NotEmpty();
            }
        }
    }
}

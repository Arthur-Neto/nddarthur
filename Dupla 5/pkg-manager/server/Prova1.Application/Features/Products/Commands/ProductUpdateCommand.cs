using FluentValidation;
using FluentValidation.Results;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Prova1.Application.Features.Products.Commands
{
    [ExcludeFromCodeCoverage]
    public class ProductUpdateCommand
    {
        public virtual int Id { get; set; }
        public string Name { get; set; }
        public double Sale { get; set; }
        public double Expense { get; set; }
        public bool IsAvailable { get; set; }
        public string Manufacture { get; set; }
        public string Expiration { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<ProductUpdateCommand>
        {
            public Validator()
            {
                RuleFor(p => p.Id).NotNull().GreaterThan(0);
                RuleFor(p => p.Name).NotNull().NotEmpty();
                RuleFor(p => p.Manufacture).NotNull().NotEmpty();
                RuleFor(p => p.Expiration).NotNull().NotEmpty();
            }
        }
    }
}

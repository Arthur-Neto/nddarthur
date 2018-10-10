using FluentValidation;
using FluentValidation.Results;
using System.Diagnostics.CodeAnalysis;

namespace Prova1.Application.Features.Products.Commands
{
    [ExcludeFromCodeCoverage]
    public class ProductRemoveCommand
    {
        public int[] ProductIds { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<ProductRemoveCommand>
        {
            public Validator()
            {
                RuleFor(p => p.ProductIds).NotNull();
                RuleFor(p => p.ProductIds.Length).GreaterThan(0);
            }
        }
    }
}

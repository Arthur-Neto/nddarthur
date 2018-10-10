using FluentValidation;
using FluentValidation.Results;
using System.Diagnostics.CodeAnalysis;

namespace Prova1.Application.Features.Orders.Commands
{
    /// <summary>
    /// 
    /// Representa o comando (dados necessário) para registrar um nova order.
    ///  
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class OrderRegisterCommand
    {
        public virtual string Customer { get; set; }

        public virtual int Quantity { get; set; }

        public virtual int ProductId { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<OrderRegisterCommand>
        {
            public Validator()
            {
                RuleFor(c => c.Customer).NotNull().NotEmpty();
                RuleFor(c => c.ProductId).GreaterThan(0);
                RuleFor(c => c.Quantity).GreaterThan(0);
            }
        }
    }
}

using FluentValidation;
using FluentValidation.Results;
using System.Diagnostics.CodeAnalysis;

namespace Prova1.Application.Features.Orders.Commands
{
    /// <summary>
    /// 
    /// Representa o comando (dados necessário) para atualizar uma order.
    ///  
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class OrderUpdateCommand
    {
        public virtual int Id { get; set; }

        public virtual string Customer { get; set; }

        public virtual int Quantity { get; set; }

        public virtual int ProductId { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<OrderUpdateCommand>
        {
            public Validator()
            {
                RuleFor(c => c.Id).NotNull().GreaterThan(0);
                RuleFor(c => c.Customer).NotNull().NotEmpty();
                RuleFor(c => c.Quantity).NotNull().GreaterThan(0);
                RuleFor(c => c.ProductId).NotNull().GreaterThan(0);
            }
        }
    }

}

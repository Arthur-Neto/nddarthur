using FluentValidation;
using FluentValidation.Results;
using System.Diagnostics.CodeAnalysis;

namespace Prova1.Application.Features.Orders.Commands
{
    /// <summary>
    /// 
    /// Representa o comando (dados necessários) para remover uma order da base de dados
    ///  
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class OrderRemoveCommand
    {
        public virtual int[] OrderIds { get; set; }

        public virtual ValidationResult Validate()
        {
            return new Validator().Validate(this);
        }

        class Validator : AbstractValidator<OrderRemoveCommand>
        {
            public Validator()
            {
                RuleFor(c => c.OrderIds).NotNull();
                RuleFor(c => c.OrderIds.Length).GreaterThan(0);
            }
        }
    }
}

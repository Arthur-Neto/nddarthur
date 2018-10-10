using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Funcionalidades.Transportadoras.Comandos
{
    public class TransportadorRemoverComando
    {
        public long Id { get; set; }

        public virtual ValidationResult RealizarValidacaoDoComando()
        {
            Validar validar = new Validar();

            return validar.Validate(this);
        }

        class Validar : AbstractValidator<TransportadorRemoverComando>
        {
            public Validar()
            {
                RuleFor(transportadorRemoverComando => transportadorRemoverComando.Id).NotNull();
                RuleFor(transportadorRemoverComando => transportadorRemoverComando.Id).GreaterThan(0);
            }
        }
    }
}

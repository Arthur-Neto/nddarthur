using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Funcionalidades.Emitentes.Comandos
{
    public class EmitenteRemoverComando
    {
        public long Id { get; set; }

        public virtual ValidationResult RealizarValidacaoDoComando()
        {
            Validar validar = new Validar();

            return validar.Validate(this);
        }

        class Validar : AbstractValidator<EmitenteRemoverComando>
        {
            public Validar()
            {
                RuleFor(emitenteRemoverComando => emitenteRemoverComando.Id).NotNull();
                RuleFor(emitenteRemoverComando => emitenteRemoverComando.Id).GreaterThan(0);
            }
        }
    }
}

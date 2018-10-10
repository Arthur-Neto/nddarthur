using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Funcionalidades.Destinatarios.Comandos
{
    public class DestinatarioRemoverComando
    {
        public long Id { get; set; }

        public virtual ValidationResult RealizarValidacaoDoComando()
        {
            Validar validar = new Validar();

            return validar.Validate(this);
        }

        class Validar : AbstractValidator<DestinatarioRemoverComando>
        {
            public Validar()
            {
                RuleFor(destinatarioRemoverComando => destinatarioRemoverComando.Id).NotNull();
                RuleFor(destinatarioRemoverComando => destinatarioRemoverComando.Id).GreaterThan(0);
            }
        }
    }
}

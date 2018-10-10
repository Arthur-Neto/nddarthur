using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Funcionalidades.Produtos.Comandos
{
    public class ProdutoRemoverComando
    {
        public virtual long Id { get; set; }

        public virtual ValidationResult RealizarValidacaoDoComando()
        {
            Validar validar = new Validar();

            return validar.Validate(this);
        }

        class Validar : AbstractValidator<ProdutoRemoverComando>
        {
            public Validar()
            {
                RuleFor(produtoRemoverComando => produtoRemoverComando.Id).NotNull();
                RuleFor(produtoRemoverComando => produtoRemoverComando.Id).GreaterThan(0);
            }
        }
    }
}

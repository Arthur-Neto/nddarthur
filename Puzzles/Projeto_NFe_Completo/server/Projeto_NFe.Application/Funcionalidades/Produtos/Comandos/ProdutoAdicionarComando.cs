using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Funcionalidades.Produtos.Comandos
{
    public class ProdutoAdicionarComando
    {
        public string Codigo { get; set; }

        public double Valor { get; set; }

        public double AliquotaIPI { get; set; }

        public double AliquotaICMS { get; set; }

        public string Descricao { get; set; }

        public virtual ValidationResult RealizarValidacaoDoComando()
        {
            Validar validar = new Validar();

            return validar.Validate(this);
        }

        class Validar : AbstractValidator<ProdutoAdicionarComando>
        {
            public Validar()
            {
                RuleFor(produtoAdicionarComando => produtoAdicionarComando.Codigo).NotNull();
                RuleFor(produtoAdicionarComando => produtoAdicionarComando.Valor).NotNull();
                RuleFor(produtoAdicionarComando => produtoAdicionarComando.Valor).GreaterThan(0);
                RuleFor(produtoAdicionarComando => produtoAdicionarComando.Descricao).NotNull();

                //RuleFor(produtoAdicionarComando => produtoAdicionarComando.AliquotaICMS).NotNull();
                //RuleFor(produtoAdicionarComando => produtoAdicionarComando.AliquotaIPI).NotNull();
            }
        }
    }
}

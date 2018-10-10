using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Funcionalidades.Produtos.Comandos
{
    public class ProdutoEditarComando
    {
        public long Id { get; set; }

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

        class Validar : AbstractValidator<ProdutoEditarComando>
        {
            public Validar()
            {
                RuleFor(produtoEditarComando => produtoEditarComando.Id).NotNull();
                RuleFor(produtoEditarComando => produtoEditarComando.Id).GreaterThan(0);
                RuleFor(produtoEditarComando => produtoEditarComando.Codigo).NotNull();
                RuleFor(produtoEditarComando => produtoEditarComando.Valor).NotNull();
                RuleFor(produtoEditarComando => produtoEditarComando.Valor).GreaterThan(0);
                RuleFor(produtoEditarComando => produtoEditarComando.Descricao).NotNull();

                //RuleFor(produtoEditarComando => produtoEditarComando.AliquotaICMS).NotNull();
                //RuleFor(produtoEditarComando => produtoEditarComando.AliquotaIPI).NotNull();
            }
        }
    }
}

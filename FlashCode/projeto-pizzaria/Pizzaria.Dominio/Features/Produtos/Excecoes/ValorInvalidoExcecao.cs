using Pizzaria.Dominio.Exceptions;

namespace Pizzaria.Dominio.Features.Produtos.Excecoes
{

    public class ValorInvalidoExcecao : BusinessException
    {
        public ValorInvalidoExcecao() : base("Valor inválido")
        {
        }
    }
}
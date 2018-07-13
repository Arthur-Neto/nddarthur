using Pizzaria.Dominio.Exceptions;

namespace Pizzaria.Dominio.Features.ItensPedidos.Excecoes
{
    public class ListaProdutosVaziaExcecao : BusinessException
    {
        public ListaProdutosVaziaExcecao() : base("Lista de produtos vazia!")
        {
        }
    }
}

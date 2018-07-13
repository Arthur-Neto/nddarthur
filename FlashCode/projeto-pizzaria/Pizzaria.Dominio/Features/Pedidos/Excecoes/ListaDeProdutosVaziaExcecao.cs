using Pizzaria.Dominio.Exceptions;

namespace Pizzaria.Dominio.Features.Pedidos.Excecoes
{
    public class ListaDeProdutosVaziaExcecao : BusinessException
    {
        public ListaDeProdutosVaziaExcecao() : base("A lista de produtos está vazia")
        {
        }
    }
}

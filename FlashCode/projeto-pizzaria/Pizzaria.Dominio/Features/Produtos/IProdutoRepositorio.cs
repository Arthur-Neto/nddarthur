using Pizzaria.Dominio.Base;
using System.Collections.Generic;

namespace Pizzaria.Dominio.Features.Produtos
{
    public interface IProdutoRepositorio : IRepositorio<Produto>
    {
        IEnumerable<Produto> ObterPizzas(TamanhoEnum tamanhoProduto);
        IEnumerable<Produto> ObterCalzones(TamanhoEnum tamanhoProduto);
        IEnumerable<Produto> ObterBebidas();
        IEnumerable<Produto> ObterAdicionais(TamanhoEnum tamanhoProduto);
    }
}

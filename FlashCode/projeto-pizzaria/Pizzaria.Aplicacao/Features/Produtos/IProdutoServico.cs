using Pizzaria.Aplicacao.Base;
using Pizzaria.Dominio.Features.Produtos;
using System.Collections.Generic;

namespace Pizzaria.Aplicacao.Features.Produtos
{
    public interface IProdutoServico : IServico<Produto>
    {
        List<Produto> AdicionarItens(List<Produto> produtos);
        IEnumerable<Produto> ObterPizzas(TamanhoEnum tamanhoProduto);
        IEnumerable<Produto> ObterCalzones(TamanhoEnum tamanhoProduto);
        IEnumerable<Produto> ObterBebidas();
        IEnumerable<Produto> ObterAdicionais(TamanhoEnum tamanhoProduto);
    }
}

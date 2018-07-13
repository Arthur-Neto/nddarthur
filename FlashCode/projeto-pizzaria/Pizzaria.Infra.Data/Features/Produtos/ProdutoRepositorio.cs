using Pizzaria.Dominio.Features.Produtos;
using Pizzaria.Infra.Data.Base;
using System.Collections.Generic;
using System.Linq;

namespace Pizzaria.Infra.Data.Features.Produtos
{
    public class ProdutoRepositorio : RepositorioGenerico<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(PizzariaContext context) : base(context)
        {
        }

        public IEnumerable<Produto> ObterAdicionais(TamanhoEnum tamanhoProduto)
        {
            IEnumerable<Produto> produtos;
            produtos = (from produto in _contexto.Adicionais where produto.Tamanho == tamanhoProduto select produto).ToList();
            return produtos;
        }

        public IEnumerable<Produto> ObterBebidas()
        {
            IEnumerable<Produto> produtos;
            produtos = (from produto in _contexto.Bebidas select produto).ToList();
            return produtos;
        }

        public IEnumerable<Produto> ObterCalzones(TamanhoEnum tamanhoProduto)
        {
            IEnumerable<Produto> produtos;
            produtos = (from produto in _contexto.Calzones where produto.Tamanho == tamanhoProduto select produto).ToList();
            return produtos;
        }

        public IEnumerable<Produto> ObterPizzas(TamanhoEnum tamanhoProduto)
        {
            IEnumerable<Produto> produtos;
            produtos = (from produto in _contexto.Pizzas where produto.Tamanho == tamanhoProduto select produto).ToList();
            return produtos;
        }
    }
}

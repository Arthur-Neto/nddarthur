using Pizzaria.Dominio.Exceptions;
using Pizzaria.Dominio.Features.Produtos;
using System.Collections.Generic;

namespace Pizzaria.Aplicacao.Features.Produtos
{
    public class ProdutoServico : IProdutoServico
    {
        IProdutoRepositorio _produtoRepositorio;

        public ProdutoServico(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public Produto Adicionar(Produto entidade)
        {
            entidade.Validar();

            return _produtoRepositorio.Salvar(entidade);
        }

        public Produto Atualizar(Produto entidade)
        {
            if (entidade.Id < 1)
                throw new IdentificadorInvalidoExcecao();

            entidade.Validar();

            return _produtoRepositorio.Atualizar(entidade);
        }

        public void Excluir(Produto entidade)
        {
            if (entidade.Id < 1)
                throw new IdentificadorInvalidoExcecao();

            _produtoRepositorio.Deletar(entidade);
        }

        public Produto ObterPorId(long id)
        {
            if (id < 1)
                throw new IdentificadorInvalidoExcecao();

            return _produtoRepositorio.ObterPorId(id);
        }

        public IEnumerable<Produto> ObterPizzas(TamanhoEnum tamanhoProduto)
        {
            return _produtoRepositorio.ObterPizzas(tamanhoProduto);
        }

        public IEnumerable<Produto> ObterCalzones(TamanhoEnum tamanhoProduto)
        {
            return _produtoRepositorio.ObterCalzones(tamanhoProduto);
        }

        public IEnumerable<Produto> ObterBebidas()
        {
            return _produtoRepositorio.ObterBebidas();
        }

        public IEnumerable<Produto> ObterAdicionais(TamanhoEnum tamanhoProduto)
        {
            return _produtoRepositorio.ObterAdicionais(tamanhoProduto);
        }

        public IEnumerable<Produto> ObterTodos()
        {
            return _produtoRepositorio.ObterTodos();
        }

        public List<Produto> AdicionarItens(List<Produto> produtos)
        {
            if (produtos == null)
                return null;

            for (int i = 0; i < produtos.Count; i++)
            {
                produtos[i] = _produtoRepositorio.Salvar(produtos[i]);
            }

            return produtos;
        }
    }
}

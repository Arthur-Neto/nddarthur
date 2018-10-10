using AutoMapper;
using Projeto_NFe.Application.Funcionalidades.Produtos.Comandos;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Produtos;
using System.Linq;

namespace Projeto_NFe.Application.Funcionalidades.Produtos
{
    public class ProdutoServico : IProdutoServico
    {
        private IProdutoRepositorio _repositorioProduto;

        public ProdutoServico(IProdutoRepositorio produtoRepositorio)
        {
            this._repositorioProduto = produtoRepositorio;
        }

        public long Adicionar(ProdutoAdicionarComando comando)
        {
            Produto produto = Mapper.Map<ProdutoAdicionarComando, Produto>(comando);

            return _repositorioProduto.Adicionar(produto);
        }

        public bool Atualizar(ProdutoEditarComando comando)
        {
            Produto produtoDb = _repositorioProduto.BuscarPorId(comando.Id) ?? throw new ExcecaoNaoEncontrado();

            Mapper.Map<ProdutoEditarComando, Produto>(comando, produtoDb);

            return _repositorioProduto.Atualizar(produtoDb);
        }

        public bool Excluir(ProdutoRemoverComando comando)
        {
            Produto produto = _repositorioProduto.BuscarPorId(comando.Id) ?? throw new ExcecaoNaoEncontrado();

            _repositorioProduto.Excluir(produto);

            return _repositorioProduto.BuscarPorId(produto.Id) == null ? true : false;
        }

        public Produto BuscarPorId(long id)
        {
            return _repositorioProduto.BuscarPorId(id) ?? throw new ExcecaoNaoEncontrado();
        }

        public IQueryable<Produto> BuscarTodos()
        {
            return _repositorioProduto.BuscarTodos();
        }
    }
}

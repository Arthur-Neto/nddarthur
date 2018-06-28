using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Dominio.Features.Produtos;

namespace Projeto_NFe.Aplicacao.Features.Produtos
{
    public class ProdutoServico : IProdutoServico
    {
        private IProdutoRepositorio _produtoRepositorio;

        public ProdutoServico(IProdutoRepositorio produtoRepositorio) => _produtoRepositorio = produtoRepositorio;

        public Produto Atualizar(Produto produto)
        {
            if (produto.ID == 0)
                throw new ExcecaoIdentificadorInvalido();

            produto.Validar();
            return _produtoRepositorio.Atualizar(produto);
        }

        public bool Deletar(long id)
        {
            if (id == 0)
                throw new ExcecaoIdentificadorInvalido();
            return _produtoRepositorio.Deletar(id);
        }

        public Produto Inserir(Produto produto)
        {
            produto.Validar();

            return _produtoRepositorio.Inserir(produto);
        }

        public Produto ObterPorId(long id)
        {
            if (id == 0)
                throw new ExcecaoIdentificadorInvalido();

            return _produtoRepositorio.ObterPorId(id);
        }

        public List<Produto> ObterTodos()
        {
            return _produtoRepositorio.ObterTodos();
        }
    }
}

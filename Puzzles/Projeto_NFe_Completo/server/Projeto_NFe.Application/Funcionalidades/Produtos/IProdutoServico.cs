using Projeto_NFe.Application.Funcionalidades.Produtos.Comandos;
using Projeto_NFe.Domain.Funcionalidades.Produtos;
using System.Linq;

namespace Projeto_NFe.Application.Funcionalidades.Produtos
{
    public interface IProdutoServico
    {
        long Adicionar(ProdutoAdicionarComando comando);
        bool Atualizar(ProdutoEditarComando comando);
        bool Excluir(ProdutoRemoverComando comando);
        IQueryable<Produto> BuscarTodos();
        Produto BuscarPorId(long id);
    }
}

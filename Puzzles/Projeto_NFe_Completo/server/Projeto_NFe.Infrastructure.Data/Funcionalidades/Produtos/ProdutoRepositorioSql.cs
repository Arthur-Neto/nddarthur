using Projeto_NFe.Domain.Funcionalidades.Produtos;
using Projeto_NFe.Infrastructure.Data.Base;
using System.Linq;

namespace Projeto_NFe.Infrastructure.Data.Funcionalidades.Produtos
{
    public class ProdutoRepositorioSql : IProdutoRepositorio
    {
        ProjetoNFeContexto _contexto;

        public ProdutoRepositorioSql(ProjetoNFeContexto contexto)
        {
            _contexto = contexto;
        }

        public long Adicionar(Produto produto)
        {
            produto = _contexto.Produtos.Add(produto);
            _contexto.SaveChanges();
            return produto.Id;
        }

        public bool Atualizar(Produto produto)
        {
            return _contexto.SaveChanges() != 0;
        }

        public Produto BuscarPorId(long Id)
        {
            Produto produto = _contexto.Produtos.Find(Id);

            return produto;
        }

        public IQueryable<Produto> BuscarTodos()
        {
            return _contexto.Produtos;
        }

        public bool Excluir(Produto produto)
        {
            _contexto.Produtos.Remove(produto);
            return _contexto.SaveChanges() != 0;
        }
    }
}

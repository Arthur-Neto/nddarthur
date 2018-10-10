using Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais;
using Projeto_NFe.Infrastructure.Data.Base;
using System.Linq;

namespace Projeto_NFe.Infrastructure.Data.Funcionalidades.Nota_Fiscal
{
    public class ProdutoNotaFiscalRepositorioSql : IProdutoNotaFiscalRepositorio
    {
        ProjetoNFeContexto _contexto;

        public ProdutoNotaFiscalRepositorioSql(ProjetoNFeContexto contexto)
        {
            _contexto = contexto;
        }

        public long Adicionar(ProdutoNotaFiscal produtoNotaFiscal)
        {
            produtoNotaFiscal = _contexto.ProdutosNotaFiscal.Add(produtoNotaFiscal);
            _contexto.SaveChanges();
            return produtoNotaFiscal.Id;
        }

        public bool Atualizar(ProdutoNotaFiscal produtoNotaFiscal)
        {

            return _contexto.SaveChanges() != 0;
        }

        public ProdutoNotaFiscal BuscarPorId(long Id)
        {
            ProdutoNotaFiscal produtoNotaFiscal = _contexto.ProdutosNotaFiscal.Find(Id);

            return produtoNotaFiscal;
        }

        public IQueryable<ProdutoNotaFiscal> BuscarProdutosPorIdNota(long id)
        {
            return _contexto.ProdutosNotaFiscal.Where(pn => pn.NotaFiscalId == id);
        }

        public IQueryable<ProdutoNotaFiscal> BuscarTodos()
        {
            return _contexto.ProdutosNotaFiscal;
        }

        public bool DeletarProdutosPorIdNota(long id)
        {
            _contexto.ProdutosNotaFiscal.RemoveRange(BuscarProdutosPorIdNota(id));
            return _contexto.SaveChanges() != 0;
        }

        public bool Excluir(ProdutoNotaFiscal produtoNotaFiscal)
        {
            _contexto.ProdutosNotaFiscal.Remove(produtoNotaFiscal);
            return _contexto.SaveChanges() != 0;
        }
    }
}

using Projeto_NFe.Domain.Interfaces;
using System.Linq;

namespace Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais
{
    public interface IProdutoNotaFiscalRepositorio : IRepositorio<ProdutoNotaFiscal>
    {
        IQueryable<ProdutoNotaFiscal> BuscarProdutosPorIdNota(long id);

        bool DeletarProdutosPorIdNota(long id);
    }
}

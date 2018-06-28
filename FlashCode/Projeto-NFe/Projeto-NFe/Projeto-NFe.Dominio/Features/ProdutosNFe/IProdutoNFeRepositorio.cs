using Projeto_NFe.Dominio.Base;
using Projeto_NFe.Dominio.Features.Produtos;
using System.Collections.Generic;

namespace Projeto_NFe.Dominio.Features.ProdutosNFe
{
    public interface IProdutoNFeRepositorio : IRepositorio<ProdutoNfe>
    {
        List<ProdutoNfe> InserirListaDeProdutos (List<ProdutoNfe> listaProdutos, long notaFiscalId);
        ProdutoNfe Inserir(ProdutoNfe produto, long nfeID, long produtoId);
        ProdutoNfe Atualizar(ProdutoNfe produto, long nfeID, long produtoId);
        List<ProdutoNfe> ObterTodosPorNotaFiscal(long nfeID);
        bool DeletarPorProdutoMaisNotaFiscal(long produtoID, long nfID);
        bool DeletarPorNotaFiscalID(long nfID);
    }
}

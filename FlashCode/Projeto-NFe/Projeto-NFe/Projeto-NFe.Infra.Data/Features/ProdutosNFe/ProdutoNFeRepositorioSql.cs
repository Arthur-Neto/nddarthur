using Projeto_NFe.Dominio.Features.ProdutosNFe;
using System;
using System.Collections.Generic;
using Projeto_NFe.Dominio.Features.Produtos;
using Projeto_NFe.Dominio.Excecoes;
using System.Data;
using Projeto_NFe.Infra.SQL;
using Projeto_NFe.Dominio.Features.ProdutosNFe.Excecoes;

namespace Projeto_NFe.Infra.Data.Features.ProdutosNFe
{
    public class ProdutoNFeRepositorioSql : IProdutoNFeRepositorio
    {
        #region Script's SQL
        private string _sqlInserir = @"INSERT INTO [dbo].[ProdutosNFe]
                                                       ([Quantidade]
                                                       ,[ProdutoID]
                                                       ,[NotaFiscalID]
                                                       ,[ValorICMS]
                                                       ,[ValorIPI])
                                                 VALUES
                                                       ({0}Quantidade
                                                       ,{0}ProdutoID
                                                       ,{0}NotaFiscalID
                                                       ,{0}ValorICMS
                                                       ,{0}ValorIPI)";

        private string _sqlDeletarPorNotaFiscal =
            @"DELETE FROM ProdutosNFe WHERE NotaFiscalID = {0}NotaFiscalID";

        private string _sqlDeletarPorProdutoMaisNotaFiscal =
            @"DELETE FROM ProdutosNFe WHERE NotaFiscalID = {0}NotaFiscalID AND ProdutoID = {0}ProdutoID";

        private string _sqlAtualizar = @"UPDATE [dbo].[ProdutosNFe]
                                                   SET [Quantidade] = {0}Quantidade
                                                      ,[ProdutoID] = {0}ProdutoID
                                                      ,[NotaFiscalID] = {0}NotaFiscalID
                                                      ,[ValorICMS] = {0}ValorICMS
                                                      ,[ValorIPI] = {0}ValorIPI
                                                 WHERE Id = {0}Id";

        private string _sqlObterPorId = @"SELECT * FROM ProdutosNFe WHERE Id = {0}Id";

        private string _sqlObterTodosPorNotaFiscal =
            @"SELECT * FROM ProdutosNFe WHERE NotaFiscalID = {0}NotaFiscalID";

        #endregion

        public List<ProdutoNfe> InserirListaDeProdutos(List<ProdutoNfe> listaProdutos, long nfeID)
        {
            if (nfeID < 1)
                throw new ExcecaoIdentificadorInvalido();

            if (listaProdutos.Count < 1)
                throw new ListaProdutosVazia();

            foreach (var produto in listaProdutos)
            {
                this.Inserir(produto,nfeID,produto.ID);
            }

            return listaProdutos;
        }

        public ProdutoNfe Atualizar(ProdutoNfe produtoNfe)
        {
            throw new ExcexaoOperacaoNaoSuportada();
        }

        public ProdutoNfe Atualizar(ProdutoNfe produtoNfe, long nfeID, long produtoId)
        {
            if (produtoNfe.ID < 1 || nfeID < 1 || produtoId < 1)
                throw new ExcecaoIdentificadorInvalido();

            Db.Update(_sqlAtualizar, ObtemParametros(produtoNfe, nfeID, produtoId));

            return produtoNfe;
        }

        public bool Deletar(long id)
        {
            throw new ExcexaoOperacaoNaoSuportada();
        }

        public bool DeletarPorNotaFiscalID(long nfID)
        {
            if (nfID < 1)
                throw new ExcecaoIdentificadorInvalido();

            var parms = new Dictionary<string, object> { { "NotaFiscalID", nfID } };

            var linhasAfetadas =  Db.Delete(_sqlDeletarPorNotaFiscal, parms);

            if (linhasAfetadas < 1)
                return false;

            return true;
        }

        public bool DeletarPorProdutoMaisNotaFiscal(long produtoID, long nfID)
        {
            if (nfID < 1 || produtoID < 1)
                throw new ExcecaoIdentificadorInvalido();

            var parms = new Dictionary<string, object> { {"ProdutoID", produtoID }, { "NotaFiscalID", nfID } };

            var linhasAfetadas = Db.Delete(_sqlDeletarPorProdutoMaisNotaFiscal, parms);

            if (linhasAfetadas < 1)
                return false;

            return true;
        }

        public ProdutoNfe Inserir(ProdutoNfe produtoNfe)
        {
            throw new ExcexaoOperacaoNaoSuportada();
        }

        public ProdutoNfe Inserir(ProdutoNfe produto, long nfeID, long produtoId)
        {
            if (nfeID < 1 || produtoId < 1)
                throw new ExcecaoIdentificadorInvalido();

            produto.Validar();

            produto.ID = Db.Insert(_sqlInserir, ObtemParametros(produto, nfeID,produtoId));

            return produto;
        }

        public ProdutoNfe ObterPorId(long id)
        {
            if (id < 1)
                throw new ExcecaoIdentificadorInvalido();

            var parms = new Dictionary<string, object> { { "Id", id } };

            return Db.Get(_sqlObterPorId, SetarParmetros, parms);
        }
        
        public List<ProdutoNfe> ObterTodos()
        {
            throw new ExcexaoOperacaoNaoSuportada();
        }

        public List<ProdutoNfe> ObterTodosPorNotaFiscal(long nfeID)
        {
            if (nfeID < 1)
                throw new ExcecaoIdentificadorInvalido();

            var parms = new Dictionary<string, object> { { "NotaFiscalID", nfeID } };

            return Db.GetAll(_sqlObterTodosPorNotaFiscal, SetarParmetros, parms);
        }

        private Dictionary<string, object> ObtemParametros(ProdutoNfe produtoNfe, long nfeID, long produtoId)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("ID", produtoNfe.ID);
            parms.Add("Quantidade", produtoNfe.Quantidade);
            parms.Add("ProdutoID", produtoId);
            parms.Add("NotaFiscalID", nfeID);
            parms.Add("ValorICMS", produtoNfe.Imposto.ValorICMS);
            parms.Add("ValorIPI", produtoNfe.Imposto.ValorIPI);
            return parms;
        }

        private ProdutoNfe SetarParmetros(IDataReader reader)
        {
            var produtoNfe = new ProdutoNfe();

            produtoNfe.ID = Convert.ToInt32(reader["Id"]);
            produtoNfe.ProdutoID = Convert.ToInt32(reader["ProdutoID"]);
            produtoNfe.Quantidade = Convert.ToInt32(reader["Quantidade"]);
            produtoNfe.Imposto.ValorIPI = Convert.ToDouble(reader["ValorIPI"]);
            produtoNfe.Imposto.ValorICMS = Convert.ToDouble(reader["ValorICMS"]);

            return produtoNfe;
        }
    }
}

using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Dominio.Features.Produtos;
using Projeto_NFe.Infra.SQL;
using System;
using System.Collections.Generic;
using System.Data;

namespace Projeto_NFe.Infra.Data.Features.Produtos
{
    public class ProdutoRepositorioSql : IProdutoRepositorio
    {
        #region Script's SQL
        private string _sqlInserir = @"INSERT INTO [dbo].[Produto]
                                                       ([Codigo]
                                                       ,[Descricao]
                                                       ,[ValorUnitario])
                                                 VALUES
                                                       ({0}Codigo
                                                       ,{0}Descricao
                                                       ,{0}ValorUnitario)";

        private string _sqlDeletar = @"DELETE FROM [dbo].[Produto] WHERE Id = {0}Id";

        private string _sqlAtualizar = @"UPDATE [dbo].[Produto]
                                                   SET [Codigo] = {0}Codigo
                                                      ,[Descricao] = {0}Descricao
                                                      ,[ValorUnitario] = {0}ValorUnitario
                                                    WHERE Id = {0}Id";

        private string _sqlObterPorId = @"SELECT * FROM [dbo].[Produto] WHERE Id = {0}Id";

        private string _sqlObterTodos = @"SELECT * FROM [dbo].[Produto]";

        #endregion
        public Produto Atualizar(Produto produto)
        {
            if (produto.ID < 1)
                throw new ExcecaoIdentificadorInvalido();

            produto.Validar();

            produto.ID = Db.Update(_sqlAtualizar, ObtemParametros(produto));

            return produto;
        }

        public bool Deletar(long id)
        {
            if (id < 1)
                throw new ExcecaoIdentificadorInvalido();
            var parms = new Dictionary<string, object> { { "Id", id } };

            int linhasAfetadas = Db.Delete(_sqlDeletar, parms);

            if (linhasAfetadas < 1)
                return false;

            return true;
        }

        public Produto Inserir(Produto produto)
        {
            produto.Validar();

            produto.ID = Db.Insert(_sqlInserir, ObtemParametros(produto));

            return produto;
        }

        public Produto ObterPorId(long id)
        {
            if (id < 1)
                throw new ExcecaoIdentificadorInvalido();

            var parms = new Dictionary<string, object> { { "Id", id } };

            return Db.Get<Produto>(_sqlObterPorId, SetarParmetros, parms);
        }

        public List<Produto> ObterTodos()
        {
            return Db.GetAll(_sqlObterTodos, SetarParmetros);
        }



        private Dictionary<string, object> ObtemParametros(Produto produto)
        {
            var parms = new Dictionary<string, object>();
            parms.Add("ID", produto.ID);
            parms.Add("Codigo", produto.CodigoProduto);
            parms.Add("Descricao", produto.Descricao);
            parms.Add("ValorUnitario", produto.ValorUnitario);
            return parms;
        }

        private Produto SetarParmetros(IDataReader reader)
        {
            Produto produto = new Produto();

            produto.ID = Convert.ToInt32(reader["Id"]);
            produto.CodigoProduto = Convert.ToString(reader["Codigo"]);
            produto.Descricao = Convert.ToString(reader["Descricao"]);
            produto.ValorUnitario = Convert.ToDouble(reader["ValorUnitario"]);

            return produto;
        }

    }
}

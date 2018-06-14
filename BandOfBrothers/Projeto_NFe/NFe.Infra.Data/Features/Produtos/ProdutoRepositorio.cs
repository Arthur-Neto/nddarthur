using NFe.Dominio.Features.Produtos;
using NFe.Dominio.Features.Valores;
using System;
using System.Collections.Generic;
using System.Data;

namespace NFe.Infra.Data.Features.Produtos
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        #region Querys_SQL
        public const string _inserir = @"INSERT INTO TBProduto (CodigoProduto, Descricao, Quantidade, ValorTotal, ValorUnitario, ImpostoICMS, ImpostoIpi) VALUES (@CodigoProduto, @Descricao, @Quantidade, @ValorTotal, @ValorUnitario, @ImpostoICMS, @ImpostoIpi)";
        public const string _atualizar = @"UPDATE TBProduto SET CodigoProduto = @CodigoProduto, Descricao = @Descricao, Quantidade = @Quantidade, ValorTotal = @ValorTotal, ValorUnitario = @ValorUnitario, ImpostoICMS = @ImpostoICMS, ImpostoIpi = @ImpostoIpi Where Id = @Id";
        public const string _obterPorId = @"SELECT * FROM TBProduto WHERE Id = @Id";
        public const string _obterTodos = @"SELECT * FROM TBProduto";
        public const string _obterTodosPorId = @"SELECT * FROM TBProduto WHERE Id = @Id";
        public const string _deletar = @"DELETE FROM TBProduto WHERE Id = @Id";
        #endregion

        public Produto Atualizar(Produto entidade)
        {
            Db.Update(_atualizar, Take(entidade));

            return PegarPorId(entidade.Id);
        }

        public void Deletar(Produto entidade)
        {
            Db.Delete(_deletar, new object[] { "@Id", entidade.Id });
        }

        public Produto PegarPorId(long id)
        {
            return Db.Get(_obterPorId, Make, new object[] { "@Id", id });
        }

        public IEnumerable<Produto> PegarTodos()
        {
            return Db.GetAll(_obterTodos, Make);
        }

        public Produto Salvar(Produto entidade)
        {
            entidade.Id = Db.Insert(_inserir, Take(entidade));
            return entidade;
        }

        private static Func<IDataReader, Produto> Make = reader =>
            new Produto
            {
                Id = Convert.ToInt64(reader["Id"]),
                CodigoProduto = Convert.ToInt32(reader["CodigoProduto"]),
                Descricao = Convert.ToString(reader["Descricao"]),
                Quantidade = Convert.ToInt32(reader["Quantidade"]),
                ValorProduto = new ValorProduto()
                {
                    ICMS = Convert.ToDecimal(reader["ImpostoICMS"]),
                    Ipi = Convert.ToDecimal(reader["ImpostoIpi"]),
                    Total = Convert.ToDecimal(reader["ValorTotal"]),
                    Unitario = Convert.ToDecimal(reader["ValorUnitario"])
                }
            };

        private object[] Take(Produto produto)
        {
            return new object[]
            {
                "@Id", produto.Id,
                "@CodigoProduto", produto.CodigoProduto,
                "@Descricao", produto.Descricao,
                "@Quantidade", produto.Quantidade,
                "@ImpostoICMS", produto.ValorProduto.ICMS,
                "@ImpostoIpi", produto.ValorProduto.Ipi,
                "@ValorTotal", produto.ValorProduto.Total,
                "@ValorUnitario", produto.ValorProduto.Unitario
            };
        }
    }
}

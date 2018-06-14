using NFe.Dominio.Features.Destinatarios;
using NFe.Dominio.Features.Emitentes;
using NFe.Dominio.Features.Notas_Fiscais;
using NFe.Dominio.Features.Transportadores;
using NFe.Dominio.Features.Valores;
using System;
using System.Collections.Generic;
using System.Data;

namespace NFe.Infra.Data.Features.Notas_Fiscais
{
    public class NotaFiscalRepositorio : INotaFiscalRepositorio
    {
        #region Querys
        public const string _inserir = @"INSERT INTO TBNotaFiscal (NaturezaOperacao, DataEmissao, DataEntrada, ChaveAcesso, Emitido, ValorFrete, TotalProdutos, TotalNota, ImpostoICMS, ImpostoIPI, IdDestinatario, IdEmitente, IdTransportador, XmlNota) VALUES (@NaturezaOperacao, @DataEmissao, @DataEntrada, @ChaveAcesso, @Emitido, @ValorFrete, @TotalProdutos, @TotalNota, @ImpostoICMS, @ImpostoIPI, @IdDestinatario, @IdEmitente, @IdTransportador, @XmlNota)";
        public const string _atualizar = @"UPDATE TBNotaFiscal SET NaturezaOperacao = @NaturezaOperacao, DataEmissao = @DataEmissao, DataEntrada = @DataEntrada, ChaveAcesso = @ChaveAcesso, Emitido = @Emitido, ValorFrete = @ValorFrete, TotalProdutos = @TotalProdutos, TotalNota = @TotalNota, ImpostoICMS = @ImpostoICMS, ImpostoIPI = @ImpostoIPI, IdDestinatario = @IdDestinatario, IdEmitente = @IdEmitente, IdTransportador = @IdTransportador WHERE Id = @Id";
        public const string _obterPorId = @"SELECT * FROM TBNotaFiscal WHERE Id = @Id";
        public const string _obterTodos = @"SELECT * FROM TBNotaFiscal";
        public const string _deletar = @"DELETE FROM TBNotaFiscal WHERE Id = @Id";
        #endregion

        public NotaFiscal Atualizar(NotaFiscal entidade)
        {
            Db.Update(_atualizar, Take(entidade));

            return PegarPorId(entidade.Id);
        }

        public void Deletar(NotaFiscal entidade)
        {
            Db.Delete(_deletar, new object[] { "@Id", entidade.Id });
        }

        public NotaFiscal PegarPorId(long id)
        {
            return Db.Get(_obterPorId, Make, new object[] { "@Id", id });
        }

        public IEnumerable<NotaFiscal> PegarTodos()
        {
            return Db.GetAll(_obterTodos, Make);
        }

        public NotaFiscal Salvar(NotaFiscal entidade)
        {
            entidade.Id = Db.Insert(_inserir, Take(entidade));

            return entidade;
        }

        private static Func<IDataReader, NotaFiscal> Make = reader =>
         new NotaFiscal
         {
             Id = Convert.ToInt64(reader["Id"]),
             NaturezaOperacao = Convert.ToString(reader["NaturezaOperacao"]),
             DataEmissao = DBNull.Value.Equals(reader["DataEmissao"]) ? (DateTime?)null : Convert.ToDateTime(reader["DataEmissao"]),
             DataEntrada = Convert.ToDateTime(reader["DataEntrada"]),
             ChaveAcesso = Convert.ToString(reader["ChaveAcesso"]),
             Emitido = Convert.ToBoolean(reader["Emitido"]),
             Valor = new ValorNota()
             {
                 TotalNota = Convert.ToDecimal(reader["TotalNota"]),
                 Frete = Convert.ToDecimal(reader["ValorFrete"]),
                 TotalProdutos = Convert.ToDecimal(reader["TotalProdutos"]),
                 ICMS = Convert.ToDecimal(reader["ImpostoICMS"]),
                 Ipi = Convert.ToDecimal(reader["ImpostoIPI"])
             },
             Destinatario = new Destinatario()
             {
                 Id = Convert.ToInt64(reader["IdDestinatario"])
             },
             Emitente = new Emitente()
             {
                 Id = Convert.ToInt64(reader["IdEmitente"])
             },
             Transportador = new Transportador()
             {
                 Id = Convert.ToInt64(reader["IdTransportador"])
             },
             NotaFiscalXml = Convert.ToString(reader["XmlNota"])
         };

        private object[] Take(NotaFiscal notaFiscal)
        {
            return new object[]
            {
                "@Id", notaFiscal.Id,
                "@NaturezaOperacao", notaFiscal.NaturezaOperacao,
                "@DataEmissao", notaFiscal.DataEmissao,
                "@DataEntrada", notaFiscal.DataEntrada,
                "@ChaveAcesso", notaFiscal.ChaveAcesso,
                "@Emitido", notaFiscal.Emitido,
                "@TotalNota", notaFiscal.Valor.TotalNota,
                "@ValorFrete", notaFiscal.Valor.Frete,
                "@TotalProdutos", notaFiscal.Valor.TotalProdutos,
                "@ImpostoICMS", notaFiscal.Valor.ICMS,
                "@ImpostoIPI", notaFiscal.Valor.Ipi,
                "@IdDestinatario", notaFiscal.Destinatario.Id,
                "@IdEmitente", notaFiscal.Emitente.Id,
                "@IdTransportador", notaFiscal.Transportador.Id,
                "@XmlNota", notaFiscal.NotaFiscalXml
            };
        }
    }
}

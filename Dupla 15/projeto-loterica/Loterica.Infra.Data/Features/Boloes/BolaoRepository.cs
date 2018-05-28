using Loterica.Dominio.Exceptions;
using Loterica.Dominio.Features.Apostas;
using Loterica.Dominio.Features.Boloes;
using Loterica.Dominio.Features.Concursos;
using Loterica.Infra.Data.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Loterica.Infra.Data.Features.Boloes
{
    public class BolaoRepository : IBolaoRepository
    {
        #region Querys
        private const string _insert = @"INSERT INTO Bolao DEFAULT VALUES";
        private const string _insertAposta = @"INSERT INTO Aposta (IdConcurso, Data, Numeros, Validade, Valor, IdBolao) VALUES (@IdConcurso, @Data, @Numeros, @Validade, @Valor, @IdBolao)";
        private const string _getById = @"SELECT * FROM Bolao WHERE Id = @Id";
        private const string _getAllApostasByIdBolao = @"SELECT * FROM Aposta INNER JOIN Bolao ON Bolao.Id = Aposta.IdBolao WHERE Aposta.IdBolao = @Id";
        private const string _delete = @"DELETE FROM Bolao Where Id = @Id";
        private const string _getAll = @"SELECT * FROM Bolao";
        #endregion

        public Bolao Adicionar(Bolao entidade)
        {
            entidade.Validar();

            long _id = Db.Insert(_insert, Take(entidade));

            foreach (var aposta in entidade.Apostas)
            {
                Db.Insert(_insertAposta, TakeAposta(aposta, _id));
            }

            entidade = ObterPorId(Convert.ToInt32(_id));

            return entidade;
        }

        public Bolao Atualizar(Bolao entidade)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Bolao entidade)
        {
            if (entidade.Id == 0)
                throw new IdentifierUndefinedException();

            entidade.Validar();

            try
            {

                Db.Delete(_delete, Take(entidade));
            }
            catch (SqlException)
            {
                throw new DependenciaException();
            }
        }

        public Bolao ObterPorId(long id)
        {
            if (id == 0)
                throw new IdentifierUndefinedException();

            Bolao bolao = Db.Get(_getById, Make, new object[] { "@Id", id });
            if (bolao == null)
                return null;
            bolao.Apostas = Db.GetAll(_getAllApostasByIdBolao, MakeAposta, new object[] { "@Id", id });

            return bolao;
        }

        public IEnumerable<Bolao> PegarTodos()
        {
            List<Bolao> boloes = Db.GetAll(_getAll, Make);

            foreach (var bolao in boloes)
            {
                bolao.Apostas = Db.GetAll(_getAllApostasByIdBolao, MakeAposta, new object[] { "@Id", bolao.Id });
            }

            return boloes;
        }

        private static Func<IDataReader, Bolao> Make = reader =>
         new Bolao
         {
             Id = Convert.ToInt32(reader["Id"])
         };

        private object[] Take(Bolao bolao)
        {
            return new object[]
            {
                "@Id", bolao.Id
            };
        }

        private static Func<IDataReader, Aposta> MakeAposta = reader =>
           new Aposta
           {
               Id = Convert.ToInt64(reader["Id"]),
               Concurso = new Concurso() { Id = Convert.ToInt32(reader["IdConcurso"]) },
               Data = Convert.ToDateTime(reader["Data"]),
               Numeros = (Convert.ToString(reader["Numeros"])).Split(',').Select(Int32.Parse).ToList(),
               Validade = Convert.ToDateTime(reader["Validade"]),
               Valor = Convert.ToDecimal(reader["Valor"])
           };

        private object[] TakeAposta(Aposta aposta, long idBolao)
        {
            return new object[]
            {
                "@Id", aposta.Id,
                "@IdConcurso", aposta.Concurso.Id,
                "@Data", aposta.Data,
                "@Numeros", string.Join(",", aposta.Numeros.Select(n => n.ToString()).ToArray()),
                "@Validade", aposta.Validade,
                "@Valor", aposta.Valor,
                "@IdBolao", idBolao
            };
        }
    }
}

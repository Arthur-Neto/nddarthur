using Loterica.Dominio.Exceptions;
using Loterica.Dominio.Features.Apostas;
using Loterica.Dominio.Features.Concursos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Loterica.Infra.Data.Features.Apostas
{
    public class ApostaRepository : IApostaRepository
    {
        #region Querys
        private const string _insert = @"INSERT INTO Aposta (IdConcurso, Data, Numeros, Validade, Valor) VALUES (@IdConcurso, @Data, @Numeros, @Validade, @Valor)";
        private const string _update = @"UPDATE Aposta SET IdConcurso = @IdConcurso, Data = @Data, Numeros = @Numeros, Validade = @Validade, Valor = @Valor WHERE Id = @Id";
        private const string _getById = @"SELECT * FROM Aposta WHERE Id = @Id";
        private const string _getAll = @"SELECT * FROM Aposta";
        private const string _delete = @"DELETE FROM Aposta Where Id = @Id";
        #endregion

        public Aposta Adicionar(Aposta entidade)
        {
            entidade.Validar();

            long _id = Db.Insert(_insert, Take(entidade));

            entidade = ObterPorId(Convert.ToInt32(_id));

            return entidade;
        }

        public Aposta Atualizar(Aposta entidade)
        {
            if (entidade.Id == 0)
                throw new IdentifierUndefinedException();

            entidade.Validar();

            Db.Update(_update, Take(entidade));

            entidade = ObterPorId(entidade.Id);

            return entidade;
        }

        public void Deletar(Aposta entidade)
        {
            if (entidade.Id == 0)
                throw new IdentifierUndefinedException();

            entidade.Validar();

            Db.Delete(_delete, Take(entidade));
        }

        public Aposta ObterPorId(long id)
        {
            if (id == 0)
                throw new IdentifierUndefinedException();

            return Db.Get(_getById, Make, new object[] { "@Id", id });
        }

        public IEnumerable<Aposta> PegarTodos()
        {
            return Db.GetAll(_getAll, Make);
        }

        private static Func<IDataReader, Aposta> Make = reader =>
           new Aposta
           {
               Id = Convert.ToInt64(reader["Id"]),
               Concurso = new Concurso() { Id = Convert.ToInt32(reader["IdConcurso"]) },
               Data = Convert.ToDateTime(reader["Data"]),
               Numeros = (Convert.ToString(reader["Numeros"])).Split(',').Select(Int32.Parse).ToList(),
               Validade = Convert.ToDateTime(reader["Validade"]),
               Valor = Convert.ToDecimal(reader["Valor"])
           };

        private object[] Take(Aposta aposta)
        {
            return new object[]
            {
                "@Id", aposta.Id,
                "@IdConcurso", aposta.Concurso.Id,
                "@Data", aposta.Data,
                "@Numeros", string.Join(",", aposta.Numeros.Select(n => n.ToString()).ToArray()),
                "@Validade", aposta.Validade,
                "@Valor", aposta.Valor
            };
        }
    }
}

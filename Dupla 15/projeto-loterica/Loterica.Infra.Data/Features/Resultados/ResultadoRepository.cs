using Loterica.Dominio.Exceptions;
using Loterica.Dominio.Features.Resultados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Loterica.Infra.Data.Features.Resultados
{
    public class ResultadoRepository : IResultadoRepository
    {
        #region Querys
        private const string _insert = @"INSERT INTO Resultado (NumerosSorteados, MediaQuadra, MediaQuina, MediaSena) VALUES (@NumerosSorteados, @MediaQuadra, @MediaQuina, @MediaSena);";
        private const string _update = @"UPDATE Resultado SET NumerosSorteados = @NumerosSorteados, MediaQuadra = @MediaQuadra, MediaQuina = @MediaQuina, MediaSena = @MediaSena WHERE Id = @Id";
        private const string _getById = @"SELECT * FROM Resultado WHERE Id = @Id";
        private const string _getAll = @"SELECT * FROM Resultado";
        private const string _delete = @"DELETE FROM Resultado WHERE Id = @Id";
        #endregion

        public Resultado Adicionar(Resultado entidade)
        {
            entidade.Validar();

            long id = Db.Insert(_insert, Take(entidade));

            entidade = ObterPorId(id);

            return entidade;
        }

        public Resultado Atualizar(Resultado entidade)
        {
            if (entidade.Id == 0)
                throw new IdentifierUndefinedException();

            entidade.Validar();

            Db.Update(_update, Take(entidade));

            entidade = ObterPorId(entidade.Id);

            return entidade;
        }

        public void Deletar(Resultado entidade)
        {
            if (entidade.Id == 0)
                throw new IdentifierUndefinedException();

            entidade.Validar();

            Db.Delete(_delete, Take(entidade));
        }

        public Resultado ObterPorId(long id)
        {
            if (id == 0)
                throw new IdentifierUndefinedException();
            
            return Db.Get(_getById, Make, new object[] { "@Id", id });
        }

        public IEnumerable<Resultado> PegarTodos()
        {
            return Db.GetAll(_getAll, Make);
        }

        private static Func<IDataReader, Resultado> Make = reader =>
           new Resultado
           {
               Id = Convert.ToInt64(reader["Id"]),
               NumerosSorteados = (Convert.ToString(reader["NumerosSorteados"])).Split(',').Select(Int32.Parse).ToList(),
               MediaQuadra = Convert.ToDecimal(reader["MediaQuadra"]),
               MediaQuina = Convert.ToDecimal(reader["MediaQuina"]),
               MediaSena = Convert.ToDecimal(reader["MediaSena"])
           };

        private object[] Take(Resultado resultado)
        {
            return new object[]
            {
                "@Id", resultado.Id,
                "@NumerosSorteados", string.Join(",", resultado.NumerosSorteados.Select(n => n.ToString()).ToArray()),
                "@MediaQuadra", resultado.MediaQuadra,
                "@MediaQuina", resultado.MediaQuina,
                "@MediaSena", resultado.MediaSena
            };
        }
    }
}

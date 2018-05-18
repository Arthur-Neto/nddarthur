using Loterica.Dominio.Base;
using Loterica.Dominio.Features.Resultados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Infra.Data.Features.Resultados
{
    public class ResultadoRepository : IRepository<Resultado>
    {
        #region Querys
        private const string _insert = @"INSERT INTO Resultado (NumerosSorteados) VALUES (@NumerosSorteados)";
        private const string _update = @"UPDATE Resultado SET NumerosSorteados = @NumerosSorteados WHERE Id = @Id";
        private const string _getById = @"SELECT * FROM Resultado WHERE Id = @Id";
        private const string _getAll = @"SELECT * FROM Resultado";
        private const string _delete = @"DELETE FROM Resultado WHERE Id = @Id";
        #endregion

        public Resultado Adicionar(Resultado entidade)
        {
            long id = Db.Insert(_insert, Take(entidade));

            entidade = ObterPorId(Convert.ToInt32(id));

            return entidade;
        }

        public Resultado Atualizar(Resultado entidade)
        {
            Db.Update(_update, Take(entidade));

            entidade = ObterPorId(entidade.Id);

            return entidade;
        }

        public void Deletar(Resultado entidade)
        {
            Db.Delete(_delete, Take(entidade));
        }

        public Resultado ObterPorId(int id)
        {
            return Db.Get(_getById, Make, new object[] { "@Id", id });
        }

        public IEnumerable<Resultado> PegarTodos()
        {
            return Db.GetAll(_getAll, Make);
        }

        private static Func<IDataReader, Resultado> Make = reader =>
           new Resultado
           {
               Id = Convert.ToInt32(reader["Id"]),
               NumerosSorteados = (Convert.ToString(reader["NumerosSorteados"])).Split(',').Select(Int32.Parse).ToList()
           };

        private object[] Take(Resultado resultado)
        {
            return new object[]
            {
                "@Id", resultado.Id,
                "@NumerosSorteados", string.Join(",", resultado.NumerosSorteados.Select(n => n.ToString()).ToArray())
            };
        }
    }
}

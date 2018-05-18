using Loterica.Dominio.Base;
using Loterica.Dominio.Features.Apostas;
using Loterica.Dominio.Features.Concursos;
using Loterica.Infra.Data.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Infra.Data.Features.Concursos
{
    public class ConcursoRepository : IRepository<Concurso>
    {

        #region Querys
        private const string _insert = @"INSERT INTO Concurso (Data, IsFechado, Premio) VALUES (@Data, @IsFechado, @Premio)";
        private const string _update = @"UPDATE Concurso Set Data = @Data, IsFechado = @IsFechado, Premio = @Premio WHERE Id = @Id";
        private const string _getById = @"SELECT * FROM Concurso Where Id = @Id";
        private const string _getAll = @"SELECT * FROM Concurso";
        private const string _delete = @"DELETE FROM Concurso Where Id = @Id";
        #endregion

        public Concurso Adicionar(Concurso entidade)
        {
            long _id = Db.Insert(_insert, Take(entidade));

            entidade = ObterPorId(Convert.ToInt32(_id));

            return entidade;
        }

        public Concurso Atualizar(Concurso entidade)
        {
            Db.Update(_insert, Take(entidade));

            entidade = ObterPorId(entidade.Id);

            return entidade;
        }

        public void Deletar(Concurso entidade)
        {
            try
            {
                Db.Delete(_delete, Take(entidade));
            }
            catch (SqlException)
            {
                throw new DependenciaException();
            }
        }

        public Concurso ObterPorId(int id)
        {
            return Db.Get(_getById, Make, new object[] { "@Id", id });
        }

        public IEnumerable<Concurso> PegarTodos()
        {
            return Db.GetAll(_getAll, Make);
        }

        private static Func<IDataReader, Concurso> Make = reader =>
         new Concurso
         {
             Id = Convert.ToInt32(reader["Id"]),
             Data = Convert.ToDateTime(reader["Data"]),
             IsFechado = Convert.ToBoolean(reader["IsFechado"]),
             Premio = Convert.ToDecimal(reader["Premio"]),

         };

        private object[] Take(Concurso concurso)
        {
            return new object[]
            {
                "@Id", concurso.Id,
                "@Data", concurso.Data,
                "@IsFechado", concurso.IsFechado,
                "@Premio", concurso.Premio
            };
        }
    }
}

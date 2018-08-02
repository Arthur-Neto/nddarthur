using ProvaTDD.Dominio.Features.Alunos;
using ProvaTDD.Dominio.Features.Resultados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTDD.Infra.Data.Features.Resultados
{
    public class ResultadoRepositorio : IResultadoRepositorio
    {
        #region Querys
        private const string _inserir = @"INSERT INTO TBResultado (Nota) VALUES(@Nota)";
        private const string _pegarPorId = @"SELECT * FROM TBResultado WHERE Id = @Id";
        private const string _pegarTodos = @"SELECT * FROM TBResultado";
        private const string _deletar = @"DELETE FROM TBResultado WHERE Id = @Id";
        private const string _atualizar = @"UPDATE TBResultado SET Nota = @Nota WHERE Id = @Id";
        #endregion

        public Resultado Atualizar(Resultado entidade)
        {
            Db.Update(_atualizar, Take(entidade));

            return PegarPorId(entidade.Id);
        }

        public void Deletar(Resultado entidade)
        {
            Db.Delete(_deletar, new object[] { "@Id", entidade.Id });
        }

        public Resultado PegarPorId(long id)
        {
            return Db.Get(_pegarPorId, Make, new object[] { "@Id", id });
        }

        public IList<Resultado> PegarTodos()
        {
            return Db.GetAll(_pegarTodos, Make);
        }

        public Resultado Salvar(Resultado entidade)
        {
            entidade.Id = Db.Insert(_inserir, Take(entidade));
            return entidade;
        }

        private static Func<IDataReader, Resultado> Make = reader =>
        new Resultado
        {
            Id = Convert.ToInt64(reader["Id"]),
            Nota = Convert.ToDouble(reader["nota"])
        };

        private object[] Take(Resultado entidade)
        {
            return new object[]
            {
                "@Id", entidade.Id,
                "@Nota", entidade.Nota
            };
        }
    }
}

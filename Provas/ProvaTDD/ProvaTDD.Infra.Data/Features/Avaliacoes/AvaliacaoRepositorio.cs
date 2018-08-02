using ProvaTDD.Dominio.Features.Avaliacoes;
using ProvaTDD.Dominio.Features.Resultados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTDD.Infra.Data.Features.Avaliacoes
{
    public class AvaliacaoRepositorio : IAvaliacaoRepositorio
    {
        #region Querys
        private const string _inserir = @"INSERT INTO TBAvaliacao(Assunto, Data) VALUES(@Assunto, @Data)";
        private const string _pegarPorId = @"SELECT * FROM TBAvaliacao WHERE Id = @Id";
        private const string _pegarTodos = @"SELECT * FROM TBAvaliacao";
        private const string _deletar = @"DELETE FROM TBAvaliacao WHERE Id = @Id";
        private const string _atualizar = @"UPDATE TBAvaliacao SET Assunto = @Assunto, Data = @Data WHERE Id = @Id";
        #endregion

        public Avaliacao Atualizar(Avaliacao entidade)
        {
            Db.Update(_atualizar, Take(entidade));

            return PegarPorId(entidade.Id);
        }

        public void Deletar(Avaliacao entidade)
        {
            Db.Delete(_deletar, new object[] { "@Id", entidade.Id });
        }

        public Avaliacao PegarPorId(long id)
        {
            return Db.Get(_pegarPorId, Make, new object[] { "@Id", id });
        }

        public IList<Avaliacao> PegarTodos()
        {
            return Db.GetAll(_pegarTodos, Make);
        }

        public Avaliacao Salvar(Avaliacao entidade)
        {
            entidade.Id = Db.Insert(_inserir, Take(entidade));
            return entidade;
        }

        private static Func<IDataReader, Avaliacao> Make = reader =>
        new Avaliacao
        {
            Id = Convert.ToInt64(reader["Id"]),
            Assunto = Convert.ToString(reader["Assunto"]),
            Data = Convert.ToDateTime(reader["Data"])
        };

        private object[] Take(Avaliacao entidade)
        {
            return new object[]
            {
                "@Id", entidade.Id,
                "@Assunto", entidade.Assunto,
                "@Data", entidade.Data
            };
        }
    }
}

using ProvaTDD.Dominio.Features.Alunos;
using System;
using System.Collections.Generic;
using System.Data;

namespace ProvaTDD.Infra.Data.Features.Alunos
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        #region Querys
        private const string _inserir = @"INSERT INTO TBAluno(Nome, Media, Idade) VALUES(@Nome, @Media, @Idade)";
        private const string _pegarPorId = @"SELECT * FROM TBAluno WHERE Id = @Id";
        private const string _pegarTodos = @"SELECT * FROM TBAluno";
        private const string _deletar = @"DELETE FROM TBAluno WHERE Id = @Id";
        private const string _atualizar = @"UPDATE TBAluno SET Nome = @Nome, Media = @Media, Idade = @Idade WHERE Id = @Id";
        #endregion

        public Aluno Atualizar(Aluno entidade)
        {
            Db.Update(_atualizar, Take(entidade));

            return PegarPorId(entidade.Id);
        }

        public void Deletar(Aluno entidade)
        {
            Db.Delete(_deletar, new object[] { "@Id", entidade.Id });
        }

        public Aluno PegarPorId(long id)
        {
            return Db.Get(_pegarPorId, Make, new object[] { "@Id", id });
        }

        public IList<Aluno> PegarTodos()
        {
            return Db.GetAll(_pegarTodos, Make);
        }

        public Aluno Salvar(Aluno entidade)
        {
            entidade.Id = Db.Insert(_inserir, Take(entidade));
            return entidade;
        }

        private static Func<IDataReader, Aluno> Make = reader =>
        new Aluno
        {
            Id = Convert.ToInt64(reader["Id"]),
            Idade = Convert.ToInt16(reader["Idade"]),
            Media = Convert.ToDouble(reader["Media"]),
            Nome = Convert.ToString(reader["Nome"])
        };

        private object[] Take(Aluno entidade)
        {
            return new object[]
            {
                "@Id", entidade.Id,
                "@Idade", entidade.Idade,
                "@Media", entidade.Media,
                "@Nome", entidade.Nome
            };
        }
    }
}

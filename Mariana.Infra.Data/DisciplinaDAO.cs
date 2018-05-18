using Mariana.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Mariana.Infra.Data
{
    public class DisciplinaDAO
    {
        #region queries 
        private const string sqlInsertDisciplina = @"INSERT INTO TBDisciplina (Nome) VALUES (@Nome);";

        private const string sqlGetAllDisciplinas = @"SELECT Id, Nome FROM TBDisciplina";

        private const string sqlGetDisciplinaById = @"SELECT Id, Nome FROM TBDisciplina WHERE Id = @Id";

        private const string sqlGetDisciplinaByName = @"SELECT Id, Nome FROM TBDisciplina WHERE Nome = @Nome AND Id <> @Id";

        private const string sqlGetDisciplinaFromMateriaById = @"SELECT Id FROM TBMateria WHERE IdDisciplina = @Id";

        private const string sqlUpdateDisciplina = @"UPDATE TBDisciplina SET Nome = @Nome WHERE Id = @Id";

        private const string sqlDeleteDisciplina = @"DELETE FROM TBDisciplina WHERE Id = @Id";

        #endregion queries

        public DisciplinaDAO()
        {
        }

        public Disciplina Adicionar(Disciplina disciplina)
        {
            DB.Add(sqlInsertDisciplina, GetParam(disciplina));

            return disciplina;
        }

        public Disciplina Atualizar(Disciplina disciplina)
        {
            DB.Update(sqlUpdateDisciplina, GetParam(disciplina));

            return disciplina;
        }

        public int Excluir(int disciplinaId)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("Id", disciplinaId);

            DB.Delete(sqlDeleteDisciplina, dic);

            return disciplinaId;
        }

        public IList<Disciplina> ObterTodosItens()
        {
            return DB.GetAll(sqlGetAllDisciplinas, Converter);
        }

        public bool Existe(Disciplina disciplina)
        {
            if (DB.GetByName(sqlGetDisciplinaByName, Converter, GetParam(disciplina)) == null)
                return false;
            else
                return true;
        }

        public bool ExisteEmMateria(Disciplina disciplina)
        {
            if (DB.GetById(sqlGetDisciplinaFromMateriaById, ConverterMateria, GetParam(disciplina)) == null)
                return false;
            else
                return true;
        }

        private static Disciplina Converter(IDataReader _reader)
        {
            Disciplina disciplina = new Disciplina();
            disciplina.Id = Convert.ToInt32(_reader["Id"]);
            disciplina.Nome = Convert.ToString(_reader["Nome"]);

            return disciplina;
        }

        private static Materia ConverterMateria(IDataReader _reader)
        {
            Materia materia = new Materia();
            materia.Id = Convert.ToInt32(_reader["Id"]);

            return materia;
        }

        public Dictionary<string, object> GetParam(Disciplina disciplina)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("Id", disciplina.Id);
            dic.Add("Nome", disciplina.Nome);

            return dic;
        }
    }
}

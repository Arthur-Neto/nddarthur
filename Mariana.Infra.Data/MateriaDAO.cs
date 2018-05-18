using Mariana.Dominio;
using Mariana.Infra.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Mariana.Infra.Data
{
    public class MateriaDAO
    {
        #region queries 
        private const string sqlInsertMateria = @"INSERT INTO TBMateria (IdDisciplina, IdSerie, Nome) VALUES (@IdDisciplina, @IdSerie, @Nome);";

        private const string sqlGetAllMaterias = @"SELECT m.Id,
                                                    m.IdDisciplina, 
                                                    m.IdSerie,
                                                    m.Nome,
                                                    d.Nome AS NomeDisciplina,
                                                    s.Numero
                                                    FROM TBMateria AS m 
                                                    INNER JOIN TBDisciplina AS d 
                                                    ON d.Id = m.IdDisciplina
                                                    INNER JOIN TBSerie AS s
                                                    ON s.Id = m.IdSerie";

        private const string sqlGetMateriaById = @"SELECT 
                                                    m.Id,
                                                    m.IdDisciplina, 
                                                    m.IdSerie,
                                                    m.Nome,
                                                    d.Nome AS NomeDisciplina,
                                                    s.Numero
                                                    FROM TBMateria AS m 
                                                    INNER JOIN TBDisciplina AS d 
                                                    ON d.Id = m.IdDisciplina
                                                    INNER JOIN TBSerie AS s
                                                    ON s.Id = m.IdSerie
                                                    WHERE m.Id = @Id";

        private const string sqlGetMateriaByName = @"SELECT Id, IdDisciplina, IdSerie, Nome FROM TBMateria WHERE Nome = @Nome AND Id <> @Id AND IdSerie = @IdSerie";

        private const string sqlUpdateMateria = @"UPDATE TBMateria SET Nome = @Nome, IdDisciplina = @IdDisciplina, IdSerie = @IdSerie WHERE Id = @Id";

        private const string sqlDeleteMateria = @"DELETE FROM TBMateria WHERE Id = @Id";

        private const string sqlGetDisciplinas = @"SELECT TBMateria.Id, TBMateria.Nome, TBMateria.IdSerie FROM TBMateria INNER JOIN TBDisciplina ON TBDisciplina.Id = TBMateria.IdDisciplina WHERE TBDisciplina.Id = @IdDisciplina";

        private const string sqlGetMateriaFromQuestaoById = @"SELECT Id FROM TBQuestao WHERE IdMateria = @Id";
        #endregion queries

        public MateriaDAO()
        {
        }

        public Materia Adicionar(Materia materia)
        {
            DB.Add(sqlInsertMateria, GetParam(materia));

            return materia;
        }

        public Materia Atualizar(Materia materia)
        {
            DB.Update(sqlUpdateMateria, GetParam(materia));

            return materia;
        }

        public int Excluir(int materiaId)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("Id", materiaId);

            DB.Delete(sqlDeleteMateria, dic);

            return materiaId;
        }
        public bool Existe(Materia materia)
        {
            Materia materiaPega = DB.GetByName(sqlGetMateriaByName, ConverterGetByName, GetParam(materia));
            if (materiaPega == null)
                return false;
            else if (materiaPega.Serie.Id != materia.Serie.Id)
                return false;
            else
                return true;
        }

        public IList<Materia> ObterTodosItens()
        {
            return DB.GetAll(sqlGetAllMaterias, Converter);
        }

        public IList<Materia> ObterMateriasPorDisciplina(Disciplina disciplina)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("IdDisciplina", disciplina.Id);

            return DB.GetAllById(sqlGetDisciplinas, Converter, dic);
        }

        private static Materia Converter(IDataReader _reader)
        {
            Materia materia = new Materia();

            materia.Id = Convert.ToInt32(_reader["Id"]);
            materia.Disciplina.Id = Convert.ToInt32(_reader["IdDisciplina"]);
            materia.Disciplina.Nome = Convert.ToString(_reader["NomeDisciplina"]);
            materia.Serie.Id = Convert.ToInt32(_reader["IdSerie"]);
            materia.Serie.NumeroSerie = Convert.ToInt32(_reader["Numero"]);
            materia.Nome = Convert.ToString(_reader["Nome"]);

            return materia;
        }
        private static Materia ConverterMateriaId(IDataReader _reader)
        {
            Materia materia = new Materia();
            materia.Id = Convert.ToInt32(_reader["Id"]);

            return materia;
        }

        public bool ExisteEmQuestao(int id)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("Id", id);
            if (DB.GetById(sqlGetMateriaFromQuestaoById, ConverterMateriaId, dic) == null)
                return false;
            else
                return true;
        }

        private static Materia ConverterGetByName(IDataReader _reader)
        {
            Materia materia = new Materia();

            materia.Id = Convert.ToInt32(_reader["Id"]);
            materia.Disciplina.Id = Convert.ToInt32(_reader["IdDisciplina"]);
            materia.Serie.Id = Convert.ToInt32(_reader["IdSerie"]);
            materia.Nome = Convert.ToString(_reader["Nome"]);

            return materia;
        }

        public Dictionary<string, object> GetParam(Materia materia)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("Id", materia.Id);
            dic.Add("IdDisciplina", materia.Disciplina.Id);
            dic.Add("IdSerie", materia.Serie.Id);
            dic.Add("Nome", materia.Nome);

            return dic;

        }
    }
}

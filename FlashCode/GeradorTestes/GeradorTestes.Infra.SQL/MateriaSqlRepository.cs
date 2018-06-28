using GeradorTestes.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeradorTestes.Domain;
using System.Data;
using GeradorTestes.Infra.Database;

namespace GeradorTestes.Infra.SQL
{
    public class MateriaSqlRepository : IMateriaRepository
    {
        #region SCRIPTS SQL
        private const string _sqlInsert = "INSERT INTO TBMaterias (Nome, SerieID, DisciplinaID) VALUES ({0}Nome, {0}SerieID, {0}DisciplinaID)";

        private const string _sqlSelectAll = "SELECT materias.ID , materias.Nome, materias.SerieID, series.Serie , materias.DisciplinaID, disciplina.Nome as 'disciplinaNome' FROM TBMaterias as materias"
                                            + " inner join TBSeries as series on series.ID = materias.SerieID"
                                             + "   inner join TBDisciplinas as disciplina on disciplina.ID = materias.DisciplinaID"
                                                + " group by disciplina.Nome , materias.ID , materias.Nome, materias.SerieID, series.Serie , materias.DisciplinaID "
                                                + "  order by disciplina.Nome, materias.Nome ";

        private const string _sqlUpdate = "UPDATE TBMaterias SET Nome = {0}Nome, SerieID = {0}SerieID, DisciplinaID = {0}DisciplinaID  WHERE ID = {0}ID ";

        private const string _sqlDelete = "DELETE FROM TBMaterias WHERE ID = {0}ID";

        private const string _sqlSelectByName = "SELECT * FROM TBMaterias WHERE Nome = {0}Nome and SerieID = {0}SerieID";

        public const string _sqlSelectByIDWhereSerieID = "SELECT * FROM TBMaterias WHERE SerieID = ({0}SerieID) ";

        public const string _sqlSelectByIDWhereDisciplinaID = "SELECT * FROM TBMaterias WHERE DisciplinaID = ({0}DisciplinaID) ";

        public const string _sqlSelectByIDWhereSerieIDAndDisciplinaID = "select * from TBMaterias {0}";
        #endregion

        public Materia Add(Materia entidade)
        {
            entidade.ID = Db.Insert(_sqlInsert, Take(entidade));

            return entidade;
        }

        public void Delete(Materia entidade)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "Id", entidade.ID } };

            Db.Delete(_sqlDelete, parms);
        }

        public IList<Materia> GetAll()
        {
            return Db.GetAll<Materia>(_sqlSelectAll, Make);
        }

        public bool GetByIDDiciplina(int id)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "DisciplinaID", id } };

            Materia s = Db.Get<Materia>(_sqlSelectByIDWhereDisciplinaID, MakeDisciplina, parms);

            if (s != null)
                return true;

            return false;
        }

        public bool GetByIDSerie(int id)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "SerieID", id } };

            Materia m = Db.Get<Materia>(_sqlSelectByIDWhereSerieID, MakeSerie, parms);

            if (m != null)
                return true;

            return false;
        }

        public IList<Materia> GetByIDSerieAndDisciplina(Serie serie = null, Disciplina disciplina = null)
        {
            Dictionary<string, object> parms;
            string where;

            if (serie.Nome != "" && disciplina.Nome == "")
            {
                parms = new Dictionary<string, object> { { "SerieNome", serie.Nome }, { "DisciplinaNome", disciplina.Nome } };
                where = "where SerieID in (select ID from TBSeries where Serie = {0}SerieNome) and DisciplinaID in (select ID from TBDisciplinas where Nome like '%%')";
            }
            else if (serie.Nome == "" && disciplina.Nome != "")
            {
                parms = new Dictionary<string, object> { { "SerieNome", serie.Nome }, { "DisciplinaNome", disciplina.Nome } };
                where = "where SerieID in (select ID from TBSeries where Serie like '%%') and DisciplinaID in (select ID from TBDisciplinas where Nome = {0}DisciplinaNome)";
            }
            else if (serie.Nome.Equals("") && disciplina.Nome.Equals(""))
            {
                parms = null;
                where = "where SerieID in (select ID from TBSeries) and DisciplinaID in (select ID from TBDisciplinas)";
            }
            else
            {
                parms = new Dictionary<string, object> { { "SerieNome", serie.Nome }, { "DisciplinaNome", disciplina.Nome } };
                where = "where SerieID in (select ID from TBSeries where Serie = {0}SerieNome) and DisciplinaID in (select ID from TBDisciplinas where Nome = {0}DisciplinaNome)";
            }
            string sql = string.Format(_sqlSelectByIDWhereSerieIDAndDisciplinaID, where);
            return Db.GetAll<Materia>(sql, Make, parms);
        }

        public bool GetByName(Materia materia)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "Nome", materia.Nome }, { "SerieID", materia.serie.ID } };
            Materia m = Db.Get<Materia>(_sqlSelectByName, MakeGetByName, parms);

            if (m != null)
                return true;

            return false;
        }

        public Materia Make(IDataReader reader)
        {
            Materia materia = new Materia();

            materia.ID = Convert.ToInt32(reader["ID"]);
            materia.Nome = Convert.ToString(reader["Nome"]);
            materia.serie = new Serie
            {
                ID = Convert.ToInt32(reader["SerieID"])
            };
            materia.disciplina = new Disciplina
            {
                ID = Convert.ToInt32(reader["DisciplinaID"])
            };
            return materia;
        }

        public Materia MakeDisciplina(IDataReader reader)
        {
            Materia materia = new Materia();

            materia.disciplina.ID = Convert.ToInt32(reader["SerieID"]);

            return materia;
        }

        public Materia MakeGetByName(IDataReader reader)
        {
            Materia materia = new Materia();

            materia.ID = Convert.ToInt32(reader["ID"]);
            materia.Nome = Convert.ToString(reader["Nome"]);
            materia.serie = new Serie
            {
               ID = Convert.ToInt32(reader["SerieID"])
            };

            return materia;
        }

        public Materia MakeSerie(IDataReader reader)
        {
            Materia materia = new Materia();
            materia.serie.ID = Convert.ToInt32(reader["SerieID"]);
            return materia;
        }

        public Dictionary<string, object> Take(Materia entidade)
        {
            return new Dictionary<string, object>
            {
                { "ID", entidade.ID },
                { "Nome", entidade.Nome },
                { "SerieID", entidade.serie.ID },
                { "DisciplinaID", entidade.disciplina.ID }
            };
        }

        public void Update(Materia entidade)
        {
            Db.Update(_sqlUpdate, Take(entidade));
        }
    }
}

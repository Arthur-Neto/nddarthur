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
    public class DisciplinaSQlRepository : IDisciplinaRepository
    {
        #region SCRIPTS SQL
        private const string _sqlInsert = "INSERT INTO TBDisciplinas (Nome) VALUES({0}Nome)";

        private const string _sqlSelectGetByName = "SELECT * FROM TBDisciplinas WHERE Nome = {0}Nome";

        private const string _sqlSelectAll = "SELECT * FROM TBDisciplinas order by Nome";

        private const string _sqlDelete = "DELETE FROM TBDisciplinas WHERE ID={0}ID";

        private const string _sqlUpdate = "UPDATE TBDisciplinas set Nome = {0}Nome WHERE ID={0}ID";

        #endregion

        public Disciplina Add(Disciplina entidade)
        {
            entidade.ID = Db.Insert(_sqlInsert, Take(entidade));

            return entidade;
        }

        public void Delete(Disciplina entidade)
        {
            Dictionary<string, object> parms = new Dictionary<string, object>
            {
                { "ID", entidade.ID}
            };
            Db.Update(_sqlDelete, parms);
        }

        public IList<Disciplina> GetAll()
        {
            return Db.GetAll<Disciplina>(_sqlSelectAll, Make);
        }

        public bool GetByName(Disciplina disciplina)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "Nome", disciplina.Nome } };
            Disciplina d = Db.Get<Disciplina>(_sqlSelectGetByName, Make, parms);
            if (d != null)
                return true;
            return false;
        }

        public Disciplina Make(IDataReader reader)
        {
            Disciplina disciplina = new Disciplina();

            disciplina.ID = Convert.ToInt32(reader["ID"]);
            disciplina.Nome = Convert.ToString(reader["Nome"]);
            return disciplina;
        }

        public Dictionary<string, object> Take(Disciplina entidade)
        {
            return new Dictionary<string, object>
            {
                { "ID", entidade.ID },
                { "Nome", entidade.Nome }
            };
        }

        public void Update(Disciplina entidade)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> {
                { "ID", entidade.ID },
                { "Nome", entidade.Nome}
            };
            Db.Update(_sqlUpdate, parms);
        }
    }
}

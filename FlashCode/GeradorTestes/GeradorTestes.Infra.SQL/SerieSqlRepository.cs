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
    public class SerieSqlRepository : ISerieRepository
    {
        #region SCRIPTS SQL
        public const string _sqlInsert = "INSERT INTO TBSeries (Serie) VALUES ({0}Serie)";

        public const string _sqlUpdate = "UPDATE TBSeries SET Serie={0}Serie WHERE Id={0}Id";

        public const string _sqlDelete = "DELETE FROM TBSeries WHERE Id={0}Id";

        public const string _sqlSelectAll = @" SELECT ID, Serie FROM TBSeries order by serie ";

        public const string _sqlSelectByName = "SELECT * FROM TBSeries WHERE Serie = ({0}Serie) ";

        #endregion

        public Serie Add(Serie entidade)
        {
            entidade.ID = Db.Insert(_sqlInsert, Take(entidade));

            return entidade;
        }

        public void Delete(Serie entidade)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "Id", entidade.ID } };

            Db.Delete(_sqlDelete, parms);
        }

        public IList<Serie> GetAll()
        {
            return Db.GetAll(_sqlSelectAll, Make);
        }

        public bool GetByName(Serie serie)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "Serie", serie.Nome } };
            Serie s = Db.Get<Serie>(_sqlSelectByName, Make, parms);
            if (s != null)
                return true;

            return false;
        }

        public Serie Make(IDataReader reader)
        {
            Serie serie = new Serie();

            serie.ID = Convert.ToInt32(reader["ID"]);
            serie.Nome = Convert.ToString(reader["Serie"]);
            
            return serie;
        }

        public Dictionary<string, object> Take(Serie entidade)
        {
            return new Dictionary<string, object>
            {
                { "ID", entidade.ID },
                { "Serie", entidade.Nome }
            };
        }

        public void Update(Serie entidade)
        {
            Db.Update(_sqlUpdate, Take(entidade));
        }
    }
}

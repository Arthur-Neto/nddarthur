using Mariana.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariana.Infra.Data
{
    public class SerieDAO
    {
        #region queries 
        private const string sqlInsertSerie = @"INSERT INTO TBSerie (Numero) VALUES (@Numero);";

        private const string sqlGetAllSerie = @"SELECT Id, Numero FROM TBSerie";

        private const string sqlGetSerieById = @"SELECT Id, Numero FROM TBSerie WHERE Id = @Id";

        private const string sqlGetSerieByName = @"SELECT Id, Numero FROM TBSerie WHERE Numero = @Numero";

        private const string sqlUpdateSerie = @"UPDATE TBSerie SET Numero = @Numero WHERE Id = @Id";

        private const string sqlDeleteSerie = @"DELETE FROM TBSerie WHERE Id = @Id";

        private const string sqlGetSerieFromMateriaById = @"SELECT Id FROM TBMateria WHERE IdSerie = @Id";

        #endregion queries

        public SerieDAO()
        {

        }

        public Serie Adicionar(Serie serie)
        {
            DB.Add(sqlInsertSerie, GetParam(serie));

            return serie;
        }

        public Serie Atualizar(Serie serie)
        {
            DB.Update(sqlUpdateSerie, GetParam(serie));

            return serie;
        }

        public int Excluir(int disciplinaId)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("Id", disciplinaId);

            DB.Delete(sqlDeleteSerie, dic);

            return disciplinaId;
        }

        public IList<Serie> ObterTodosItens()
        {
            return DB.GetAll(sqlGetAllSerie, Converter);
        }

        public bool Existe(Serie serie)
        {
            if (DB.GetByName(sqlGetSerieByName, Converter, GetParam(serie)) == null)
                return false;
            else
                return true;
        }

        public bool ExisteEmMateria(Serie serie)
        {
            if (DB.GetById(sqlGetSerieFromMateriaById, ConverterMateria, GetParam(serie)) == null)
                return false;
            else
                return true;
        }

        private static Materia ConverterMateria(IDataReader _reader)
        {
            Materia materia = new Materia();
            materia.Id = Convert.ToInt32(_reader["Id"]);

            return materia;
        }

        private static Serie Converter(IDataReader _reader)
        {
            Serie serie = new Serie();
            serie.Id = Convert.ToInt32(_reader["Id"]);
            serie.NumeroSerie = Convert.ToInt32(_reader["Numero"]);

            return serie;
        }

        public Dictionary<string, object> GetParam(Serie serie)
        {
            var dic = new Dictionary<string, object>();
            dic.Add("Id", serie.Id);
            dic.Add("Numero", serie.NumeroSerie);

            return dic;
        }
    }
}

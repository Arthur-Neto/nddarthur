using Prova2.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Data;
using Prova2.Infra.DataBase;

namespace Prova2.Infra.Data
{
    public class LivroDAO
    {
        #region Scripts SQL

        /// <summary>
        /// Scripts para manipulação das tabelas do banco de dados
        /// </summary>
        public const string _sqlInsert = @"INSERT INTO LIVRO
                                                       (TITULO,
                                                        TEMA,
                                                        AUTOR,
                                                        VOLUME,
                                                        DATAPUBLICACAO,
                                                        DISPONIBILIDADE)
                                                  VALUES
                                                        ({0}TITULO,
                                                        {0}TEMA,
                                                        {0}AUTOR,
                                                        {0}VOLUME,
                                                        {0}DATAPUBLICACAO,
                                                        {0}DISPONIBILIDADE)";

        public const string _sqlSelectAll = @"SELECT ID
                                                    ,TITULO
                                                    ,TEMA
                                                    ,AUTOR
                                                    ,VOLUME
                                                    ,DATAPUBLICACAO
                                                    ,DISPONIBILIDADE
                                                 FROM LIVRO";

        public const string _sqlSelect = @"SELECT ID
                                                 ,TITULO
                                                 ,TEMA
                                                 ,AUTOR
                                                 ,VOLUME
                                                 ,DATAPUBLICACAO
                                                 ,DISPONIBILIDADE
                                                 FROM LIVRO
                                            WHERE ID = {0}ID";

        public const string _sqlUpdate = @"UPDATE LIVRO
                                                        SET TITULO = {0}TITULO
                                                           ,TEMA = {0}TEMA
                                                           ,AUTOR = {0}AUTOR
                                                           ,VOLUME = {0}VOLUME
                                                           ,DATAPUBLICACAO = {0}DATAPUBLICACAO
                                                           ,DISPONIBILIDADE = {0}DISPONIBILIDADE
                                             WHERE ID = {0}ID";

        public static string _sqlDelete = @"DELETE FROM LIVRO
                                             WHERE ID = {0}ID";

        #endregion Scripts SQL

        public LivroDAO()
        {
        }

        public Livro Add(Livro livro)
        {

            livro.Id = Db.Insert(_sqlInsert, Take(livro));

            return livro;

        }

       //public IQueryable<Livro> GetAll()
        public IList<Livro> GetAll()
        {
            return Db.GetAll(_sqlSelectAll, Make);

        }

        public Livro GetById(int livroId)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "ID", livroId } };

            return Db.Get(_sqlSelect, Make, parms);

        }

        public void Update(Livro livro)
        {
            Db.Update(_sqlUpdate, Take(livro));
        }

        public void Delete(int id)
        {

            var parms = new Dictionary<string, object> { { "ID", id } };

            Db.Delete(_sqlDelete, parms);

        }

        /// <summary>
        /// Cria a lista de parametros do objeto livro para passar para o comando Sql.
        /// </summary>
        /// <param name="livro">Objeto livro passado por parâmetro.</param>
        /// <returns>Lista de parâmetros.</returns>
        private Dictionary<string, object> Take(Livro livro)
        {
            return new Dictionary<string, object>
            {
                { "ID", livro.Id },
                { "TITULO", livro.Titulo },
                { "TEMA", livro.Tema},
                { "AUTOR", livro.Autor },
                { "VOLUME", livro.Volume},
                { "DATAPUBLICACAO", livro.DataPublicacao},
                { "DISPONIBILIDADE", livro.Disponibilidade }
            };
        }

        private static Func<IDataReader, Livro> Make = reader =>
          new Livro
          {
              Id = Convert.ToInt32(reader["ID"]),
              Titulo = Convert.ToString(reader["TITULO"]),
              Tema = Convert.ToString(reader["TEMA"]),
              Autor = Convert.ToString(reader["AUTOR"]),
              Volume = Convert.ToInt32(reader["VOLUME"]),
              DataPublicacao = Convert.ToDateTime(reader["DATAPUBLICACAO"]),
              Disponibilidade = Convert.ToBoolean(reader["DISPONIBILIDADE"])
          };
    }
}

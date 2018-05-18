using Prova2.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;
using MySql.Data.MySqlClient;
using Prova2.Infra.DataBase;

namespace Prova2.Infra.Data
{
    public class EmprestimoDAO
    {

        #region Scripts SQL

        /// <summary>
        /// Scripts para manipulação das tabelas do banco de dados
        /// </summary>
        public const string _sqlInsert = @"INSERT INTO EMPRESTIMO
                                                       (CLIENTE
                                                       ,DATADEVOLUCAO
                                                       ,IDLIVRO)
                                                   VALUES
                                                         ({0}CLIENTE,
                                                          {0}DATADEVOLUCAO,
                                                          {0}IDLIVRO)";

        public const string _sqlSelectAll = @"SELECT  E.ID 
                                                     ,E.CLIENTE 
                                                     ,E.DATADEVOLUCAO 
                                                     ,E.IDLIVRO 
                                                        ,L.TITULO 
                                                        ,L.TEMA 
                                                        ,L.AUTOR 
                                                        ,L.VOLUME 
                                                        ,L.DATAPUBLICACAO 
                                                        ,L.DISPONIBILIDADE 
                                            FROM EMPRESTIMO AS E 
                                            INNER JOIN LIVRO AS L 
                                            ON L.ID = E.IDLIVRO;";

        public const string _sqlSelect = @"SELECT  E.ID
                                                     ,E.CLIENTE
                                                     ,E.DATADEVOLUCAO
                                                     ,E.IDLIVRO
	                                                 ,L.TITULO
	                                                 ,L.TEMA
	                                                 ,L.CLIENTE
	                                                 ,L.VOLUME
	                                                 ,L.DATAPUBLICACAO
	                                                 ,L.DISPONIBILIDADE
                                               FROM EMPRESTIMO AS E
                                               INNER JOIN LIVRO AS L
                                               ON L.ID = E.IDLIVRO
                                           WHERE E.ID = {0}ID";

        public const string _sqlUpdate = @"UPDATE EMPRESTIMO
                                                   SET CLIENTE = {0}CLIENTE
                                                      ,DATADEVOLUCAO = {0}DATADEVOLUCAO
                                                      ,IDLIVRO = {0}IDLIVRO
                                                    WHERE ID = {0}ID";

        public static string _sqlDelete = @"DELETE FROM EMPRESTIMO
                                                    WHERE ID = {0}ID";

        #endregion Scripts SQL

        public EmprestimoDAO()

        {

        }

        public Emprestimo Add(Emprestimo emprestimo)
        {

            emprestimo.Id = Db.Insert(_sqlInsert, Take2(emprestimo));

            return emprestimo;

        }

        public void Update(Emprestimo emprestimo)
        {
            Db.Update(_sqlUpdate, Take2(emprestimo));
        }

        //public IQueryable<Emprestimo> GetAll()
        public IList<Emprestimo> GetAll()
        {
            return Db.GetAll(_sqlSelectAll, Make);
        }

        public Emprestimo GetById(int emprestimoId)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "ID", emprestimoId } };

            return Db.Get(_sqlSelect, Make, parms);
        }

        public void Delete(int id)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "ID", id } };

            Db.Delete(_sqlDelete, parms);
        }

        /// <summary>
        /// Cria a lista de parametros do objeto emprestimo para passar para o comando Sql.
        /// </summary>
        /// <param name="product">Objeto emprestimo passado por parâmetro.</param>
        /// <returns>Lista de parâmetros.</returns>
        private Dictionary<string, object> Take2(Emprestimo emprestimo)
        {
            return new Dictionary<string, object>
            {
                { "ID", emprestimo.Id },
                { "CLIENTE", emprestimo.Cliente },
                { "DATADEVOLUCAO", emprestimo.DataDevolucao },
                { "IDLIVRO", emprestimo.Livro.Id }
            };
        }

        /// <summary>
        /// Método que cria um objeto Emprestimo baseado no DataReader.
        /// </summary>
        /// <param name="reader">Interface que implementa os métodos de leitura de dados.</param>
        /// <returns>Retorna o objeto.</returns>
        private Emprestimo Make(IDataReader reader)
        {
            Emprestimo emprestimo = new Emprestimo();

            emprestimo.Id = Convert.ToInt32(reader["ID"]);
            emprestimo.Cliente = Convert.ToString(reader["CLIENTE"]);
            emprestimo.DataDevolucao = Convert.ToDateTime(reader["DATADEVOLUCAO"]);
            emprestimo.Livro.Id = Convert.ToInt32(reader["IDLIVRO"]);
            emprestimo.Livro.Titulo = Convert.ToString(reader["TITULO"]);
            emprestimo.Livro.Tema = Convert.ToString(reader["TEMA"]);
            emprestimo.Livro.Autor = Convert.ToString(reader["AUTOR"]);
            emprestimo.Livro.Volume = Convert.ToInt32(reader["VOLUME"]);
            emprestimo.Livro.DataPublicacao = Convert.ToDateTime(reader["DATAPUBLICACAO"]);
            emprestimo.Livro.Disponibilidade = Convert.ToBoolean(reader["DISPONIBILIDADE"]);

            return emprestimo;
        }
    }
}


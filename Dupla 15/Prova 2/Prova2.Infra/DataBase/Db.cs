using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova2.Infra.DataBase
{
   public static class Db
    {
        #region Attributes

        /// <summary>
        /// Propriedade de configurações (AppSettings)
        /// </summary>
        private static readonly string _connectionStringName = ConfigurationManager.AppSettings.Get("ConnectionStringName"); //Busca na tag appSettings em App.config a chave ConnectionStringName
        private static readonly string _providerName = ConfigurationManager.AppSettings.Get("DataProvider"); //Busca na tag appSettings em App.config a chave DataProvider

        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings[_connectionStringName].ConnectionString; //Busca a connection string no arquivo App.config
        private static readonly DbProviderFactory _factory = DbProviderFactories.GetFactory(_providerName); //Pega a factory lendo o providerName que está configurado no App.config

        #endregion Attributes

        #region Properties

        /// <summary>
        /// Define o prefixo do parametro pelo seu provider
        /// </summary>
        public static string ParameterPrefix
        {
            get
            {
                switch (_providerName)
                {
                    // Microsoft Access não tem suporte a esse tipo de comando
                    case "System.Data.OleDb": return "@";
                    case "System.Data.SqlClient": return "@";
                    case "System.Data.OracleClient": return ":";
                    case "MySql.Data.MySqlClient": return "?";

                    default:
                        return "@";
                }
            }
        }

        #endregion Properties

        public static int Insert(string sql, Dictionary<string, object> parms = null, bool identitySelect = true)
        {
            sql = string.Format(sql, ParameterPrefix);

            using (var connection = _factory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;

                using (var command = _factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.SetParameters(parms); // Extension method
                    command.CommandText = identitySelect ? sql.AppendIdentitySelect() : sql; // Extension method

                    connection.Open();

                    int id = 0;

                    if (identitySelect)
                        id = Convert.ToInt32(command.ExecuteScalar());
                    else
                        command.ExecuteNonQuery();

                    return id;
                }
            }
        }

        public static void Update(string sql, Dictionary<string, object> parms = null)
        {
            sql = string.Format(sql, ParameterPrefix);

            using (var connection = _factory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;

                using (var command = _factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.SetParameters(parms); //Extesion Method

                    connection.Open();

                    command.ExecuteNonQuery();

                    command.Parameters.Clear();
                }
            }
        }

        public static void Delete(string sql, Dictionary<string, object> parms = null)
        {
            Update(sql, parms);
        }

        public static IList<T> GetAll<T>(string sql, Func<IDataReader, T> Make, Dictionary<string, object> parms = null)
        {
            using (var connection = _factory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;

                using (var command = _factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.SetParameters(parms); //Extesion Method

                    connection.Open();

                    var list = new List<T>();
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var obj = Make(reader);
                        list.Add(obj);
                    }

                    command.Parameters.Clear();

                    return list;
                }
            }
        }

        public static T Get<T>(string sql, Func<IDataReader, T> Make, Dictionary<string, object> parms = null)
        {
            sql = string.Format(sql, ParameterPrefix);

            using (var connection = _factory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;

                using (var command = _factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.SetParameters(parms); //Extesion Method

                    connection.Open();

                    T t = default(T);

                    var reader = command.ExecuteReader();

                    if (reader.Read())
                        t = Make(reader);

                    command.Parameters.Clear();

                    return t;
                }
            }
        }

        #region Private methods

        /// <summary>
        /// Métode de extensão da classe DbCommand que seta os parametros adicionando o seus respectivos prefixos.
        /// </summary>
        /// <param name="command">Classe command que o método utilizará para adcionar os parametros.</param>
        /// <param name="parms">Parametros do script.</param>
        private static void SetParameters(this DbCommand command, Dictionary<string, object> parms)
        {
            if (parms != null)
            {
                foreach (var item in parms)
                {
                    var dbParameter = command.CreateParameter();
                    dbParameter.ParameterName = item.Key;
                    dbParameter.Value = item.Value;

                    command.Parameters.Add(dbParameter);
                }

            }
        }

        /// <summary>
        /// Concatena no script de inserção o select do id
        /// </summary>
        /// <param name="sql">Script de Insert</param>
        /// <returns></returns>
        private static string AppendIdentitySelect(this string sql)
        {
            switch (_providerName)
            {
                // Microsoft Access não tem suporte a esse tipo de comando
                case "System.Data.OleDb": return sql;
                case "System.Data.SqlClient": return sql + ";SELECT SCOPE_IDENTITY()";
                case "System.Data.OracleClient": return sql + ";SELECT MySequence.NEXTVAL FROM DUAL";
                case "Firebird.Data.FbClient": return sql + ";GENERATOR(x=>x.identity)";
                default: return sql + ";SELECT @@IDENTITY";
            }
        }

        #endregion Private methods
    }

}

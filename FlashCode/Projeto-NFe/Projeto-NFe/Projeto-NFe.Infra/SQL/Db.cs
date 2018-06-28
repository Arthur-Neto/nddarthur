using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.SQL
{
    [ExcludeFromCodeCoverage]
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

        /// <summary>
        /// Método genérico para inserção
        /// <param name="sql">Script SQL de Insert na tabela.</param>
        /// <param name="parms">Array de parametros que serão adicionados no Insert. O seu valor está null por padrão.</param>
        /// <param name="identitySelect">Marcação que define se precisa que retorne o id do item adicionado. O seu valor está true por padrão.</param>
        /// <returns>Retorna o id selecionado ou 0.</returns>
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

        /// <summary>
        ///  Método genérico para update
        /// </summary>
        /// <param name="sql">Script SQL de Update na tabela.</param>
        /// <param name="parms">Array de parametros que serão adicionados no Insert. O seu valor está null por padrão.</param>
        public static int Update(string sql, Dictionary<string, object> parms = null)
        {
            sql = string.Format(sql, ParameterPrefix);
            int updated;
            using (var connection = _factory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;

                using (var command = _factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.SetParameters(parms); //Extesion Method

                    connection.Open();

                    updated = command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
            }
            return updated;
        }
        
        /// <summary>
        /// Método genérico para delete
        /// </summary>
        /// <param name="sql">Script SQL de Update na tabela.</param>
        /// <param name="parms">Array de parametros que serão adicionados no Insert. O seu valor está null por padrão.</param>
        public static int Delete(string sql, Dictionary<string, object> parms = null)
        {
            return Update(sql, parms);
        }

        /// <summary>
        /// Método genérico para select
        /// </summary>
        /// <param name="sql">Script SQL de SELECT na tabela.</param
        /// <param name="make">Delegate que interpreta e atribui os valores da consulta para o objeto.</param>
        /// <param name="parms">Array de parametros que serão adicionados no Insert. O seu valor está null por padrão.</param>
        public static List<T> GetAll<T>(string sql, Func<IDataReader, T> Make, Dictionary<string, object> parms = null)
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

        /// <summary>
        /// Método genérico para select
        /// </summary>
        /// <param name="sql">Script SQL de SELECT na tabela.</param
        /// <param name="make">Delegate que interpreta e atribui os valores da consulta para o objeto.</param>
        /// <param name="parms">Array de parametros que serão adicionados no Insert. O seu valor está null por padrão.</param>
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

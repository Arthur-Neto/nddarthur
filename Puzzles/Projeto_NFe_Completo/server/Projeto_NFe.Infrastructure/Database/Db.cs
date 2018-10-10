using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Database
{
    public static class Db
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["NFe_DBTESTCONTEXT"].ConnectionString;

        private static string _providerName = ConfigurationManager.AppSettings.Get("DataProvider");

        private static DbProviderFactory _providerType = DbProviderFactories.GetFactory(_providerName);

        public static long Adicionar(string sql, Dictionary<string, object> dictionary)
        {
            return ExecutarCommandoSql(sql, dictionary);
        }

        public static long Atualizar(string sql, Dictionary<string, object> dictionary = null)
        {
            return ExecutarCommandoSql(sql, dictionary);
        }

        public static void Excluir(string sql, Dictionary<string, object> dictionary)
        {
            ExecutarCommandoSql(sql, dictionary);
        }

        public static IEnumerable<T> BuscarListaPorId<T>(String sql, Func<IDataReader, T> convertRelactionalData, Dictionary<string, object> dictionary)
        {
            sql = string.Format(sql, AlterarPrefixoPorTipoDeProvedor);
            using (DbConnection connection = _providerType.CreateConnection())
            {
                connection.ConnectionString = _connectionString;

                using (DbCommand command = _providerType.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    DefinirParametrosParaOComandoSql(command, dictionary);
                    connection.Open();

                    var reader = command.ExecuteReader();

                    var list = new List<T>();

                    while (reader.Read())
                    {
                        var obj = convertRelactionalData(reader);
                        list.Add(obj);
                    }
                    return list;
                }
            }
        }

        public static T BuscarPorId<T>(String sql, Func<IDataReader, T> convertRelactionalData, Dictionary<string, object> dictionary)
        {
            sql = string.Format(sql, AlterarPrefixoPorTipoDeProvedor);
            using (DbConnection connection = _providerType.CreateConnection())
            {
                connection.ConnectionString = _connectionString;

                using (DbCommand command = _providerType.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    DefinirParametrosParaOComandoSql(command, dictionary);
                    connection.Open();


                    T t = default(T);
                    IDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                        t = convertRelactionalData(reader);
                    
                    return t;
                }
            }
        }

        //ok
        public static IEnumerable<T> BuscarTodos<T>(String sql, Func<IDataReader, T> convertRelactionalData)
        {
            using (DbConnection connection = _providerType.CreateConnection())
            {
                connection.ConnectionString = _connectionString;

                using (DbCommand command = _providerType.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    connection.Open();

                    var reader = command.ExecuteReader();

                    var list = new List<T>();

                    while (reader.Read())
                    {
                        var obj = convertRelactionalData(reader);
                        list.Add(obj);
                    }
                    return list;
                }
            }
        }
        public static void DefinirParametrosParaOComandoSql(DbCommand command, Dictionary<string, object> dictionary)
        {
            if (dictionary != null)
            {
                foreach (var item in dictionary)
                {
                    var dbParameter = command.CreateParameter();
                    dbParameter.ParameterName = item.Key;
                    dbParameter.Value = item.Value;
                    command.Parameters.Add(dbParameter);
                }
            }
        }


        // Connection AND execute SQL
        public static long ExecutarCommandoSql(string sql, Dictionary<string, object> parms = null)
        {
            sql = string.Format(sql, AlterarPrefixoPorTipoDeProvedor);
            long idAux;
            using (DbConnection connection = _providerType.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                using (DbCommand command = _providerType.CreateCommand())
                {

                    command.Connection = connection;
                    command.CommandText = sql;
                    DefinirParametrosParaOComandoSql(command, parms);
                    connection.Open();

                    idAux = Convert.ToInt64(command.ExecuteScalar());
                }
            }
            return idAux;
        }

        public static string AlterarPrefixoPorTipoDeProvedor
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
    }
}

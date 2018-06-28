using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorTestes.Infra.Database
{
    public static class Db
    {
        private static readonly string _connectionStringName = ConfigurationManager.AppSettings.Get("ConnectionStringName");
        private static readonly string _providerName = ConfigurationManager.AppSettings.Get("DataProvider");

        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings[_connectionStringName].ConnectionString;
        private static readonly DbProviderFactory _factory = DbProviderFactories.GetFactory(_providerName);

        public static string ParameterPrefix
        {
            get
            {
                switch (_providerName)
                {
                    case "System.Data.OleDb": return "@";
                    case "System.Data.SqlClient": return "@";
                    case "System.Data.OracleClient": return ":";
                    case "MySql.Data.MySqlClient": return "?";

                    default:
                        return "@";
                }
            }
        }

        public static int Insert(string sql, Dictionary<string, object> parms = null, bool identitySelect = true)
        {
            sql = string.Format(sql, ParameterPrefix);

            using (var connection = _factory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;

                using (var command = _factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.SetParameters(parms);
                    command.CommandText = identitySelect ? sql.AppendIdentitySelect() : sql;

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
                    command.SetParameters(parms);

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
            if (parms != null)
                sql = string.Format(sql, ParameterPrefix);

            using (var connection = _factory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;

                using (var command = _factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.SetParameters(parms);

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
                    command.SetParameters(parms);

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

        private static string AppendIdentitySelect(this string sql)
        {
            switch (_providerName)
            {
                case "System.Data.OleDb": return sql;
                case "System.Data.SqlClient": return sql + ";SELECT SCOPE_IDENTITY()";
                case "System.Data.OracleClient": return sql + ";SELECT MySequence.NEXTVAL FROM DUAL";
                case "Firebird.Data.FbClient": return sql + ";GENERATOR(x=>x.identity)";
                default: return sql + ";SELECT @@IDENTITY";
            }
        }
    }
}

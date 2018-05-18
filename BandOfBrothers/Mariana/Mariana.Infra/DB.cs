using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mariana.Infra
{
    //public delegate T Func<T>(IDataReader reader);

    public class DB
    {
        private static readonly string connectionStringName = ConfigurationManager.AppSettings.Get("connectionDB");

        private static readonly string providerName = ConfigurationManager.ConnectionStrings[connectionStringName].ProviderName;

        private static readonly string connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;

        private static readonly DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);

        public DB()
        {
        }

        public static Dictionary<string, object> Add(string sql, Dictionary<string, object> parms)
        {
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (DbCommand _command = factory.CreateCommand())
                {
                    _command.Connection = connection;
                    SetParameters(_command, parms);
                    sql = AppendIdentitySelect(sql);
                    _command.CommandText = sql;

                    connection.Open();

                    _command.ExecuteScalar();

                    return parms;
                }
            }
        }

        public static T GetById<T>(string sql, Func<IDataReader, T> convert, Dictionary<string, object> parms)
        {
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (var command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    SetParameters(command, parms);

                    connection.Open();

                    T t = default(T);

                    var reader = command.ExecuteReader();

                    if (reader.Read())
                        t = convert(reader);

                    return t;
                }
            }
        }

        public static IList<T> GetAllById<T>(string sql, Func<IDataReader, T> convert, Dictionary<string, object> parms)
        {
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (var command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    SetParameters(command, parms);

                    connection.Open();

                    var list = new List<T>();
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var obj = convert(reader);
                        list.Add(obj);
                    }

                    return list;
                }
            }
        }

        public static IList<T> GetAll<T>(string sql, Func<IDataReader, T> convert, Dictionary<string, object> parms = null)
        {
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (var command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    SetParameters(command, parms);

                    try
                    {
                        connection.Open();

                        var list = new List<T>();
                        var reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            var obj = convert(reader);
                            list.Add(obj);
                        }

                        return list;
                    }
                    catch(Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    
                }
            }
        }

        public static void Update(string sql, Dictionary<string, object> parms)
        {
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (var command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    SetParameters(command, parms);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(string sql, Dictionary<string, object> parms)
        {
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (var command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    sql = AppendIdentitySelect(sql);
                    SetParameters(command, parms);

                    command.CommandText = sql;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public static T GetByName<T>(string sql, Func<IDataReader, T> convert, Dictionary<string, object> parms)
        {
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (var command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    SetParameters(command, parms);

                    connection.Open();

                    T t = default(T);

                    var reader = command.ExecuteReader();

                    if (reader.Read())
                        t = convert(reader);

                    return t;
                }
            }
        }

        public static void SetParameters(DbCommand command, Dictionary<string, object> parms)
        {
            if (parms != null && parms.Count > 0)
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

        public static string AppendIdentitySelect(string sql)
        {
            switch (providerName)
            {
                // Microsoft Access não tem suporte a esse tipo de comando
                case "System.Data.SqlClient": return sql + ";SELECT SCOPE_IDENTITY();";
                case "MySql.Data.MySqlClient": return sql;
                default: return sql + ";SELECT @@IDENTITY;";
            }
        }

    }
}

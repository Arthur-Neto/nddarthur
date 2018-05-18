using System.Collections.Generic;
using System.Data;

namespace Mariana.Infra.Data.SQL
{
    public static class SQLMetodosExtensao
    {
        public static void AdicionarParametros(this IDbCommand command, Dictionary<string, object> parameters)
        {
            if (parameters == null)
                return;

            foreach (KeyValuePair<string, object> entry in parameters)
            {
                var parameter = command.CreateParameter();
                parameter.ParameterName = entry.Key;
                parameter.Value = entry.Value;

                command.Parameters.Add(parameter);
            }
        }

        public static string FormatarSQL(this string query, TipoRepositorio type, bool loadId = false)
        {
            query = query.DefinirApelido(type);
            query = (loadId ? query.AcrescentarConsultaId(type) : query);

            return query;
        }

        private static string DefinirApelido(this string query, TipoRepositorio type)
        {
            return string.Format(query, TipoRepositorioUtil.ObterApelido(type));
        }

        private static string AcrescentarConsultaId(this string query, TipoRepositorio type)
        {
            switch (type)
            {
                case TipoRepositorio.MY_SQL:
                    return query + ";SELECT @@IDENTITY";
                case TipoRepositorio.SQL_SERVER:
                    return query + ";SELECT SCOPE_IDENTITY()";
            }

            return query;
        }

    }
}

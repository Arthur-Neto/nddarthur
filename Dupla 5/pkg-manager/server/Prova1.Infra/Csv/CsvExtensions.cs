using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Prova1.Infra.Csv
{
    /// <summary>
    ///  Classe que utiliza Reflection para serializar dados em CSV
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class CsvExtensions
    {
        public static string ToCsv<T>(this IQueryable objectlist, string separator)
        {
            var properties = typeof(T).GetProperties();

            var data = new StringBuilder();
            data.AppendLine(GetHeader(separator, properties));

            foreach (var obj in objectlist)
            {
                data.AppendLine(ToCsvFields(separator, properties, obj));
            }

            return data.ToString();
        }

        private static string GetHeader(string separator, PropertyInfo[] properties)
        {
            var header = new StringBuilder();

            foreach (var p in properties)
            {
                if (header.Length > 0)
                    header.Append(separator);

                if (p.PropertyType.FullName != "System.String" && p.PropertyType.FullName != "System.DateTime" && !p.PropertyType.IsPrimitive)
                {
                    header.Append(GetHeader(separator, p.PropertyType.GetProperties()));
                }
                else
                {
                    header.Append(p.Name);
                }
            }

            return header.ToString();
        }

        private static string ToCsvFields(string separator, PropertyInfo[] properties, object obj)
        {
            var line = new StringBuilder();

            foreach (var p in properties)
            {
                if (line.Length > 0)
                    line.Append(separator);

                if (p.PropertyType.FullName != "System.String" && p.PropertyType.FullName != "System.DateTime" && !p.PropertyType.IsPrimitive)
                {
                    var nestedObject = p.GetValue(obj);
                    line.Append(ToCsvFields(separator, p.PropertyType.GetProperties(), nestedObject));
                }
                else
                {
                    var value = p.GetValue(obj, null);

                    line.Append(value != null ? value.ToString() : "-");
                }
            }

            return line.ToString();
        }
    }
}

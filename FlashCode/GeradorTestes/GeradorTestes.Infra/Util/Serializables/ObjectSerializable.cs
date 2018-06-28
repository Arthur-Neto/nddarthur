using CsvHelper;
using GeradorTestes.Domain;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace GeradorTestes.Infra.Util.Serializables
{
    public static class ObjectSerializable
    {
        public static string SerializeCSV<T>(this Teste teste, string caminho) where T : Entidade
        {
            using (StreamWriter writer = new StreamWriter(caminho, true, Encoding.UTF8))
            {
                CsvWriter csvWriter = new CsvWriter(writer);
                csvWriter.Configuration.Delimiter = ";";
                csvWriter.WriteRecords(teste.listaQuestao);


            }
            return teste.ToString();
        }
        public static IList<T> SerializeXML<T>(this IList<T> obj, string caminho) where T : Entidade
        {
            using (StreamWriter streamWriter = new StreamWriter(caminho, true, Encoding.UTF8))
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(streamWriter))
                {
                    XmlSerializer serializer = new XmlSerializer(obj.GetType());
                    serializer.Serialize(xmlWriter, obj);
                }
            }

            return obj;
        }

        public static T DeserializeCSV<T>(this T objs) where T : Entidade
        {
            using (var reader = new StreamReader(@"Teste.csv"))
            {
                var csvReader = new CsvReader(reader);
                return csvReader.GetRecord<T>();
            }
        }
        public static T DeserializeXML<T>(this string obj) where T : Entidade
        {
            using (XmlReader reader = XmlReader.Create(new StringReader(obj)))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Teste));

                return (T)serializer.Deserialize(reader);
            }
        }
    }
}

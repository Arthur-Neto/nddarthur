using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projeto_NFe.Infrastructure.XML.Serializador
{
    public static class XMLHelper
    {
        public static string Serializar<T>(T objeto)
        {
            string xml = "";
            XmlSerializer xmlSerializer = new XmlSerializer(objeto.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, objeto);
                xml = textWriter.ToString();
            }

            return xml;
        }

        public static void SerializarParaAquivo<T>(T objeto, string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(objeto.GetType());

            using (FileStream fs = new FileStream(path, FileMode.CreateNew))
            {
                xmlSerializer.Serialize(fs, objeto);
            }
        }

    }
}

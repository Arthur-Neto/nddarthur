using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace NFe.Infra.Utils
{
    [ExcludeFromCodeCoverage]
    public static class SerializeHelper
    {
        private static string RemoveNamespaceAndEncodingFromXml(string xml)
        {
            string namespacePattern = @"(xsi:?[^=]*:[""][^""]*[""])|(xmlns:?[^=]*:[""][^""]*[""])|(xmlns:?[^=]*=[""][^""]*[""])|(xmlns:?[^=]*=[''][^""]*[''])|(xsi:schemaLocation:?[^=]*=[""][^""]*[""])";
            return Regex.Replace(xml.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", ""), namespacePattern, string.Empty);
        }

        public static string Serialize(object objToSerial, bool RemoveNamespacesAndCodification = false)
        {
            int charToRemove = 65279;
            XmlSerializer serializer = new XmlSerializer(objToSerial.GetType());
            XmlWriterSettings set = new XmlWriterSettings();

            set.Encoding = Encoding.UTF8;
            set.Indent = true;
            MemoryStream ms = new MemoryStream();
            using (XmlWriter writer = XmlWriter.Create(ms, set))
                serializer.Serialize(writer, objToSerial);
            string xml = Encoding.UTF8.GetString(ms.ToArray());
            ms = null;
            xml = xml.Replace(Convert.ToChar(charToRemove).ToString(), string.Empty);


            if (RemoveNamespacesAndCodification)
                xml = RemoveNamespaceAndEncodingFromXml(xml);

            return xml;
        }

        public static string SerializeWithSimplifiedNamespace(object objToSerial)
        {
            XmlSerializerNamespaces myNamespaces = new XmlSerializerNamespaces();
            myNamespaces.Add("", "");

            int charToRemove = 65279;
            XmlSerializer serializer = new XmlSerializer(objToSerial.GetType());
            XmlWriterSettings set = new XmlWriterSettings();
            set.Encoding = Encoding.UTF8;
            set.Indent = true;
            StringWriter sw = new StringWriter();
            serializer.Serialize(new NoTypeAttributeXmlWriter(sw), objToSerial, myNamespaces);
            string xml = sw.ToString();

            xml = xml.Replace(Convert.ToChar(charToRemove).ToString(), string.Empty);
            xml = xml.Replace("q1:", string.Empty);
            xml = xml.Replace(":q1", string.Empty);
            return xml;
        }

        public static string SerializeWithoutXmlReader(object objToSerial)
        {
            int charToRemove = 65279;
            XmlSerializer serializer = new XmlSerializer(objToSerial.GetType());
            XmlWriterSettings set = new XmlWriterSettings();
            set.OmitXmlDeclaration = true;

            set.Encoding = Encoding.UTF8;
            set.Indent = true;
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            MemoryStream ms = new MemoryStream();
            using (XmlWriter writer = XmlWriter.Create(ms, set))
                serializer.Serialize(writer, objToSerial, ns);
            string xml = Encoding.UTF8.GetString(ms.ToArray());
            ms = null;
            xml = xml.Replace(Convert.ToChar(charToRemove).ToString(), string.Empty);
            return xml;
        }

        public static string SerializeWithoutNamespace(object objToSerial)
        {
            XmlSerializerNamespaces myNamespaces = new XmlSerializerNamespaces();
            myNamespaces.Add("", "");

            int charToRemove = 65279;
            XmlSerializer serializer = new XmlSerializer(objToSerial.GetType());
            XmlWriterSettings set = new XmlWriterSettings();
            set.Encoding = Encoding.UTF8;
            set.Indent = true;
            StringWriter sw = new StringWriter();
            serializer.Serialize(new NoTypeAttributeXmlWriter(sw), objToSerial, myNamespaces);
            string xml = sw.ToString();

            xml = xml.Replace(Convert.ToChar(charToRemove).ToString(), string.Empty);
            return xml;
        }

        public static T Deserialize<T>(string xml)
        {
            if (!String.IsNullOrEmpty(xml))
            {
                if (false == xml.StartsWith("<"))
                {
                    int pos = xml.IndexOf('<');
                    xml = xml.Remove(0, pos);
                }

                xml = xml.Replace(">True<", ">true<").Replace(">False<", ">false<");
                xml = xml.Replace("\"True\"", "\"true\"").Replace("\"False\"", "\"false\"");

                XmlSerializer serializer = new XmlSerializer(typeof(T));
                XmlReaderSettings set = new XmlReaderSettings();
                set.ValidationFlags = XmlSchemaValidationFlags.AllowXmlAttributes;
                using (XmlReader reader = XmlReader.Create(new StringReader(xml), set))
                    return (T)serializer.Deserialize(reader);
            }

            return default(T);
        }
    }
}
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Xml;

namespace NFe.Infra.Utils
{
    [ExcludeFromCodeCoverage]
    public class NoTypeAttributeXmlWriter : XmlTextWriter
    {
        public NoTypeAttributeXmlWriter(TextWriter w)
            : base(w) { }

        public NoTypeAttributeXmlWriter(Stream w, Encoding encoding)
            : base(w, encoding) { }

        public NoTypeAttributeXmlWriter(string filename, Encoding encoding)
            : base(filename, encoding) { }

        bool skip;

        public override void WriteStartAttribute(string prefix, string localName, string ns)
        {
            if (ns == "http://www.w3.org/2001/XMLSchema-instance" && localName == "type")
            {
                skip = true;
            }
            else
            {
                base.WriteStartAttribute(prefix, localName, ns);
            }
        }

        public override void WriteString(string text)
        {
            if (!skip) base.WriteString(text);
        }

        public override void WriteEndAttribute()
        {
            if (!skip) base.WriteEndAttribute();
            skip = false;
        }
    }
}

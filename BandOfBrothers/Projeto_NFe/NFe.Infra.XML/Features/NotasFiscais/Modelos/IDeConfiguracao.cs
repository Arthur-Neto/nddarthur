using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NFe.Infra.XML.Features.NotasFiscais.Modelos
{
    [ExcludeFromCodeCoverage]
    public class IdeConfiguracao
    {
        [XmlElement(ElementName = "natOp")]
        public string NaturezaOperacao { get; set; }

        [XmlElement(ElementName = "dhEmi")]
        public DateTime DataEmissao { get; set; }
    }
}

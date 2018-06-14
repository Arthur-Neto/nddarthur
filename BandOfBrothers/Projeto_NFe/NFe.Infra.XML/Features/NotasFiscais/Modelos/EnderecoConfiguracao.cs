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
    public class EnderDestConfiguracao
    {
        [XmlElement(ElementName = "xLgr")]
        public string Logradouro { get; set; }

        [XmlElement(ElementName = "nro")]
        public string Numero { get; set; }

        [XmlElement(ElementName = "xBairro")]
        public string Bairro { get; set; }

        [XmlElement(ElementName = "xMun")]
        public string Municipio { get; set; }

        [XmlElement(ElementName = "UF")]
        public string Estado { get; set; }

        [XmlElement(ElementName = "xPais")]
        public string Pais { get; set; }
    }
}

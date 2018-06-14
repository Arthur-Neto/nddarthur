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
    public class TransportadorConfiguracao
    {
        public TransportadorConfiguracao()
        {
            Transporta = new TransportaConfiguracao();
        }

        [XmlElement(ElementName = "modFrete")]
        public int modFrete { get; set; }

        [XmlElement(ElementName = "transporta")]
        public TransportaConfiguracao Transporta { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TransportaConfiguracao
    {
        public TransportaConfiguracao()
        {
        }

        [XmlElement(ElementName = "CNPJ")]
        public string CnpjDestinatario { get; set; }

        [XmlElement(ElementName = "xNome")]
        public string Nome { get; set; }

        [XmlElement(ElementName = "IE")]
        public string InscricaoEstadual { get; set; }

        [XmlElement(ElementName = "xEnder")]
        public string Logradouro { get; set; }

        [XmlElement(ElementName = "xMun")]
        public string Municipio { get; set; }

        [XmlElement(ElementName = "UF")]
        public string Estado { get; set; }
    }
}

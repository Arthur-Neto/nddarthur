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
    public class DestinatarioConfiguracao
    {
        public DestinatarioConfiguracao()
        {
            enderDest = new EnderDestConfiguracao();
        }

        [XmlElement(ElementName = "CNPJ")]
        public string CnpjDestinatario { get; set; }

        [XmlElement(ElementName = "CPF")]
        public string CpfDestinatario { get; set; }

        [XmlElement(ElementName = "xNome")]
        public string Nome { get; set; }

        [XmlElement(ElementName = "indIEDest")]
        public string InscricaoEstadual { get; set; }

        [XmlElement(ElementName = "enderDest")]
        public EnderDestConfiguracao enderDest { get; set; }
    }
}

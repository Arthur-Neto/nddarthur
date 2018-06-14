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
    public class EmitenteConfiguracao
    {
        public EmitenteConfiguracao()
        {
            enderDest = new EnderDestConfiguracao();
        }

        [XmlElement(ElementName = "CNPJ")]
        public string CnpjEmitente { get; set; }

        [XmlElement(ElementName = "xNome")]
        public string RazaoSocial { get; set; }

        [XmlElement(ElementName = "xFant")]
        public string Nome { get; set; }

        [XmlElement(ElementName = "IE")]
        public string InscricaoEstadual { get; set; }

        [XmlElement(ElementName = "IM")]
        public string InscricaoMunicipal { get; set; }

        [XmlElement(ElementName = "enderEmit")]
        public EnderDestConfiguracao enderDest { get; set; }
    }
}

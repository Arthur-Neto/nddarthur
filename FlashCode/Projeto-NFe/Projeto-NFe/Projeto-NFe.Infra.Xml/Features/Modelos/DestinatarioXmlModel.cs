using System.Xml.Serialization;

namespace Projeto_NFe.Infra.Xml.Features.Modelos
{
    public class DestinatarioXmlModel
    {
        public DestinatarioXmlModel()
        {

        }
        [XmlElement]
        public string Cnpj { get; set; }
        [XmlElement]
        public string Cpf { get; set; }
        [XmlElement(ElementName = "xNome")]
        public string XNome { get; set; }
        [XmlElement(ElementName = "xFant")]
        public string XFant { get; set; }
        [XmlElement(ElementName = "indIEDest")]
        public string IE { get; set; }
        [XmlElement(ElementName = "enderDest")]
        public EnderecoXmlModel EnderDest { get; set; }
    }
}
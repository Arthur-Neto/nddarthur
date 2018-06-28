using System.Xml.Serialization;

namespace Projeto_NFe.Infra.Xml.Features.Modelos
{
    public class ImpostoXmlModel
    {
        public ImpostoXmlModel() { }
        [XmlElement(ElementName = "pICMS")]
        public string PICMS { get; set; }
        [XmlElement(ElementName = "vICMS")]
        public string VICMS { get; set; }
    }
}
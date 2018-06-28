using System.Xml.Serialization;

namespace Projeto_NFe.Infra.Xml.Features.Modelos
{
    public class ProdutoXmlModel
    {
        public ProdutoXmlModel() { }
        [XmlElement(ElementName = "cProd")]
        public string CProd { get; set; }
        [XmlElement(ElementName = "xProd")]
        public string xProd { get; set; }
        [XmlElement(ElementName = "qCom")]
        public string QCom { get; set; }
        [XmlElement(ElementName = "vUnCom")]
        public string VUnCom { get; set; }
        [XmlElement(ElementName = "vProd")]
        public string VProd { get; set; }
    }
}
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Projeto_NFe.Infra.Xml.Features.Modelos
{
    public class DetXmlModel
    {
        public DetXmlModel() { }
        [XmlAttribute]
        public int Id { get; set; }
        [XmlElement(ElementName = "prod")]
        public ProdutoXmlModel Prod { get; set; }
        [XmlElement(ElementName = "imposto")]
        public ImpostoXmlModel Imposto { get; set; }
    }
}
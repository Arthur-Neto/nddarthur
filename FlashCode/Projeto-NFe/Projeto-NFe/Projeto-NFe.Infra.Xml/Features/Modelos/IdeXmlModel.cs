using System.Xml.Serialization;

namespace Projeto_NFe.Infra.Xml.Features.Modelos
{
    public class IdeXmlModel
    {
        public IdeXmlModel() { }
        [XmlElement]
        public string natOp { get; set; }
        [XmlElement]
        public string dhEmi { get; set; }
    }
}
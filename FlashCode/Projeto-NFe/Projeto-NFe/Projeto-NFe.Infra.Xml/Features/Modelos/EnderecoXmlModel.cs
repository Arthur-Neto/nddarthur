using System.Xml.Serialization;

namespace Projeto_NFe.Infra.Xml.Features.Modelos
{
    public class EnderecoXmlModel
    {
        public EnderecoXmlModel() { }
        [XmlElement]
        public string xLgr { get; set; }
        [XmlElement]
        public string nro { get; set; }
        [XmlElement]
        public string xBairro { get; set; }
        [XmlElement]
        public string xMun { get; set; }
        [XmlElement]
        public string UF { get; set; }
        [XmlElement]
        public string xPais { get; set; }
    }
}
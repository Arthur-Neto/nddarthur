using Projeto_NFe.Dominio.Base;
using Projeto_NFe.Infra.Documentos.Features.Cnpjs;
using Projeto_NFe.Infra.Documentos.Features.Cpfs;
using System.Xml.Serialization;

namespace Projeto_NFe.Infra.Xml.Features.Modelos
{
    public class TransportadorXmlModel
    {
        public TransportadorXmlModel() { }
        [XmlElement(ElementName ="xFant")]
        public string Nome { get; set; }
        [XmlElement(ElementName = "xNome")]
        public string RazaoSocial { get; set; }
        [XmlElement]
        public string Cpf { get; set; }
        [XmlElement]
        public string Cnpj { get; set; }
        [XmlElement(ElementName ="enderTrans")]
        public EnderecoXmlModel EnderTrans { get; set; }
        [XmlElement(ElementName = "indIETrans")]
        public string IE { get; set; }
        [XmlElement(ElementName = "respFrete")]
        public bool Responsabilidade_Frete { get; set; }
    }
}
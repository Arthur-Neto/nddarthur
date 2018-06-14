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
    public class InfNFeConfiguracao
    {
        public InfNFeConfiguracao()
        {
            ide = new IdeConfiguracao();
            emit = new EmitenteConfiguracao();
            dest = new DestinatarioConfiguracao();
            det = new List<ProdutoConfiguracao>();
            total = new TotalConfiguracao();
            transp = new TransportadorConfiguracao();
        }

        [XmlAttribute(AttributeName = "Id")]
        public string ChaveAcesso { get; set; }

        [XmlAttribute(AttributeName = "Versao")]
        public string Versao { get; set; }

        [XmlElement(ElementName = "ide")]
        public IdeConfiguracao ide { get; set; }

        [XmlElement(ElementName = "emit")]
        public EmitenteConfiguracao emit { get; set; }

        [XmlElement(ElementName = "dest")]
        public DestinatarioConfiguracao dest { get; set; }

        [XmlArrayItem("det")]
        public List<ProdutoConfiguracao> det { get; set; }

        [XmlElement(ElementName = "total")]
        public TotalConfiguracao total { get; set; }

        [XmlElement(ElementName = "transp")]
        public TransportadorConfiguracao transp { get; set; }
    }
}

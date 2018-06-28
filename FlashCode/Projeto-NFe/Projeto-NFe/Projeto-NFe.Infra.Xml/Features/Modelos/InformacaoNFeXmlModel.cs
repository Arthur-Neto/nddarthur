using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projeto_NFe.Infra.Xml.Features.Modelos
{
    public class InformacaoNFeXmlModel
    {
        public InformacaoNFeXmlModel()
        {

        }
        [XmlAttribute]
        public string Id { get; set; }
        [XmlElement(ElementName = "ide")]
        public IdeXmlModel Ide { get;set; }
        [XmlElement(ElementName = "emit")]
        public EmitenteXmlModel Emit { get; set; }
        [XmlElement(ElementName = "dest")]
        public DestinatarioXmlModel Dest { get; set; }
        [XmlElement(ElementName = "trans")]
        public TransportadorXmlModel Trans { get; set; }
        [XmlElement(ElementName = "det")]
        public List<DetXmlModel> Dets { get; set; }


    }
}

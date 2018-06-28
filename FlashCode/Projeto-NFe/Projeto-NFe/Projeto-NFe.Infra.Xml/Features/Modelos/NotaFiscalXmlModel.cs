using Projeto_NFe.Dominio.Features.NotasFiscais;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projeto_NFe.Infra.Xml.Features.Modelos
{
    [XmlRoot(ElementName = "NFe",Namespace = "Projeto-NFe Academia NDD",DataType = "string")]
    public class NotaFiscalXmlModel
    {
        public NotaFiscalXmlModel() { }
        [XmlElement]
        public InformacaoNFeXmlModel InfNFe { get; set; }

        [XmlAttribute]
        public string Id { get; set; }
   
    }
}

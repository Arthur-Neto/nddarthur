using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projeto_NFe.Infra.Xml.Features.Modelos
{
    public class EmitenteXmlModel
    {
        public EmitenteXmlModel() { }
        [XmlElement]
        public string Cnpj { get; set; }
        [XmlElement]
        public string  XNome { get; set; }
        [XmlElement]
        public string XFant { get; set; }
        [XmlElement]
        public string IE { get; set; }
        [XmlElement]
        public string IM { get; set; }
        [XmlElement]
        public EnderecoXmlModel EnderEmit{ get; set; }
}
}

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
    public class TotalConfiguracao
    {
        public TotalConfiguracao()
        {
            ICMSTot = new ICMSTotConfiguracao();
        }

        [XmlElement(ElementName = "ICMSTot")]
        public ICMSTotConfiguracao ICMSTot { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ICMSTotConfiguracao
    {
        public ICMSTotConfiguracao()
        {
        }

        [XmlElement(ElementName = "vICMS")]
        public decimal ValorIcms { get; set; }

        [XmlElement(ElementName = "vFrete")]
        public decimal ValorFrete { get; set; }

        [XmlElement(ElementName = "vIPI")]
        public decimal ValorIpi { get; set; }

        [XmlElement(ElementName = "vNF")]
        public decimal ValorProdutos { get; set; }

        [XmlElement(ElementName = "vTotTrib")]
        public decimal ValorTotalNota { get; set; }
    }
}

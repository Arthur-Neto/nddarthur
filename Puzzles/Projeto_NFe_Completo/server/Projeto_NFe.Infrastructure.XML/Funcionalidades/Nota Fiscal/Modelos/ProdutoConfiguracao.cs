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
    public class ProdutoConfiguracao
    {
        [XmlAttribute(AttributeName = "nItem")]
        public int nItemNumber { get; set; }

        public ProdutoConfiguracao()
        {
            Prod = new ProdConfiguracao();
            Imposto = new ImpostoConfiguracao();
        }

        [XmlElement(ElementName = "prod")]
        public ProdConfiguracao Prod { get; set; }

        [XmlElement(ElementName = "imposto")]
        public ImpostoConfiguracao Imposto { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProdConfiguracao
    {
        [XmlElement(ElementName = "cProd")]
        public string CodigoProduto { get; set; }

        [XmlElement(ElementName = "xProd")]
        public string DescricaoProduto { get; set; }

        [XmlElement(ElementName = "qCom")]
        public int Quantidade { get; set; }

        [XmlElement(ElementName = "vUnCom")]
        public double Unitario { get; set; }

        [XmlElement(ElementName = "vProd")]
        public double Total { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ImpostoConfiguracao
    {
        public ImpostoConfiguracao()
        {
            Icms = new Icms();
        }

        [XmlElement(ElementName = "ICMS")]
        public Icms Icms { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class Icms
    {
        public Icms()
        {
            IcmsProduto = new IcmsProduto();
        }

        [XmlElement(ElementName = "ICMS00")]
        public IcmsProduto IcmsProduto { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class IcmsProduto
    {
        [XmlElement(ElementName = "pICMS")]
        public double AliquotaICMS { get; set; }

        [XmlElement(ElementName = "vICMS")]
        public double ValorICMS { get; set; }
    }
}

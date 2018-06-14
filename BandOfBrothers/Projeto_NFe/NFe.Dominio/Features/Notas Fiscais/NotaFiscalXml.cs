using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace NFe.Dominio.Features.Notas_Fiscais
{
    [ExcludeFromCodeCoverage]
    [XmlRoot("NFe")]
    public class NotaFiscalXml
    {
        public NotaFiscalXml()
        {
            infNFe = new InfNFeConfig();
        }

        [XmlElement(ElementName = "infNFe")]
        public InfNFeConfig infNFe { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class InfNFeConfig
    {
        public InfNFeConfig()
        {
            ide = new IdeConfig();
            emit = new EmitenteConfig();
            dest = new DestinatarioConfig();
            det = new List<ProdutoConfig>();
            total = new TotalConfig();
            transp = new TransportadorConfig();
        }

        [XmlAttribute(AttributeName = "Id")]
        public string ChaveAcesso { get; set; }

        [XmlAttribute(AttributeName = "Versao")]
        public string Versao { get; set; }

        [XmlElement(ElementName = "ide")]
        public IdeConfig ide { get; set; }

        [XmlElement(ElementName = "emit")]
        public EmitenteConfig emit { get; set; }

        [XmlElement(ElementName = "dest")]
        public DestinatarioConfig dest { get; set; }

        [XmlArrayItem("det")]
        public List<ProdutoConfig> det { get; set; }

        [XmlElement(ElementName = "total")]
        public TotalConfig total { get; set; }

        [XmlElement(ElementName = "transp")]
        public TransportadorConfig transp { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class IdeConfig
    {
        [XmlElement(ElementName = "natOp")]
        public string NaturezaOperacao { get; set; }

        [XmlElement(ElementName = "dhEmi")]
        public DateTime DataEmissao { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProdutoConfig
    {
        [XmlAttribute(AttributeName = "nItem")]
        public int nItemNumber { get; set; }

        public ProdutoConfig()
        {
            Prod = new ProdConfig();
            Imposto = new ImpostoConfig();
        }

        [XmlElement(ElementName = "prod")]
        public ProdConfig Prod { get; set; }

        [XmlElement(ElementName = "imposto")]
        public ImpostoConfig Imposto { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ProdConfig
    {
        [XmlElement(ElementName = "cProd")]
        public int CodigoProduto { get; set; }

        [XmlElement(ElementName = "xProd")]
        public string DescricaoProduto { get; set; }

        [XmlElement(ElementName = "qCom")]
        public int Quantidade { get; set; }

        [XmlElement(ElementName = "vUnCom")]
        public decimal Unitario { get; set; }

        [XmlElement(ElementName = "vProd")]
        public decimal Total { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ImpostoConfig
    {
        public ImpostoConfig()
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
        public decimal Ipi { get; set; }

        [XmlElement(ElementName = "vICMS")]
        public decimal Icms { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class EmitenteConfig
    {
        public EmitenteConfig()
        {
            enderDest = new EnderDestConfig();
        }

        [XmlElement(ElementName = "CNPJ")]
        public string CnpjEmitente { get; set; }

        [XmlElement(ElementName = "xNome")]
        public string RazaoSocial { get; set; }

        [XmlElement(ElementName = "xFant")]
        public string Nome { get; set; }

        [XmlElement(ElementName = "IE")]
        public string InscricaoEstadual { get; set; }

        [XmlElement(ElementName = "IM")]
        public string InscricaoMunicipal { get; set; }

        [XmlElement(ElementName = "enderEmit")]
        public EnderDestConfig enderDest { get; set; }

    }

    [ExcludeFromCodeCoverage]
    public class DestinatarioConfig
    {
        public DestinatarioConfig()
        {
            enderDest = new EnderDestConfig();
        }

        [XmlElement(ElementName = "CNPJ")]
        public string CnpjDestinatario { get; set; }

        [XmlElement(ElementName = "CPF")]
        public string CpfDestinatario { get; set; }

        [XmlElement(ElementName = "xNome")]
        public string Nome { get; set; }

        [XmlElement(ElementName = "indIEDest")]
        public string InscricaoEstadual { get; set; }

        [XmlElement(ElementName = "enderDest")]
        public EnderDestConfig enderDest { get; set; }

    }

    [ExcludeFromCodeCoverage]
    public class EnderDestConfig
    {
        [XmlElement(ElementName = "xLgr")]
        public string Logradouro { get; set; }

        [XmlElement(ElementName = "nro")]
        public string Numero { get; set; }

        [XmlElement(ElementName = "xBairro")]
        public string Bairro { get; set; }

        [XmlElement(ElementName = "xMun")]
        public string Municipio { get; set; }

        [XmlElement(ElementName = "UF")]
        public string Estado { get; set; }

        [XmlElement(ElementName = "xPais")]
        public string Pais { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TotalConfig
    {
        public TotalConfig()
        {
            ICMSTot = new ICMSTotConfig();
        }

        [XmlElement(ElementName = "ICMSTot")]
        public ICMSTotConfig ICMSTot { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class ICMSTotConfig
    {
        public ICMSTotConfig()
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

    [ExcludeFromCodeCoverage]
    public class TransportadorConfig
    {
        public TransportadorConfig()
        {
            Transporta = new TransportaConfig();
        }

        [XmlElement(ElementName = "modFrete")]
        public int modFrete { get; set; }

        [XmlElement(ElementName = "transporta")]
        public TransportaConfig Transporta { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class TransportaConfig
    {
        public TransportaConfig()
        {
        }

        [XmlElement(ElementName = "CNPJ")]
        public string CnpjDestinatario { get; set; }

        [XmlElement(ElementName = "xNome")]
        public string Nome { get; set; }

        [XmlElement(ElementName = "IE")]
        public string InscricaoEstadual { get; set; }

        [XmlElement(ElementName = "xEnder")]
        public string Logradouro { get; set; }

        [XmlElement(ElementName = "xMun")]
        public string Municipio { get; set; }

        [XmlElement(ElementName = "UF")]
        public string Estado { get; set; }
    }
}
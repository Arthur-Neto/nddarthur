using NFe.Infra.XML.Features.NotasFiscais.Modelos;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace NFe.Infra.XML.Features.NotasFiscais
{
    [ExcludeFromCodeCoverage]
    [XmlRoot("NFe")]
    public class NotaFiscalModeloXml
    {
        public NotaFiscalModeloXml()
        {
            infNFe = new InfNFeConfiguracao();
        }

        [XmlElement(ElementName = "infNFe")]
        public InfNFeConfiguracao infNFe { get; set; }
    }    
}

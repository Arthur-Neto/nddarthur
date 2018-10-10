using NFe.Infra.XML.Features.NotasFiscais;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Infrastructure.XML.Funcionalidades.Nota_Fiscal.Mapeadores;
using Projeto_NFe.Infrastructure.XML.Serializador;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Projeto_NFe.Infrastructure.XML.Funcionalidades.Nota_Fiscal
{
    public class NotaFiscalRepositorioXML
    {
       public virtual string Serializar(NotaFiscal notaFiscal)
        {
            NotaFiscalModeloXml notaFiscalXML = NotaFiscalParaNotaFiscalXMLModelo.MontarNotaFiscalXMLModelo(notaFiscal);
            return XMLHelper.Serializar(notaFiscalXML);
        }

        public virtual void Serializar(NotaFiscal notaFiscal, string caminho)
        {
            NotaFiscalModeloXml notaFiscalXML = NotaFiscalParaNotaFiscalXMLModelo.MontarNotaFiscalXMLModelo(notaFiscal);
            XMLHelper.SerializarParaAquivo(notaFiscalXML, caminho);
        }
    }
}

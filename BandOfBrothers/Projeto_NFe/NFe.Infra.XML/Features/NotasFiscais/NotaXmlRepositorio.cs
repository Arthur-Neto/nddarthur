using NFe.Dominio.Features.Notas_Fiscais;
using NFe.Infra.Utils;
using NFe.Infra.XML.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NFe.Infra.XML.Features.NotasFiscais
{
    public class NotaXmlRepositorio : INotaXmlRepositorio
    {
        public NotaXmlRepositorio()
        {
            NotaFiscalModeloXml = new NotaFiscalModeloXml();
        }

        public virtual NotaFiscalModeloXml NotaFiscalModeloXml { get; set; }

        public virtual string XmlNotaFiscal
        {
            get
            {
                return SerializeHelper.Serialize(NotaFiscalModeloXml);
            }
        }

        public void NotaFiscalParaXml(NotaFiscal notaFiscal)
        {
            NotaParaXml NotaParaXml = new NotaParaXml();
            if (notaFiscal != null)
            {
                NotaFiscalModeloXml.infNFe = NotaParaXml.GeraValoresParaInfNFeXml(notaFiscal);
                NotaFiscalModeloXml.infNFe.ide = NotaParaXml.GeraValoresParaIdeNFeXml(notaFiscal);
                NotaFiscalModeloXml.infNFe.det = NotaParaXml.GeraValoresProdutoXml(notaFiscal);
                NotaFiscalModeloXml.infNFe.dest = NotaParaXml.GeraValoresParaDestinatarioXml(notaFiscal);
                NotaFiscalModeloXml.infNFe.emit = NotaParaXml.GeraValoresParaEmitenteXml(notaFiscal);
                NotaFiscalModeloXml.infNFe.total.ICMSTot = NotaParaXml.GeraValoresParaIcmsTotalXml(notaFiscal);
                NotaFiscalModeloXml.infNFe.transp = NotaParaXml.GeraValoresParaTransportadorXml(notaFiscal);
            }
            else
                throw new NotaFiscalXmlNulaException();
        }

        public NotaFiscal XmlParaNotaFiscal(NotaFiscal notaFiscal)
        {
            XmlParaNota XmlParaNota = new XmlParaNota();

            if (!(notaFiscal == null))
            {
                NotaFiscalModeloXml = SerializeHelper.Deserialize<NotaFiscalModeloXml>(notaFiscal.NotaFiscalXml);

                notaFiscal.Emitente = XmlParaNota.PegaEmitente(NotaFiscalModeloXml);
                notaFiscal.Emitente.Id = notaFiscal.Emitente.Id;
                notaFiscal.Transportador = XmlParaNota.PegaTransportador(NotaFiscalModeloXml);
                notaFiscal.Transportador.Id = notaFiscal.Transportador.Id;
                notaFiscal.Destinatario = XmlParaNota.PegaDestinatario(NotaFiscalModeloXml);
                notaFiscal.Destinatario.Id = notaFiscal.Destinatario.Id;
                notaFiscal.Produtos = XmlParaNota.PegarProdutos(NotaFiscalModeloXml);

                return notaFiscal;
            }
            else
                throw new NotaFiscalXmlNulaException();
        }

        public  void ExportaParaArquivoXml(string caminho, NotaFiscal notaFiscal)
        {
            if (notaFiscal != null)
            {
                using (var fs = new FileStream(caminho, FileMode.OpenOrCreate))
                using (StreamWriter file = new StreamWriter(fs, Encoding.UTF8))
                {
                    NotaFiscalParaXml(notaFiscal);
                    file.WriteLine(XmlNotaFiscal);
                }
            }
            else
             throw new NotaFiscalXmlNulaException();
        }
    }
}

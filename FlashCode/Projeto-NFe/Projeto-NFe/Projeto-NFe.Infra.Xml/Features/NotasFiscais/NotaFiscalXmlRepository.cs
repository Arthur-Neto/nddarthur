using Projeto_NFe.Dominio.Base;
using Projeto_NFe.Dominio.Features.Destinatarios;
using Projeto_NFe.Dominio.Features.Emitentes;
using Projeto_NFe.Dominio.Features.Enderecos;
using Projeto_NFe.Dominio.Features.NotasFiscais;
using Projeto_NFe.Dominio.Features.Produtos;
using Projeto_NFe.Dominio.Features.Transportadores;
using Projeto_NFe.Infra.Xml.Features.Mapeador;
using Projeto_NFe.Infra.Xml.Features.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Projeto_NFe.Infra.Xml.Features.NotasFiscais
{
    public class NotaFiscalXmlRepository : INotaFiscalExportacao
    {
        private string _caminho;

        public NotaFiscalXmlRepository(string caminho)
        {
            _caminho = caminho;
        }

        public string SerializarParaString(NotaFiscal notaFiscal)
        {
            NotaFiscalXmlModel notaModel = MapeadorNotaFiscal.MapearParaNFeModel(notaFiscal);
            string xml = string.Empty;

            using (StringWriter escritor = new StringWriter())
            {
                XmlSerializer serializador = new XmlSerializer(notaModel.GetType());
                serializador.Serialize(escritor, notaModel);
                xml = escritor.ToString();
            }
            return xml;
        }
        public void SerializarParaArquivo(NotaFiscal notaFiscal)
        {
            NotaFiscalXmlModel notaModel = MapeadorNotaFiscal.MapearParaNFeModel(notaFiscal);
            using (XmlWriter streamWriter = XmlWriter.Create(_caminho))
            {
                XmlSerializer serializador = new XmlSerializer(notaModel.GetType());
                serializador.Serialize(streamWriter, notaModel);
            }
        }
        public NotaFiscal Deserializar(string xml)
        {
            using (XmlReader leitor = XmlReader.Create(new StringReader(xml)))
            {
                XmlSerializer serializador = new XmlSerializer(typeof(NotaFiscalXmlModel));
                var model = (NotaFiscalXmlModel)serializador.Deserialize(leitor);
                return MapeadorNotaFiscal.MapearDeNFeModel(model);
            }
        }
        public bool Exportar(NotaFiscal notaFiscal)
        {
            SerializarParaArquivo(notaFiscal);
            if (!File.Exists(_caminho))
                return false;

            return true;
        }

    }
}


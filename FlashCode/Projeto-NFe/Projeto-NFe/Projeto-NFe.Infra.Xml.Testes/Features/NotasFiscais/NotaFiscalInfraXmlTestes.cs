using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Comuns.Testes.Features.NotasFiscais;
using Projeto_NFe.Dominio.Features.NotasFiscais;
using Projeto_NFe.Infra.Xml.Features.NotasFiscais;
using System;
using System.IO;

namespace Projeto_NFe.Infra.Xml.Testes.Features.NotasFiscais
{
    [TestFixture]
    public class NotaFiscalInfraXmlTestes
    {
        private NotaFiscal _notaFiscal;
        private INotaFiscalExportacao _notaFiscalExportacao;
        private string _caminho;

        [SetUp]
        public void SetUp()
        {
            _notaFiscal = new NotaFiscal();
            _caminho = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            _notaFiscalExportacao = new NotaFiscalXmlRepository(_caminho);
        }

        [Test]
        public void NotaFiscal_InfraXml_EXportar_EsperadoOK()
        {
            _notaFiscal = NotaFiscalObjetoMae.ObterValidoNotaFiscal();
            var caminho = Path.Combine(_caminho, _notaFiscal.Chave + ".xml");
            _notaFiscalExportacao = new NotaFiscalXmlRepository(caminho);

            var emitido = _notaFiscalExportacao.Exportar(_notaFiscal);

            emitido.Should().Be(true);
        }
        [Test]
        public void NotaFiscal_InfraXml_EXportar_TransportadorPessoa_EsperadoOK()
        {
            _notaFiscal = NotaFiscalObjetoMae.ObterValidoNotaFiscalTransportadorPessoa();
            var caminho = Path.Combine(_caminho, _notaFiscal.Chave + ".xml");
            _notaFiscalExportacao = new NotaFiscalXmlRepository(caminho);

            var emitido = _notaFiscalExportacao.Exportar(_notaFiscal);

            emitido.Should().Be(true);
        }
    }
}

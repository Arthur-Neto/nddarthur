using FluentAssertions;
using NFe.Common.Testes.Features;
using NFe.Dominio.Features.Notas_Fiscais;
using NFe.Infra.XML.Exceptions;
using NFe.Infra.XML.Features.NotasFiscais;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFe.Infra.XML.Testes.Features.Notas_Fiscais
{
    [TestFixture]
    public class NotaFiscalXmlTestes
    {
        public NotaFiscal _nota { get; set; }
        public NotaXmlRepositorio _notaXml { get; set; }

        [SetUp]
        public void SetUp()
        {
            _notaXml = new NotaXmlRepositorio();
        }

        [Test]
        public void NotaFiscal_InfraXml_NotaFiscalParaXMlComCnpj_DeveFuncionar()
        {
            _nota = ObjectMother.ObterNotaEmitidaValidaComCnpjRazaoSocial();
            _nota.Emitir();

            Action action = () => _notaXml.NotaFiscalParaXml(_nota);

            action.Should().NotThrow();

            _notaXml.XmlNotaFiscal.Should().NotBeNull();
        }

        [Test]
        public void NotaFiscal_InfraXml_NotaFiscalParaXMlComCpf_DeveFuncionar()
        {
            _nota = ObjectMother.ObterNotaEmitidaValidaComCpf();
            _nota.Emitir();

            Action action = () => _notaXml.NotaFiscalParaXml(_nota);

            action.Should().NotThrow();

            _notaXml.XmlNotaFiscal.Should().NotBeNull();
        }

        [Test]
        public void NotaFiscal_InfraXml_NotaFiscalParaXMlComDataVazia_DeveFuncionar()
        {
            _nota = ObjectMother.ObterNotaEmitidaValidaComCpf();
            _nota.Emitir();
            _nota.DataEmissao = null;
            Action action = () => _notaXml.NotaFiscalParaXml(_nota);

            action.Should().NotThrow();

            _notaXml.XmlNotaFiscal.Should().NotBeNull();
        }

        [Test]
        public void NotaFiscal_InfraXml_XmlParaNotaFiscalComCpfeNome_DeveFuncionar()
        {
            _nota = ObjectMother.ObterNotaEmitidaValidaComCnpjRazaoSocial();
            _nota.Emitir();

            _notaXml.NotaFiscalParaXml(_nota);
            _nota.NotaFiscalXml = _notaXml.XmlNotaFiscal;

            NotaFiscal result = _notaXml.XmlParaNotaFiscal(_nota);

            result.Should().NotBeNull();
        }

        [Test]
        public void NotaFiscal_InfraXml_XmlParaNotaFiscalComCnpjERazaoSocial_DeveFuncionar()
        {
            _nota = ObjectMother.ObterNotaEmitidaValidaComCpf();
            _nota.Emitir();

            _notaXml.NotaFiscalParaXml(_nota);
            _nota.NotaFiscalXml = _notaXml.XmlNotaFiscal;

            NotaFiscal result = _notaXml.XmlParaNotaFiscal(_nota);

            result.Should().NotBeNull();
        }

        [Test]
        public void NotaFiscal_InfraXml_ExportarXMl_DeveFuncionar()
        {
            //O arquivo vai ser salvo em \Projeto_NFe\NFe.Infra.XML.Testes\bin
            var caminho = AppDomain.CurrentDomain.BaseDirectory + "\\..\\teste.xml";

            _nota = ObjectMother.ObterNotaEmitidaValida();
            _nota.Emitir();

            _notaXml.NotaFiscalParaXml(_nota);
            _nota.NotaFiscalXml = _notaXml.XmlNotaFiscal;

            Action action = () => _notaXml.ExportaParaArquivoXml(caminho, _nota);

            action.Should().NotThrow();

            _notaXml.XmlNotaFiscal.Should().NotBeNull();
        }

        [Test]
        public void NotaFiscal_InfraXml_NotaFiscalParaXMl_NaoDeveFuncionar()
        {
            _nota = ObjectMother.ObterNotaEmitidaValida();
            _nota.Emitir();
            _nota = null;

            Action action = () => _notaXml.NotaFiscalParaXml(_nota);

            action.Should().Throw<NotaFiscalXmlNulaException>();
        }

        [Test]
        public void NotaFiscal_InfraXml_XmlParaNotaFiscal_NaoDeveFuncionar()
        {
            _nota = ObjectMother.ObterNotaEmitidaValida();
            _nota.Emitir();

            _notaXml.NotaFiscalParaXml(_nota);
            _nota.NotaFiscalXml = _notaXml.XmlNotaFiscal;
            _nota = null;

            Action action = () => _notaXml.XmlParaNotaFiscal(_nota);

            action.Should().Throw<NotaFiscalXmlNulaException>();
        }

        [Test]
        public void NotaFiscal_InfraXml_ExportarXMl_NaoDeveFuncionar()
        {
            //O arquivo vai ser salvo em \Projeto_NFe\NFe.Infra.XML.Testes\bin
            var caminho = AppDomain.CurrentDomain.BaseDirectory + "\\..\\teste.xml";

            _nota = ObjectMother.ObterNotaEmitidaValida();
            _nota.Emitir();

            _notaXml.NotaFiscalParaXml(_nota);
            _nota.NotaFiscalXml = _notaXml.XmlNotaFiscal;

            _nota = null;

            Action action = () => _notaXml.ExportaParaArquivoXml(caminho, _nota);

            action.Should().Throw<NotaFiscalXmlNulaException>();
        }
    }
}

using FluentAssertions;
using NFe.Common.Testes.Features;
using NFe.Dominio.Features.Notas_Fiscais;
using NUnit.Framework;
using System;

namespace NFe.Dominio.Testes.Features.Notas_Fiscais
{
    [TestFixture]
    public class NotaFiscalTestes
    {
        NotaFiscal notaFiscal;

        [SetUp]
        public void SetUp()
        {
            notaFiscal = new NotaFiscal();
        }

        [Test]
        public void NotaFiscal_Dominio_Validar_DeveValidarOk()
        {
            notaFiscal = ObjectMother.ObterNotaValida();

            Action acao = notaFiscal.Validar;

            acao.Should().NotThrow();
        }

        [Test]
        public void NotaFiscal_Dominio_Emitir_DeveEmitirNota()
        {
            notaFiscal = ObjectMother.ObterNotaValida();
            notaFiscal.GerarChaveAcesso();

            Action acao = notaFiscal.Emitir;

            acao.Should().NotThrow();
        }

        [Test]
        public void NotaFiscal_Dominio_Emitir_DeveObterXmlNota()
        {
            notaFiscal = ObjectMother.ObterNotaValida();
            notaFiscal.GerarChaveAcesso();

            Action acao = notaFiscal.Emitir;

            acao.Should().NotThrow(); 
            notaFiscal.NotaFiscalXml.Should().NotBeNull();
        }

        [Test]
        public void NotaFiscal_Dominio_Validar_DeveValidarNotaEmitidaOk()
        {
            notaFiscal = ObjectMother.ObterNotaEmitidaValida();

            Action acao = notaFiscal.Validar;

            acao.Should().NotThrow();
        }

        [Test]
        public void NotaFiscal_Dominio_Validar_DeveValidarNotaComDataEmissaoNula()
        {
            notaFiscal = ObjectMother.ObterNotaEmitidaValida();
            notaFiscal.DataEmissao = null;

            Action acao = notaFiscal.Validar;

            acao.Should().NotThrow();
        }

        [Test]
        public void NotaFiscal_Dominio_Validar_DeveJogarExcecaoDestinatarioIgualEmitente()
        {
            notaFiscal = ObjectMother.ObterNotaComEmitenteIgualDestinatario();

            Action acao = notaFiscal.Validar;

            acao.Should().Throw<NotaFiscalEmitenteEqualsDestinatarioException>();
        }

        [Test]
        public void NotaFiscal_Dominio_Validar_DeveJogarExcecaoDataEntradaMaiorDataEmitida()
        {
            notaFiscal = ObjectMother.ObterNotaEmitidaComDataEntradaEMaiorQueDataEmitida();
            notaFiscal.DataEntrada = DateTime.Now.AddDays(30);
            notaFiscal.DataEmissao = DateTime.Now;

            Action acao = notaFiscal.Validar;

            acao.Should().Throw<NotaFiscalDataEntradaOverflowException>();
        }

        [Test]
        public void NotaFiscal_Dominio_Validar_DeveJogarExcecaoEmitenteVazio()
        {
            notaFiscal = ObjectMother.ObterNotaValida();
            notaFiscal.Emitente = null;

            Action acao = notaFiscal.Validar;

            acao.Should().Throw<NotaFiscalEmitenteVazioException>();
        }

        [Test]
        public void NotaFiscal_Dominio_Validar_DeveJogarExcecaoDestinatarioVazio()
        {
            notaFiscal = ObjectMother.ObterNotaValida();
            notaFiscal.Destinatario = null;

            Action acao = notaFiscal.Validar;

            acao.Should().Throw<NotaFiscalDestinatarioVazioException>();
        }

        [Test]
        public void NotaFiscal_Dominio_Validar_DevePreencherTransportadorVazioComOsDadosDeDestinatario()
        {
            notaFiscal = ObjectMother.ObterNotaValidaSemTransportador();
            notaFiscal.Transportador = null;

            notaFiscal.Validar();

            notaFiscal.Transportador.Nome.Should().Be(notaFiscal.Destinatario.Nome);
        }
    }
}

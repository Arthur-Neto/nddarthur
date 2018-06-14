using FluentAssertions;
using NFe.Common.Testes.Features;
using NFe.Dominio.Features.Notas_Fiscais;
using NFe.Infra.PDF.Features.Notas_Fiscais;
using NUnit.Framework;
using System;

namespace NFe.Infra.PDF.Testes.Features.Notas_Fiscais
{
    [TestFixture]
    public class NotaFiscalPdfTestes
    {
        NotaFiscal nota;

        [Test]
        public void NotaFiscal_InfraPdf_DeveGerarPDFOk()
        {
            nota = ObjectMother.ObterNotaEmitidaValida();
            var caminho = AppDomain.CurrentDomain.BaseDirectory + "\\..\\teste.pdf";
            nota.Emitir();

            Action action = () => NotaFiscalPdf.Exportar(caminho, nota);

            action.Should().NotThrow();
        }

        [Test]
        public void NotaFiscal_InfraPdf_DeveGerarPDFComCpfEmitenteOk()
        {
            nota = ObjectMother.ObterNotaEmitidaValida();
            nota.Emitente = ObjectMother.ObterEmitenteComCnpjVazio();
            var caminho = AppDomain.CurrentDomain.BaseDirectory + "\\..\\teste.pdf";
            nota.Emitir();

            Action action = () => NotaFiscalPdf.Exportar(caminho, nota);

            action.Should().NotThrow();
        }

        [Test]
        public void NotaFiscal_InfraPdf_DeveGerarPDFComCnpjEmitenteOk()
        {
            nota = ObjectMother.ObterNotaEmitidaValida();
            nota.Emitente = ObjectMother.ObterEmitenteComCpfVazio();
            var caminho = AppDomain.CurrentDomain.BaseDirectory + "\\..\\teste.pdf";
            nota.Emitir();

            Action action = () => NotaFiscalPdf.Exportar(caminho, nota);

            action.Should().NotThrow();
        }

        [Test]
        public void NotaFiscal_InfraPdf_DeveGerarPDFComCpfDestinatarioOk()
        {
            nota = ObjectMother.ObterNotaEmitidaValida();
            nota.Destinatario = ObjectMother.ObtemDestinatarioCnpjVazio();
            var caminho = AppDomain.CurrentDomain.BaseDirectory + "\\..\\teste.pdf";
            nota.Emitir();

            Action action = () => NotaFiscalPdf.Exportar(caminho, nota);

            action.Should().NotThrow();
        }

        [Test]
        public void NotaFiscal_InfraPdf_DeveGerarPDFComCnpjDestinatarioOk()
        {
            nota = ObjectMother.ObterNotaEmitidaValida();
            nota.Destinatario = ObjectMother.ObtemDestinatarioCpfVazio();
            var caminho = AppDomain.CurrentDomain.BaseDirectory + "\\..\\teste.pdf";
            nota.Emitir();

            Action action = () => NotaFiscalPdf.Exportar(caminho, nota);

            action.Should().NotThrow();
        }

        [Test]
        public void NotaFiscal_InfraPdf_DeveGerarPDFComCpfTransportadorOK()
        {
            nota = ObjectMother.ObterNotaEmitidaValida();
            nota.Transportador = ObjectMother.ObterTransportadorComCnpjVazio();
            var caminho = AppDomain.CurrentDomain.BaseDirectory + "\\..\\teste.pdf";
            nota.Emitir();

            Action action = () => NotaFiscalPdf.Exportar(caminho, nota);

            action.Should().NotThrow();
        }

        [Test]
        public void NotaFiscal_InfraPdf_DeveGerarPDFComCnpjTransportadorOK()
        {
            nota = ObjectMother.ObterNotaEmitidaValida();
            nota.Transportador = ObjectMother.ObterTransportadorComCpfVazio();
            var caminho = AppDomain.CurrentDomain.BaseDirectory + "\\..\\teste.pdf";
            nota.Emitir();
            Action action = () => NotaFiscalPdf.Exportar(caminho, nota);

            action.Should().NotThrow();
        }
    }
}

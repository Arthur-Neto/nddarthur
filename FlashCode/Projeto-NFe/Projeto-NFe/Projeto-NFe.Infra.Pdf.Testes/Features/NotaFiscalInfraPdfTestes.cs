using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Comuns.Testes.Features.NotasFiscais;
using Projeto_NFe.Dominio.Features.NotasFiscais;
using Projeto_NFe.Infra.Pdf.Features.NotasFiscais;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Projeto_NFe.Infra.Pdf.Testes.Features
{
    [TestFixture]
    public class NotaFiscalInfraPdfTestes
    {
        private NotaFiscal _notafiscal;
        private INotaFiscalExportacao _notaFiscalPdf;

        [SetUp]
        public void SetUp()
        {
            _notafiscal = new NotaFiscal();
            _notaFiscalPdf = new NotaFiscalPdf(@".\notafiscal.pdf");
        }


        [Test]
        public void NotaFiscal_InfraPdf_Emitir_EsperadoOK()
        {
            _notafiscal = NotaFiscalObjetoMae.ObterValidoNotaFiscal();

           var emitido = _notaFiscalPdf.Exportar(_notafiscal);

            emitido.Should().Be(true);
        }
    }
}
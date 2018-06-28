using System;
using System.Collections.Generic;
using System.IO;
using DanfeSharp;
using DanfeSharp.Modelo;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Projeto_NFe.Dominio.Features.NotasFiscais;
using Projeto_NFe.Infra.Pdf.Features.Destinatarios;
using Projeto_NFe.Infra.Pdf.Features.Emitentes;
using Projeto_NFe.Infra.Pdf.Features.Impostos;
using Projeto_NFe.Infra.Pdf.Features.Transportadores;

namespace Projeto_NFe.Infra.Pdf.Features.NotasFiscais
{
    public class NotaFiscalPdf : INotaFiscalExportacao
    {
        private string _caminho;

        public NotaFiscalPdf(String caminho)
        {
            this._caminho = caminho;
        }
        
        public bool Exportar(NotaFiscal notaFiscal)
        {
            if (notaFiscal == null)
                return false;

            var modelo = NotaFiscalMapPdf.MapParaNotaFiscalViewModel(notaFiscal);
            using (var danfe = new Danfe(modelo))
            {
                danfe.Gerar();
                danfe.Salvar(_caminho);
            }
            
            return true;
        }
    }
}

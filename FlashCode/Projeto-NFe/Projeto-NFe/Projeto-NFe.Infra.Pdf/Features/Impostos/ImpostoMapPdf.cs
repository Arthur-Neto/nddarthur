using DanfeSharp.Modelo;
using Projeto_NFe.Dominio.Features.NotasFiscais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Pdf.Features.Impostos
{
    public static class ImpostoMapPdf
    {
        public static CalculoImpostoViewModel MapParaImpostoViewModel(NotaFiscal notaFiscal)
        {
            return new CalculoImpostoViewModel()
            {
                BaseCalculoIcms = notaFiscal.ValorTotalProdutos,
                ValorFrete = notaFiscal.ValorFrete,
                ValorIcms = notaFiscal.ObterICMS(),
                ValorIpi = notaFiscal.ObterIPI(),
                ValorTotalNota = notaFiscal.ValorTotalNota,
                ValorTotalProdutos = notaFiscal.ValorTotalProdutos,
                ValorAproximadoTributos = null
            };
        }
    }
}

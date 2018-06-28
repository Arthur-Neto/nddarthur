using DanfeSharp;
using DanfeSharp.Modelo;
using Projeto_NFe.Dominio.Features.NotasFiscais;
using Projeto_NFe.Infra.Pdf.Features.Destinatarios;
using Projeto_NFe.Infra.Pdf.Features.Emitentes;
using Projeto_NFe.Infra.Pdf.Features.Impostos;
using Projeto_NFe.Infra.Pdf.Features.Transportadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Pdf.Features.NotasFiscais
{
    public static class NotaFiscalMapPdf
    {
        private static List<ProdutoViewModel> ConverterParaProdutoModel(NotaFiscal notaFiscal)
        {
            var produtos = new List<ProdutoViewModel>();

            foreach (var produto in notaFiscal.Produtos)
            {
                ProdutoViewModel produtoModel = new ProdutoViewModel
                {
                    AliquotaIcms = produto.Imposto.AliquotaICMS,
                    AliquotaIpi = produto.Imposto.AliquotaIPI,
                    BaseIcms = produto.ValorTotal,
                    Codigo = produto.CodigoProduto.ToString(),
                    Descricao = produto.Descricao,
                    Quantidade = produto.Quantidade,
                    ValorIcms = produto.Imposto.ValorICMS,
                    ValorIpi = produto.Imposto.ValorIPI,
                    ValorTotal = produto.ValorTotal,
                    ValorUnitario = produto.ValorUnitario,

                };

                produtos.Add(produtoModel);
            }
            return produtos;
        }
        public static DanfeViewModel MapParaNotaFiscalViewModel(NotaFiscal notaFiscal)
        {
            return new DanfeViewModel()
            {
                ChaveAcesso = notaFiscal.Chave,
                DataHoraEmissao = notaFiscal.DataEmissao,
                Produtos = ConverterParaProdutoModel(notaFiscal),
                NaturezaOperacao = notaFiscal.NaturezaOperacao,
                NfNumero = notaFiscal.ID,
                Orientacao = Orientacao.Retrato,
                DataSaidaEntrada = notaFiscal.DataEntrada,
                CalculoImposto = ImpostoMapPdf.MapParaImpostoViewModel(notaFiscal),
                Destinatario = DestinatarioMapPdf.MapParaDestinatarioViewModel(notaFiscal.Destinatario),
                Emitente = EmitenteMapPdf.MapParaEmitenteViewModel(notaFiscal.Emitente),
                Transportadora = TransportadorMapPdf.MapParaTransportadoraViewModel(notaFiscal.Transportador)
            };
        }
    }
}

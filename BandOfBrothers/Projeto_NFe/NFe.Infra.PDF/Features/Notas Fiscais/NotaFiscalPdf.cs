using iTextSharp.text.pdf;
using NFe.Dominio.Features.Notas_Fiscais;
using System;
using System.IO;
using System.Linq;

namespace NFe.Infra.PDF.Features.Notas_Fiscais
{
    public static class NotaFiscalPdf
    {
        public static void Exportar(string caminho, NotaFiscal nota)
        {
            string caminhoModeloNFE = AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\..\\NFe.Infra.PDF\\Modelos\\Modelo NFE.pdf";
            PdfReader reader = new PdfReader(caminhoModeloNFE);
            using (PdfStamper stamper = new PdfStamper(reader, new FileStream(caminho, FileMode.Create)))
            {
                AcroFields fields = stamper.AcroFields;

                SetarCamposEmitente(nota, fields);
                SetarCamposDestinatario(nota, fields);
                SetarCamposValorNota(nota, fields);
                SetarCamposTransportador(nota, fields);
                SetarCamposProduto(nota, fields);

                stamper.FormFlattening = true;
                stamper.Close();
            }
        }

        private static void SetarCamposProduto(NotaFiscal nota, AcroFields fields)
        {
            for (int i = 0; i < nota.Produtos.Count; i++)
            {
                fields.SetField("DET_PROD_CPROD." + i, nota.Produtos[i].CodigoProduto.ToString());
                fields.SetField("DET_PROD_XPROD." + i, nota.Produtos[i].Descricao);
                fields.SetField("DET_PROD_QCOM." + i, nota.Produtos[i].Quantidade.ToString());
                fields.SetField("DET_PROD_VPROD." + i, nota.Produtos[i].ValorProduto.Total.ToString());
                fields.SetField("DET_IMPOSTO_ICMS_ICMS_PICMS." + i, nota.Produtos[i].ValorProduto.Aliquota.ICMS.ToString());
                fields.SetField("DET_IMPOSTO_IPI_IPITRIB_PIPI." + i, nota.Produtos[i].ValorProduto.Aliquota.Ipi.ToString());
                fields.SetField("DET_IMPOSTO_IPI_IPITRIB_VIPI." + i, nota.Produtos[i].ValorProduto.Ipi.ToString());
                fields.SetField("DET_PROD_VUNCOM." + i, nota.Produtos[i].ValorProduto.Unitario.ToString());
                fields.SetField("DET_IMPOSTO_ICMS_ICMS_VICMS." + i, nota.Produtos[i].ValorProduto.ICMS.ToString());
            }
        }

        private static void SetarCamposEmitente(NotaFiscal nota, AcroFields fields)
        {
            fields.SetField("NOME", nota.Emitente.Nome);
            fields.SetField("LOGRADOURO", nota.Emitente.Endereco.Logradouro);
            fields.SetField("BAIRRO", nota.Emitente.Endereco.Bairro);
            fields.SetField("IDE_TPNF", "1");
            fields.SetField("IDE_TOTALPAGES", "1");
            fields.SetField("IDE_CURRENTPAGE", "1");
            fields.SetField("EMIT_IE", nota.Emitente.InscricaoEstadual);
            fields.SetField("EMIT_IM", nota.Emitente.InscricaoMunicipal);

            if (nota.Emitente.Cpf.EhValido)
                fields.SetField("EMIT_CPF", nota.Emitente.Cpf.valor);
            else
                fields.SetField("EMIT_CNPJ", nota.Emitente.Cnpj.valor);
        }

        private static void SetarCamposDestinatario(NotaFiscal nota, AcroFields fields)
        {
            fields.SetField("DEST_XNOME", nota.Destinatario.Nome + " | " + nota.Destinatario.RazaoSocial);
            fields.SetField("IDE_DEMI", Convert.ToDateTime(nota.DataEmissao).ToShortDateString());
            fields.SetField("IDE_DSAIENT", nota.DataEntrada.ToShortDateString());

            if (nota.Destinatario.Cpf.EhValido)
                fields.SetField("DEST_CPF", nota.Destinatario.Cpf.valor);
            else
                fields.SetField("DEST_CNPJ", nota.Destinatario.Cnpj.valor);

            fields.SetField("DEST_ENDERDEST_XLGR", nota.Destinatario.Endereco.Logradouro);
            fields.SetField("DEST_ENDERDEST_XBAIRRO", nota.Destinatario.Endereco.Bairro);
            fields.SetField("DEST_ENDERDEST_XMUN", nota.Destinatario.Endereco.Municipio);
            fields.SetField("DEST_ENDERDEST_UF", nota.Destinatario.Endereco.Estado);
            fields.SetField("DEST_ENDERDEST_NRO", nota.Destinatario.Endereco.Numero);
            fields.SetField("DEST_IE", nota.Destinatario.InscricaoEstadual);
        }

        private static void SetarCamposValorNota(NotaFiscal nota, AcroFields fields)
        {
            fields.SetField("IDE_NATOP", nota.NaturezaOperacao);
            fields.SetField("IDE_REFNFEMASK", nota.ChaveAcesso);
            fields.SetField("TOTAL_ICMSTOT_VFRETE", nota.Valor.Frete.ToString());
            fields.SetField("TOTAL_ICMSTOT_VICMS", nota.Valor.ICMS.ToString());
            fields.SetField("TOTAL_ICMSTOT_VPROD", nota.Valor.TotalProdutos.ToString());
            fields.SetField("TOTAL_ICMSTOT_VIPI", nota.Valor.Ipi.ToString());
            fields.SetField("TOTAL_ICMSTOT_VNF", nota.Valor.TotalNota.ToString());
        }

        private static void SetarCamposTransportador(NotaFiscal nota, AcroFields fields)
        {
            fields.SetField("TRANSP_TRANSPORTA_XNOME", nota.Transportador.Nome + nota.Transportador.RazaoSocial);
            fields.SetField("TRANSP_TRANSPORTA_XENDER", nota.Transportador.Endereco.Logradouro);
            fields.SetField("TRANSP_VOL_QVOL.0", nota.Produtos.Sum(prod => prod.Quantidade).ToString());
            fields.SetField("TRANSP_MODFRETE", nota.Transportador.ResponsabilidadeFrete.ToString());
            fields.SetField("TRANSP_VEICTRANSP_UF", nota.Transportador.Endereco.Estado);

            if (nota.Transportador.Cnpj.EhValido)
                fields.SetField("TRANSP_TRANSPORTA_CNPJ", nota.Transportador.Cnpj.valor);
            else
                fields.SetField("TRANSP_TRANSPORTA_CPF", nota.Transportador.Cpf.valor);

            fields.SetField("TRANSP_TRANSPORTA_IE", nota.Transportador.InscricaoEstadual);
            fields.SetField("TRANSP_TRANSPORTA_XMUN", nota.Transportador.Endereco.Municipio);
            fields.SetField("TRANSP_TRANSPORTA_UF", nota.Transportador.Endereco.Estado);
        }
    }
}

using iTextSharp.text.pdf;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.PDF.Funcionalidades.Nota_Fiscal
{
    public class NotaFiscalRepositorioPDF
    {
        public void Exportar(string caminhoParaANovaNotaFiscal, NotaFiscal notaFiscal)
        {
            string pdfTemplate = @"..\..\..\Modelo.pdf";
            string newFile = caminhoParaANovaNotaFiscal;

            PdfReader pdfReader = new PdfReader(pdfTemplate);
            PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(
                        newFile, FileMode.Create));

            AcroFields pdfFormFields = pdfStamper.AcroFields;

            // Atribui os campos conforme o modelo

            // NotaFiscal
            pdfFormFields.SetField("CHAVE_ACESSO", "NFe" + notaFiscal.ChaveAcesso);
            pdfFormFields.SetField("EMITENTE_NATUREZA_DA_OPERACAO", notaFiscal.NaturezaOperacao);
            pdfFormFields.SetField("DATA_EMISSAO", notaFiscal.DataEmissao.ToString());

            // Emitente
            pdfFormFields.SetField("EMITENTE_INSCRICAO_ESTADUAL", notaFiscal.Emitente.InscricaoEstadual);
            pdfFormFields.SetField("EMITENTE_CNPJ", notaFiscal.Emitente.CNPJ.Numero);

            // Destinatário
            pdfFormFields.SetField("DESTINATARIO_NOME", notaFiscal.Destinatario.NomeRazaoSocial);
            pdfFormFields.SetField("DESTINATARIO_RUA", notaFiscal.Destinatario.Endereco.Logradouro + " nº " + notaFiscal.Destinatario.Endereco.Numero);
            pdfFormFields.SetField("DESTINATARIO_MUNICIPIO", notaFiscal.Destinatario.Endereco.Municipio);
            pdfFormFields.SetField("DESTINATARIO_ESTADO", notaFiscal.Destinatario.Endereco.Estado);
            pdfFormFields.SetField("DESTINATARIO_BAIRRO", notaFiscal.Destinatario.Endereco.Bairro);
            pdfFormFields.SetField("DESTINATARIO_DOCUMENTO", notaFiscal.Destinatario.Documento.Numero);
            pdfFormFields.SetField("DESTINATARIO_INSCRICAO_ESTADUAL", notaFiscal.Destinatario.InscricaoEstadual);

            // Transportador
            pdfFormFields.SetField("TRANSPORTADOR_NOME", notaFiscal.Transportador.NomeRazaoSocial);
            pdfFormFields.SetField("TRANSPORTADOR_RUA", notaFiscal.Transportador.Endereco.Logradouro + " nº " + notaFiscal.Transportador.Endereco.Numero);
            pdfFormFields.SetField("TRANSPORTADOR_RESPONSABILIDADE_FRETE", notaFiscal.Transportador.ResponsabilidadeFrete ? "Sim" : "Não");
            pdfFormFields.SetField("TRANSPORTADOR_MUNICIPIO", notaFiscal.Transportador.Endereco.Municipio);
            pdfFormFields.SetField("TRANSPORTADOR_ESTADO", notaFiscal.Transportador.Endereco.Estado);
            pdfFormFields.SetField("TRANSPORTADOR_DOCUMENTO", notaFiscal.Transportador.Documento.Numero);

            // Valores
            pdfFormFields.SetField("VALOR_TOTAL_IPI", notaFiscal.ValorTotalIPI.ToString());
            pdfFormFields.SetField("VALOR_ICMS", notaFiscal.ValorTotalICMS.ToString());
            pdfFormFields.SetField("VALOR_FRETE", notaFiscal.ValorTotalFrete.ToString());
            pdfFormFields.SetField("VALOR_TOTAL_PRODUTOS", notaFiscal.ValorTotalProdutos.ToString());
            pdfFormFields.SetField("VALOR_TOTAL_NOTA", notaFiscal.ValorTotalNota.ToString());

            // Produtos
            for (int i = 0; i < notaFiscal.Produtos.Count(); i++)
            {
                string produtoNumero = "PRODUTO";
                produtoNumero = string.Concat(produtoNumero + (i+1).ToString());

                pdfFormFields.SetField(produtoNumero + "_CODIGO", notaFiscal.Produtos[i].Produto.Codigo);
                pdfFormFields.SetField(produtoNumero + "_DESCRICAO", notaFiscal.Produtos[i].Produto.Descricao);
                pdfFormFields.SetField(produtoNumero + "_QUANTIDADE", notaFiscal.Produtos[i].Quantidade.ToString());
                pdfFormFields.SetField(produtoNumero + "_VALOR_UNITARIO", notaFiscal.Produtos[i].Produto.Valor.ToString());
                pdfFormFields.SetField(produtoNumero + "_VALOR_TOTAL", notaFiscal.Produtos[i].ValorTotal.ToString());
                pdfFormFields.SetField(produtoNumero + "_VALOR_ICMS", notaFiscal.Produtos[i].ValorICMS.ToString());
                pdfFormFields.SetField(produtoNumero + "_ALIQ_ICMS", (notaFiscal.Produtos[i].Produto.AliquotaICMS*100).ToString());
                pdfFormFields.SetField(produtoNumero + "_ALIQ_IPI", (notaFiscal.Produtos[i].Produto.AliquotaIPI*100).ToString());

                if (i == 3) break; // O modelo só possui uma página e esta página só suporta quatro produtos listados simultaneamente
            }

            // Configura a propriedade para desabilitar edição
            pdfStamper.FormFlattening = true;

            // Fecha o PDF
            pdfStamper.Close();
        }
    }
}

using NFe.Infra.XML.Features.NotasFiscais;
using NFe.Infra.XML.Features.NotasFiscais.Modelos;
using Projeto_NFe.Domain.Funcionalidades.Documentos.CNPJs;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.XML.Funcionalidades.Nota_Fiscal.Mapeadores
{
    public class NotaFiscalParaNotaFiscalXMLModelo
    {
        public static NotaFiscalModeloXml MontarNotaFiscalXMLModelo(NotaFiscal notaFiscal)
        {
            NotaFiscalModeloXml notaFiscalModeloXML = new NotaFiscalModeloXml();
            notaFiscalModeloXML.infNFe = MontarInfNFEXMLModelo(notaFiscal);

            return notaFiscalModeloXML;
        }

        private static InfNFeConfiguracao MontarInfNFEXMLModelo(NotaFiscal notaFiscal)
        {
            InfNFeConfiguracao infNFeConf = new InfNFeConfiguracao();
            infNFeConf.ChaveAcesso = notaFiscal.ChaveAcesso;
            infNFeConf.Versao = "3.10";
            infNFeConf.dest = MontarDestinatarioConfiguracao(notaFiscal);
            infNFeConf.emit = MontarEmitenteConfiguracao(notaFiscal);
            infNFeConf.det = MontarListaDeProdutosConfiguracao(notaFiscal);
            infNFeConf.ide = MontarIdeConfiguracao(notaFiscal);
            infNFeConf.total = MontarTotalConfiguracao(notaFiscal);
            infNFeConf.transp = MontarTransportadoraConfiguracao(notaFiscal);

            return infNFeConf;
        }

        private static TransportadorConfiguracao MontarTransportadoraConfiguracao(NotaFiscal notaFiscal)
        {
            TransportadorConfiguracao transportadorConfiguracao = new TransportadorConfiguracao();
            transportadorConfiguracao.Transporta.CnpjDestinatario = notaFiscal.Destinatario.Documento.Numero;
            transportadorConfiguracao.Transporta.Estado = notaFiscal.Transportador.Endereco.Estado;
            transportadorConfiguracao.Transporta.InscricaoEstadual = notaFiscal.Transportador.InscricaoEstadual;
            transportadorConfiguracao.Transporta.Logradouro = notaFiscal.Transportador.Endereco.Logradouro;
            transportadorConfiguracao.Transporta.Municipio = notaFiscal.Transportador.Endereco.Municipio;
            transportadorConfiguracao.Transporta.Nome = notaFiscal.Transportador.NomeRazaoSocial;
            transportadorConfiguracao.modFrete = Convert.ToInt32(notaFiscal.Transportador.ResponsabilidadeFrete);

            return transportadorConfiguracao;
        }

        private static TotalConfiguracao MontarTotalConfiguracao(NotaFiscal notaFiscal)
        {
            TotalConfiguracao totalConfiguracao = new TotalConfiguracao();
            totalConfiguracao.ICMSTot.ValorIcms = notaFiscal.ValorTotalICMS;
            totalConfiguracao.ICMSTot.ValorIpi = notaFiscal.ValorTotalIPI;
            totalConfiguracao.ICMSTot.ValorFrete = notaFiscal.ValorTotalFrete;
            totalConfiguracao.ICMSTot.ValorProdutos = notaFiscal.ValorTotalProdutos;
            totalConfiguracao.ICMSTot.ValorTotalNota = notaFiscal.ValorTotalNota;

            return totalConfiguracao;
        }

        private static IdeConfiguracao MontarIdeConfiguracao(NotaFiscal notafiscal)
        {
            IdeConfiguracao ideConfiguracao = new IdeConfiguracao();
            ideConfiguracao.DataEmissao = (DateTime)notafiscal.DataEmissao;
            ideConfiguracao.NaturezaOperacao = notafiscal.NaturezaOperacao;

            return ideConfiguracao;
        }

        private static DestinatarioConfiguracao MontarDestinatarioConfiguracao(NotaFiscal notaFiscal)
        {
            DestinatarioConfiguracao destinatarioConfiguracao = new DestinatarioConfiguracao();

            if (notaFiscal.Destinatario.Documento.GetType() == typeof(CNPJ))
            {
                destinatarioConfiguracao.CnpjDestinatario = notaFiscal.Destinatario.Documento.Numero;
            }
            else
            {
                destinatarioConfiguracao.CpfDestinatario = notaFiscal.Destinatario.Documento.Numero;
            }
            destinatarioConfiguracao.enderDest = MontarEnderecoDestinatarioConfiguracao(notaFiscal);

            destinatarioConfiguracao.InscricaoEstadual = notaFiscal.Destinatario.InscricaoEstadual;
            destinatarioConfiguracao.Nome = notaFiscal.Destinatario.NomeRazaoSocial;

            return destinatarioConfiguracao;
        }

        private static EmitenteConfiguracao MontarEmitenteConfiguracao(NotaFiscal notaFiscal)
        {
            EmitenteConfiguracao emitConfiguracao = new EmitenteConfiguracao();

            emitConfiguracao.CnpjEmitente = notaFiscal.Emitente.CNPJ.Numero;
            emitConfiguracao.InscricaoEstadual = notaFiscal.Emitente.InscricaoEstadual;
            emitConfiguracao.InscricaoMunicipal = notaFiscal.Emitente.InscricaoMunicipal;
            emitConfiguracao.Nome = notaFiscal.Emitente.NomeFantasia;
            emitConfiguracao.RazaoSocial = notaFiscal.Emitente.RazaoSocial;
            emitConfiguracao.enderEmit = MontarEnderecoEmitenteConfiguracao(notaFiscal);

            return emitConfiguracao;
        }

        private static EnderecoConfiguracao MontarEnderecoDestinatarioConfiguracao(NotaFiscal notaFiscal)
        {
            EnderecoConfiguracao enderDestConfiguracao = new EnderecoConfiguracao();

            enderDestConfiguracao.Numero = notaFiscal.Destinatario.Endereco.Numero;
            enderDestConfiguracao.Logradouro = notaFiscal.Destinatario.Endereco.Logradouro;
            enderDestConfiguracao.Municipio = notaFiscal.Destinatario.Endereco.Municipio;
            enderDestConfiguracao.Estado = notaFiscal.Destinatario.Endereco.Estado;
            enderDestConfiguracao.Bairro = notaFiscal.Destinatario.Endereco.Bairro;
            enderDestConfiguracao.Pais = notaFiscal.Destinatario.Endereco.Pais;

            return enderDestConfiguracao;
        }

        private static EnderecoConfiguracao MontarEnderecoEmitenteConfiguracao(NotaFiscal notaFiscal)
        {
            EnderecoConfiguracao enderDestConfiguracao = new EnderecoConfiguracao();

            enderDestConfiguracao.Numero = notaFiscal.Emitente.Endereco.Numero;
            enderDestConfiguracao.Logradouro = notaFiscal.Emitente.Endereco.Logradouro;
            enderDestConfiguracao.Municipio = notaFiscal.Emitente.Endereco.Municipio;
            enderDestConfiguracao.Estado = notaFiscal.Emitente.Endereco.Estado;
            enderDestConfiguracao.Bairro = notaFiscal.Emitente.Endereco.Bairro;
            enderDestConfiguracao.Pais = notaFiscal.Emitente.Endereco.Pais;

            return enderDestConfiguracao;
        }

        private static List<ProdutoConfiguracao> MontarListaDeProdutosConfiguracao(NotaFiscal notaFiscal)
        {
            List<ProdutoConfiguracao> listaProdutos = new List<ProdutoConfiguracao>();

            for (int i = 0; i < notaFiscal.Produtos.Count; i++)
            {
                ProdutoNotaFiscal produtoNotaFiscal = notaFiscal.Produtos.ToList()[i];
                ProdutoConfiguracao produto = new ProdutoConfiguracao();
                produto.Imposto = MontarImpostoConfiguracao(produtoNotaFiscal);
                produto.nItemNumber = i + 1;
                produto.Prod = MontarProdutoConfiguracao(produtoNotaFiscal);

                listaProdutos.Add(produto);
            }

            return listaProdutos;
        }

        private static ProdConfiguracao MontarProdutoConfiguracao(ProdutoNotaFiscal produtoNotaFiscal)
        {
            ProdConfiguracao prodConfiguracao = new ProdConfiguracao();
            prodConfiguracao.CodigoProduto = produtoNotaFiscal.Produto.Codigo;
            prodConfiguracao.DescricaoProduto = produtoNotaFiscal.Produto.Descricao;
            prodConfiguracao.Quantidade = produtoNotaFiscal.Quantidade;
            prodConfiguracao.Total = produtoNotaFiscal.ValorTotal;
            prodConfiguracao.Unitario = produtoNotaFiscal.Produto.Valor;

            return prodConfiguracao;
        }

        private static ImpostoConfiguracao MontarImpostoConfiguracao(ProdutoNotaFiscal produtoNotaFiscal)
        {
            ImpostoConfiguracao impostoConfiguracao = new ImpostoConfiguracao();
            IcmsProduto icmsProduto = new IcmsProduto();
            Icms icms = new Icms();
            icms.IcmsProduto = icmsProduto;
            icmsProduto.AliquotaICMS = produtoNotaFiscal.Produto.AliquotaICMS * 100;
            icmsProduto.ValorICMS = produtoNotaFiscal.ValorICMS;
            impostoConfiguracao.Icms = icms;

            return impostoConfiguracao;
        }
    }
}

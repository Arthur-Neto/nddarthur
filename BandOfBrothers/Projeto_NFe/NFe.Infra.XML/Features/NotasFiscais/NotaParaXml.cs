using NFe.Dominio.Features.Notas_Fiscais;
using NFe.Infra.XML.Features.NotasFiscais.Modelos;
using System;
using System.Collections.Generic;

namespace NFe.Infra.XML.Features.NotasFiscais
{
    public class NotaParaXml
    {
        public List<ProdutoConfiguracao> GeraValoresProdutoXml(NotaFiscal _notaFiscal)
        {
            List<ProdutoConfiguracao> det = new List<ProdutoConfiguracao>();

            int i = 1;

            foreach (var produto in _notaFiscal.Produtos)
            {
                ProdutoConfiguracao produtoConfiguracao = new ProdutoConfiguracao();

                produtoConfiguracao.Prod.CodigoProduto = produto.CodigoProduto;
                produtoConfiguracao.Prod.DescricaoProduto = "Trib ICMS Integral Aliquota 10.00 - PIS e COFINS cod 04 - Orig 0";
                produtoConfiguracao.Prod.Quantidade = produto.Quantidade;
                produtoConfiguracao.Prod.Total = produto.ValorProduto.Total;
                produtoConfiguracao.Prod.Unitario = produto.ValorProduto.Unitario;
                produtoConfiguracao.nItemNumber = i;
                produtoConfiguracao.Imposto.Icms.IcmsProduto.Icms = produto.ValorProduto.ICMS;
                produtoConfiguracao.Imposto.Icms.IcmsProduto.Ipi = produto.ValorProduto.Ipi;

                det.Add(produtoConfiguracao);

                i++;
            }

            return det;
        }

        public DestinatarioConfiguracao GeraValoresParaDestinatarioXml(NotaFiscal _notaFiscal)
        {
            DestinatarioConfiguracao DestinatarioConfiguracao = new DestinatarioConfiguracao();

            if (_notaFiscal.Destinatario.Cnpj.valorFormatado != "")
                DestinatarioConfiguracao.CnpjDestinatario = _notaFiscal.Destinatario.Cnpj.valorFormatado;
            else
                DestinatarioConfiguracao.CpfDestinatario = _notaFiscal.Destinatario.Cpf.valorFormatado;

            if (_notaFiscal.Destinatario.Nome != "")
                DestinatarioConfiguracao.Nome = _notaFiscal.Destinatario.Nome;
            else
                DestinatarioConfiguracao.Nome = _notaFiscal.Destinatario.RazaoSocial;

            DestinatarioConfiguracao.InscricaoEstadual = _notaFiscal.Destinatario.InscricaoEstadual;
            DestinatarioConfiguracao.enderDest.Estado = _notaFiscal.Destinatario.Endereco.Estado;
            DestinatarioConfiguracao.enderDest.Logradouro = _notaFiscal.Destinatario.Endereco.Logradouro;
            DestinatarioConfiguracao.enderDest.Municipio = _notaFiscal.Destinatario.Endereco.Municipio;
            DestinatarioConfiguracao.enderDest.Numero = _notaFiscal.Destinatario.Endereco.Numero;
            DestinatarioConfiguracao.enderDest.Pais = _notaFiscal.Destinatario.Endereco.Pais;
            DestinatarioConfiguracao.enderDest.Bairro = _notaFiscal.Destinatario.Endereco.Bairro;

            return DestinatarioConfiguracao;
        }

        public EmitenteConfiguracao GeraValoresParaEmitenteXml(NotaFiscal _notaFiscal)
        {
            EmitenteConfiguracao EmitenteConfiguracao = new EmitenteConfiguracao();

            EmitenteConfiguracao.CnpjEmitente = _notaFiscal.Emitente.Cnpj.valorFormatado;

            EmitenteConfiguracao.RazaoSocial = _notaFiscal.Emitente.RazaoSocial;
            EmitenteConfiguracao.Nome = _notaFiscal.Emitente.Nome;

            EmitenteConfiguracao.InscricaoEstadual = _notaFiscal.Emitente.InscricaoEstadual;
            EmitenteConfiguracao.InscricaoMunicipal = _notaFiscal.Emitente.InscricaoMunicipal;
            EmitenteConfiguracao.enderDest.Estado = _notaFiscal.Emitente.Endereco.Estado;
            EmitenteConfiguracao.enderDest.Logradouro = _notaFiscal.Emitente.Endereco.Logradouro;
            EmitenteConfiguracao.enderDest.Municipio = _notaFiscal.Emitente.Endereco.Municipio;
            EmitenteConfiguracao.enderDest.Numero = _notaFiscal.Emitente.Endereco.Numero;
            EmitenteConfiguracao.enderDest.Pais = _notaFiscal.Emitente.Endereco.Pais;
            EmitenteConfiguracao.enderDest.Bairro = _notaFiscal.Emitente.Endereco.Bairro;

            return EmitenteConfiguracao;
        }

        public InfNFeConfiguracao GeraValoresParaInfNFeXml(NotaFiscal _notaFiscal)
        {
            InfNFeConfiguracao InfNFeConfiguracao = new InfNFeConfiguracao();
            InfNFeConfiguracao.ChaveAcesso = "NFe" + _notaFiscal.ChaveAcesso;
            InfNFeConfiguracao.Versao = "3.10";

            return InfNFeConfiguracao;
        }

        public IdeConfiguracao GeraValoresParaIdeNFeXml(NotaFiscal _notaFiscal)
        {
            IdeConfiguracao InfNFeConfiguracao = new IdeConfiguracao();

            InfNFeConfiguracao.NaturezaOperacao = _notaFiscal.NaturezaOperacao;
            if (_notaFiscal.DataEmissao == null)
                _notaFiscal.DataEmissao = DateTime.Now;
            InfNFeConfiguracao.DataEmissao = (DateTime)_notaFiscal.DataEmissao;

            return InfNFeConfiguracao;
        }

        public ICMSTotConfiguracao GeraValoresParaIcmsTotalXml(NotaFiscal _notaFiscal)
        {
            ICMSTotConfiguracao ICMSTotConfiguracao = new ICMSTotConfiguracao();

            ICMSTotConfiguracao.ValorFrete = _notaFiscal.Valor.Frete;
            ICMSTotConfiguracao.ValorIcms = _notaFiscal.Valor.ICMS;
            ICMSTotConfiguracao.ValorIpi = _notaFiscal.Valor.Ipi;
            ICMSTotConfiguracao.ValorProdutos = _notaFiscal.Valor.TotalProdutos;
            ICMSTotConfiguracao.ValorTotalNota = _notaFiscal.Valor.TotalNota;

            return ICMSTotConfiguracao;
        }

        public TransportadorConfiguracao GeraValoresParaTransportadorXml(NotaFiscal _notaFiscal)
        {
            TransportadorConfiguracao TransportadorConfiguracao = new TransportadorConfiguracao();

            TransportadorConfiguracao.modFrete = (int)_notaFiscal.Transportador.ResponsabilidadeFrete;
            if (string.IsNullOrEmpty(_notaFiscal.Transportador.Cpf))
                TransportadorConfiguracao.Transporta.CnpjDestinatario = _notaFiscal.Transportador.Cnpj.valorFormatado;
            else
                TransportadorConfiguracao.Transporta.CnpjDestinatario = _notaFiscal.Transportador.Cpf.valorFormatado;
            TransportadorConfiguracao.Transporta.Estado = _notaFiscal.Transportador.Endereco.Estado;
            TransportadorConfiguracao.Transporta.InscricaoEstadual = _notaFiscal.Transportador.InscricaoEstadual;
            TransportadorConfiguracao.Transporta.Logradouro = _notaFiscal.Transportador.Endereco.Logradouro;
            TransportadorConfiguracao.Transporta.Municipio = _notaFiscal.Transportador.Endereco.Municipio;
            if (string.IsNullOrEmpty(_notaFiscal.Transportador.Nome))
                TransportadorConfiguracao.Transporta.Nome = _notaFiscal.Transportador.RazaoSocial;
            else
                TransportadorConfiguracao.Transporta.Nome = _notaFiscal.Transportador.Nome;

            return TransportadorConfiguracao;
        }
    }
}

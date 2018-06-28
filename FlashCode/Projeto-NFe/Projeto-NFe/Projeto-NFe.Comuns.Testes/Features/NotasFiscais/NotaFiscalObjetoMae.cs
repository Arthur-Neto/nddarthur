using Projeto_NFe.Comuns.Testes.Features.Destinatarios;
using Projeto_NFe.Comuns.Testes.Features.Emitentes;
using Projeto_NFe.Comuns.Testes.Features.Produtos;
using Projeto_NFe.Comuns.Testes.Features.ProdutosNFe;
using Projeto_NFe.Comuns.Testes.Features.Transportadores;
using Projeto_NFe.Dominio.Features.Impostos;
using Projeto_NFe.Dominio.Features.NotasFiscais;
using Projeto_NFe.Dominio.Features.Produtos;
using Projeto_NFe.Dominio.Features.ProdutosNFe;
using System;
using System.Collections.Generic;

namespace Projeto_NFe.Comuns.Testes.Features.NotasFiscais
{
    public static class NotaFiscalObjetoMae
    {
        public static NotaFiscal ObterValidoNotaFiscal()
        {
            return new NotaFiscal
            {
                ID = 1,
                Chave = "2241 6012 5845 2734 4330 8800 6670 2528 4401 3375 0538",
                ValorFrete = 45,
                NaturezaOperacao = "Gestão, Consulta e Downloads de NFs",
                Produtos = PegarListaProdutos(),
                ValorTotalNota = 1500,
                DataEntrada = DateTime.Now.AddDays(1),
                DataEmissao = DateTime.Now.AddDays(2),
                Destinatario = DestinatarioObjetoMae.ObterValidoEmpresa(),
                Transportador = TransportadorObjetoMae.ObterValidoEmpresa(),
                Emitente = EmitenteObjetoMae.ObterValido()
            };

        }
        public static NotaFiscal ObterValidoNotaFiscalTransportadorPessoa()
        {
            return new NotaFiscal
            {
                ID = 1,
                Chave = "2241 6012 5845 2734 4330 8800 6670 2528 4401 3375 0538",
                ValorFrete = 45,
                NaturezaOperacao = "Gestão, Consulta e Downloads de NFs",
                Produtos = PegarListaProdutos(),
                ValorTotalNota = 1500,
                DataEntrada = DateTime.Now.AddDays(1),
                DataEmissao = DateTime.Now.AddDays(2),
                Destinatario = DestinatarioObjetoMae.ObterValidoPessoa(),
                Transportador = TransportadorObjetoMae.ObterValidoPessoa(),
                Emitente = EmitenteObjetoMae.ObterValido()
            };

        }


        private static List<ProdutoNfe> PegarListaProdutos()
        {
            List<ProdutoNfe> lista = new List<ProdutoNfe>();
            ProdutoNfe nfe = new ProdutoNfe();
            nfe.ID = 1;
            nfe.Descricao = "Descrição produto 1";
            nfe.CodigoProduto = "111111";
            nfe.Quantidade = 11;
            nfe.ValorUnitario = 111;
            nfe.Imposto = new Imposto(nfe);
            nfe.Imposto.ValorICMS = 11111111;
            nfe.Imposto.ValorIPI = 1111;
            lista.Add(nfe);
            return lista;
        }
    }
}

using NUnit.Framework;
using Projeto_NFe.Infrastructure.PDF.Funcionalidades.Nota_Fiscal;
using System;
using System.Collections.Generic;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using Projeto_NFe.Domain.Funcionalidades.Produtos;
using Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais;
using System.IO;
using FluentAssertions;
using Projeto_NFe.Common.Tests.Funcionalidades;
using Projeto_NFe.Domain.Funcionalidades.Documentos;

namespace Projeto_NFe.Infrastructure.PDF.Tests.Funcionalidades.Nota_Fiscal
{
    [TestFixture]
    public class NotaFiscalParaPDFTeste
    {

        NotaFiscal _notaFiscal;
        string _caminhoParaANovaNotaFiscal = @"..\..\..\NotaFiscal.pdf";


        [SetUp]
        public void IniciarCenario()
        {
            Endereco enderecoEmitente = ObjectMother.PegarEnderecoValido();
            Endereco enderecoDestinatario = ObjectMother.PegarEnderecoValido();
            Endereco enderecoTransportador = ObjectMother.PegarEnderecoValido();

            Emitente emitente = ObjectMother.PegarEmitenteValido(enderecoEmitente, new Documento("99.327.235/0001-50", TipoDocumento.CNPJ));
            Destinatario destinatario = ObjectMother.PegarDestinatarioValidoComCNPJ(enderecoDestinatario, new Documento("13.106.137/0001-77", TipoDocumento.CNPJ));
            Transportador transportador = ObjectMother.PegarTransportadorValidoComCNPJ(enderecoTransportador, new Documento("11.222.333/0001-81", TipoDocumento.CNPJ));

            _notaFiscal = ObjectMother.PegarNotaFiscalValida(emitente, destinatario, transportador);

            Produto produto = ObjectMother.ObterProdutoValido();
            ProdutoNotaFiscal produtoNotaFiscal = ObjectMother.PegarProdutoNotaFiscalValido(produto, _notaFiscal);

            _notaFiscal.Produtos = new List<ProdutoNotaFiscal>();
            _notaFiscal.Produtos.Add(produtoNotaFiscal);

            _notaFiscal.CalcularValoresTotais();
            _notaFiscal.GerarChaveDeAcesso(new Random());
            _notaFiscal.DataEmissao = DateTime.Now;
        }

        [Test]
        public void NotaFiscal_InfraPDF_Exportar_Sucesso()
        {
            NotaFiscalRepositorioPDF gerador = new NotaFiscalRepositorioPDF();
            gerador.Exportar(_caminhoParaANovaNotaFiscal, _notaFiscal);

            Action acaoParaVerificarSeArquivoExiste = () => File.Exists(_caminhoParaANovaNotaFiscal);

            acaoParaVerificarSeArquivoExiste.Should().Equals(true);

            File.Delete(_caminhoParaANovaNotaFiscal);

        }

        [Test]
        public void NotaFiscal_InfraPDF_Exportar_Com5Produtos_Sucesso()
        {
            Produto produto = ObjectMother.ObterProdutoValido();
            ProdutoNotaFiscal produtoNotaFiscal = ObjectMother.PegarProdutoNotaFiscalValido(produto, _notaFiscal);

            _notaFiscal.Produtos = new List<ProdutoNotaFiscal>();
            _notaFiscal.Produtos.Add(produtoNotaFiscal);
            _notaFiscal.Produtos.Add(produtoNotaFiscal);
            _notaFiscal.Produtos.Add(produtoNotaFiscal);
            _notaFiscal.Produtos.Add(produtoNotaFiscal);
            _notaFiscal.Produtos.Add(produtoNotaFiscal);

            _notaFiscal.CalcularValoresTotais();
            _notaFiscal.GerarChaveDeAcesso(new Random());
            _notaFiscal.DataEmissao = DateTime.Now;

            NotaFiscalRepositorioPDF gerador = new NotaFiscalRepositorioPDF();
            gerador.Exportar(_caminhoParaANovaNotaFiscal, _notaFiscal);

            Action acaoParaVerificarSeArquivoExiste = () => File.Exists(_caminhoParaANovaNotaFiscal);

            acaoParaVerificarSeArquivoExiste.Should().Equals(true);

            File.Delete(_caminhoParaANovaNotaFiscal);

        }

    }
}

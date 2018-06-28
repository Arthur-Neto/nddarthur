using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Comuns.Testes.Features.NotasFiscais;
using Projeto_NFe.Dominio.Features.NotasFiscais;
using Projeto_NFe.Dominio.Features.NotasFiscais.Excecoes;
using Projeto_NFe.Dominio.Features.Produtos;
using System;
using System.Collections.Generic;

namespace Projeto_NFe.Dominio.Testes.Features.NotasFiscais
{
    [TestFixture]
    public class NotaFiscalDominioTestes
    {
        NotaFiscal _notaFiscal;
        private Mock<Random> _mockRandom;
        private int _numeroSorteado = 1;
        private int _numeroRandomicoInicio = 0;
        private int _numeroRandomicoFim = 9;

        [SetUp]
        public void SetUp()
        {
            _notaFiscal = NotaFiscalObjetoMae.ObterValidoNotaFiscal();
            _mockRandom = new Mock<Random>();
        }

        [Test]
        public void NotaFiscal_Dominio_NotaFiscal_Validar_EsperadoOK()
        {
            Action action = () => _notaFiscal.Validar();
            action.Should().NotThrow();
        }

        [Test]
        public void NotaFiscal_Dominio_NotaFiscal_Validar_Transportador_Vazio_EsperadoOk()
        {
            _notaFiscal.Transportador = null;

            Action action = () => _notaFiscal.Validar();

            action.Should().NotThrow();
            _notaFiscal.Transportador.Cpf.Should().Be(_notaFiscal.Destinatario.Cpf);
            _notaFiscal.Transportador.Cnpj.Should().Be(_notaFiscal.Destinatario.Cnpj);
        }

        [Test]
        public void NotaFiscal_Dominio_NotaFiscal_Calcular_ValorTotalNota_EsperadoOk()
        {
            Action action = () => _notaFiscal.CalcularValorTotalNota();
            action.Should().NotThrow();
            _notaFiscal.ValorTotalNota.Should().BeGreaterThan(0);
        }

        [Test]
        public void NotaFiscal_Dominio_NotaFiscal_Validar_ValorTotalNota_Negativo_EsperadoFalha()
        {
            _notaFiscal.ValorTotalNota = -1;

            Action action = () => _notaFiscal.Validar();
            action.Should().Throw<ExcecaoValorTotalInvalido>();
        }

        [Test]
        public void NotaFiscal_Dominio_NotaFiscal_Validar_NaturezaOperacao_Vazio_EsperadoFalha()
        {
            _notaFiscal.NaturezaOperacao = String.Empty;

            Action action = () => _notaFiscal.Validar();
            action.Should().Throw<ExcecaoNaturezaOperacaoVazia>();
        }

        [Test]
        public void NotaFiscal_Dominio_NotaFiscal_Validar_DataEntrada_Invalida_EsperadoFalha()
        {
            _notaFiscal.DataEntrada = DateTime.Now.AddDays(-1);

            Action action = () => _notaFiscal.Validar();
            action.Should().Throw<ExcecaoDataEntradaInvalida>();
        }

        [Test]
        public void NotaFiscal_Dominio_NotaFiscal_Validar_DataEmissao_Invalida_EsperadoFalha()
        {
            _notaFiscal.DataEmissao = DateTime.Now.AddDays(-1);

            Action action = () => _notaFiscal.Validar();
            action.Should().Throw<ExcecaoDataEmissaoInvalida>();
        }

        [Test]
        public void NotaFiscal_Dominio_NotaFiscal_Validar_ChaveAcesso_Invalida_EsperadoFalha()
        {
            _notaFiscal.Chave = String.Empty;

            Action action = () => _notaFiscal.Validar();
            action.Should().Throw<ExcecaoChaveInvalida>();
        }

        [Test]
        public void NotaFiscal_Dominio_NotaFiscal_Validar_Destinatario_Nulo_EsperadoFalha()
        {
            _notaFiscal.Destinatario = null;

            Action action = () => _notaFiscal.Validar();
            action.Should().Throw<ExcecaoDestinatarioNulo>();
        }

        [Test]
        public void NotaFiscal_Dominio_NotaFiscal_Validar_Emitente_Nulo_EsperadoFalha()
        {
            _notaFiscal.Emitente = null;

            Action action = () => _notaFiscal.Validar();
            action.Should().Throw<ExcecaoEmitenteNulo>();
        }

        [Test]
        public void Teste_Dominio_NotaFiscal_Validar_Produtos_Vazio_EsperadoFalha()
        {
            _notaFiscal.Produtos = new List<ProdutoNfe>();

            Action action = () => _notaFiscal.Validar();
            action.Should().Throw<ExcecaoProdutosVazio>();
        }

        [Test]
        public void Teste_Dominio_NotaFiscal_GerarChave_EsperadoOK()
        {
            _mockRandom.Setup(r => r.Next(_numeroRandomicoInicio, _numeroRandomicoFim)).Returns(() => _numeroSorteado);

            Action action = () => _notaFiscal.GerarChave(_mockRandom.Object);

            action.Should().NotThrow();
            _notaFiscal.Chave.Should().NotBeNullOrEmpty();

        }

        [Test]
        public void Teste_Dominio_NotaFiscal_CalcularValorTotalProdutos_EsperadoOK()
        {
            _notaFiscal = NotaFiscalObjetoMae.ObterValidoNotaFiscal();

            double retorno = _notaFiscal.CalcularValorTotalProdutos();

            _notaFiscal.ValorTotalProdutos.Should().BeGreaterThan(0);
            retorno.Should().Be(_notaFiscal.ValorTotalProdutos);

        }

        [Test]
        public void Teste_Dominio_NotaFiscal_ObterValorTotalICMS_EsperadoOK()
        {
            _notaFiscal = NotaFiscalObjetoMae.ObterValidoNotaFiscal();

            Action action = ()=> _notaFiscal.ObterValorTotalICMS();

            action.Should().NotThrow();

        }

        [Test]
        public void Teste_Dominio_NotaFiscal_ObterICMS_EsperadoOK()
        {
            _notaFiscal = NotaFiscalObjetoMae.ObterValidoNotaFiscal();

            Action action = () => _notaFiscal.ObterICMS();

            action.Should().NotThrow();

        }

        [Test]
        public void Teste_Dominio_NotaFiscal_ObterIPI_EsperadoOK()
        {
            _notaFiscal = NotaFiscalObjetoMae.ObterValidoNotaFiscal();

            Action action = () => _notaFiscal.ObterIPI();

            action.Should().NotThrow();

        }
    }
}

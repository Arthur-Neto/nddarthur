using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Funcionalidades;
using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Documentos;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais;
using Projeto_NFe.Domain.Funcionalidades.Produtos;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using System;
using System.Collections.Generic;

namespace Projeto_NFe.Domain.Tests.Funcionalidades.Nota_Fiscal
{
    [TestFixture]
    public class NotaFiscalTeste
    {
        Mock<Transportador> _transportadorMock;
        Mock<Destinatario> _destinatarioMock;
        Mock<Emitente> _emitenteMock;
        Mock<Produto> _produtoMock;
        Mock<ProdutoNotaFiscal> _produtoNotaFiscal;
        Mock<Endereco> _enderecoMock;
        Mock<Documento> _cnpjMock;

        List<ProdutoNotaFiscal> _produtosNotaFiscal;
        NotaFiscal _notaFiscal;

        [SetUp]
        public void IniciarCenario()
        {
            _produtoMock = new Mock<Produto>();
            _transportadorMock = new Mock<Transportador>();
            _destinatarioMock = new Mock<Destinatario>();
            _emitenteMock = new Mock<Emitente>();
            _enderecoMock = new Mock<Endereco>();
            _produtoNotaFiscal = new Mock<ProdutoNotaFiscal>(_notaFiscal, _produtoMock.Object, 1);
            _produtosNotaFiscal = new List<ProdutoNotaFiscal>();
            _cnpjMock = new Mock<Documento>();
        }

        [Test]
        public void NotaFiscal_Dominio_TamanhoChaveDeAcessoDeveSer44_Sucesso()
        {
            Random sorteador = new Random();
            _notaFiscal.GerarChaveDeAcesso(sorteador);
            string chaveGerada = _notaFiscal.ChaveAcesso;

            chaveGerada.Length.Should().Be(44);
        }

        [Test]
        public void NotaFiscal_Dominio_CalcularValoresTotais_Sucesso()
        {
            Mock<ProdutoNotaFiscal> produtoNotaFiscal2 = new Mock<ProdutoNotaFiscal>(_notaFiscal, _produtoMock.Object, 1);
            _produtoNotaFiscal.Setup(pnf => pnf.ValorTotal).Returns(100);
            produtoNotaFiscal2.Setup(pnf => pnf.ValorTotal).Returns(50);
            _produtoNotaFiscal.Setup(pnf => pnf.ValorICMS).Returns(70);
            produtoNotaFiscal2.Setup(pnf => pnf.ValorICMS).Returns(40);
            _produtoNotaFiscal.Setup(pnf => pnf.ValorIPI).Returns(30);
            produtoNotaFiscal2.Setup(pnf => pnf.ValorIPI).Returns(50);
            _produtosNotaFiscal.Add(_produtoNotaFiscal.Object);
            _produtosNotaFiscal.Add(produtoNotaFiscal2.Object);
            _notaFiscal = ObjectMother.PegarNotaFiscalValidaComListaDeProdutos(_emitenteMock.Object, _destinatarioMock.Object, _transportadorMock.Object, _produtosNotaFiscal);

            _notaFiscal.ValorTotalFrete = 50;
            _notaFiscal.CalcularValoresTotais();

            _notaFiscal.ValorTotalProdutos.Should().Be(150);
            _notaFiscal.ValorTotalICMS.Should().Be(110);
            _notaFiscal.ValorTotalIPI.Should().Be(80);
            _notaFiscal.ValorTotalImpostos.Should().Be(190);
            _notaFiscal.ValorTotalNota.Should().Be(390);
        }

        [Test]
        public void NotaFiscal_Dominio_ValidarSeFoiEmitida_Sucesso()
        {
            _notaFiscal = ObjectMother.PegarNotaFiscalValida(_emitenteMock.Object, _destinatarioMock.Object, _transportadorMock.Object);
            _notaFiscal.ChaveAcesso = "11111111111111111111111111111111111171111111";
            _notaFiscal.FoiEmitida.Should().BeTrue();
        }

        [Test]
        public void NotaFiscal_Dominio_ValidarSeNaoFoiEmitida_Sucesso()
        {
            _notaFiscal = ObjectMother.PegarNotaFiscalValida(_emitenteMock.Object, _destinatarioMock.Object, _transportadorMock.Object);
            _notaFiscal.ChaveAcesso = "";
            _notaFiscal.FoiEmitida.Should().BeFalse();
        }

    }
}

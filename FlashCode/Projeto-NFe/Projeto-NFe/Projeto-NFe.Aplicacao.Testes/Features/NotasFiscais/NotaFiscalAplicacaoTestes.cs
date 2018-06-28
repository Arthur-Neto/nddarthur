using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Aplicacao.Features.NotasFiscais;
using Projeto_NFe.Comuns.Testes.Features.NotasFiscais;
using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Dominio.Features.Destinatarios;
using Projeto_NFe.Dominio.Features.Emitentes;
using Projeto_NFe.Dominio.Features.Enderecos;
using Projeto_NFe.Dominio.Features.NotasFiscais;
using Projeto_NFe.Dominio.Features.NotasFiscais.Excecoes;
using Projeto_NFe.Dominio.Features.Produtos;
using Projeto_NFe.Dominio.Features.ProdutosNFe;
using Projeto_NFe.Dominio.Features.Transportadores;
using Projeto_NFe.Infra.Data.Features.ProdutosNFe;
using System;
using System.Collections.Generic;

namespace Projeto_NFe.Aplicacao.Testes.Features.NotasFiscais
{
    [TestFixture]
    public class NotaFiscalAplicacaoTestes
    {
        private Mock<NotaFiscal> _mockNotaFiscal;
        private INotaFiscalServico _notaFiscalServico;
        private Mock<INotaFiscalRepositorio> _mockNotaFiscalRepositorio;
        private Mock<INotaFiscalExportacao> _mockExportacaoXML;
        private Mock<INotaFiscalExportacao> _mockExportacaoPDF;
        private Mock<IEnderecoRepositorio> _mockEnderecoRepositorio;
        private Mock<IEmitenteRepositorio> _mockEmitenteRepositorio;
        private Mock<IDestinatarioRepositorio> _mockDestinatarioRepositorio;
        private Mock<ITransportadorRepositorio> _mockTransportadorRepositorio;
        private Mock<IProdutoNFeRepositorio> _mockNfeRepositorio;
        private Random _random;

        NotaFiscal _notaFiscal;

        [SetUp]
        public void SetUp()
        {
            _notaFiscal = NotaFiscalObjetoMae.ObterValidoNotaFiscal();
            _mockNotaFiscal = new Mock<NotaFiscal>();
            _mockNfeRepositorio = new Mock<IProdutoNFeRepositorio>();
            _mockNotaFiscalRepositorio = new Mock<INotaFiscalRepositorio>();
            _mockExportacaoXML = new Mock<INotaFiscalExportacao>();
            _mockExportacaoPDF = new Mock<INotaFiscalExportacao>();
            _mockEnderecoRepositorio = new Mock<IEnderecoRepositorio>();
            _mockEmitenteRepositorio = new Mock<IEmitenteRepositorio>();
            _mockDestinatarioRepositorio = new Mock<IDestinatarioRepositorio>();
            _mockTransportadorRepositorio = new Mock<ITransportadorRepositorio>();
            _random = new Random();
            _notaFiscalServico = new NotaFiscalServico(
                _mockNotaFiscalRepositorio.Object, _mockExportacaoXML.Object,
                _mockExportacaoPDF.Object, _mockEnderecoRepositorio.Object,
                _mockEmitenteRepositorio.Object, _mockDestinatarioRepositorio.Object,
                _mockTransportadorRepositorio.Object,_mockNfeRepositorio.Object, _random);
        }

        [Test]
        public void NotaFiscal_Aplicacao_Inserir_EsperadoOK()
        {
            _mockNotaFiscalRepositorio
                .Setup(nfr => nfr.Inserir(_notaFiscal))
                .Returns(new NotaFiscal { ID = 1 });

            var notaFiscal = _notaFiscalServico.Inserir(_notaFiscal);

            _mockNotaFiscalRepositorio.Verify(nfr => nfr.Inserir(_notaFiscal));
            notaFiscal.ID.Should().BeGreaterThan(0);
        }

        [Test]
        public void Teste_Aplicacao_NotaFiscal_Emitir_ChaveRepetida_EsperadoOK()
        {
            _notaFiscal = NotaFiscalObjetoMae.ObterValidoNotaFiscal();
            bool retorno = false;

            _mockNotaFiscal.Setup(r => r.GerarChave(_random));
            _mockNotaFiscal.Setup(r => r.CalcularValorTotalNota());

            _mockNotaFiscalRepositorio.Setup(r => r.ValidarExistenciaPorChave(_notaFiscal.Chave))
    .Returns(() => retorno == false ? (retorno = true) : (retorno = false));

            _mockNotaFiscalRepositorio
               .Setup(nfr => nfr.InserirNotaFiscalEmitida(_notaFiscal));

            _mockNfeRepositorio
                .Setup(nf => nf.DeletarPorNotaFiscalID(1))
                .Returns(true);

            _mockNotaFiscalRepositorio.Setup(nfr => nfr.Deletar(1)).Returns(true);

            var notaFiscal = _notaFiscalServico.EmitirNota(_notaFiscal);


            _mockNotaFiscalRepositorio.Verify(nfr => nfr.InserirNotaFiscalEmitida(_notaFiscal));
            notaFiscal.Should().BeTrue();
        }
        [Test]
        public void NotaFiscal_Aplicacao_Obter_IDInvalido_EsperadoNulo()
        {
            long id = 234;

            _mockNotaFiscalRepositorio
                .Setup(dr => dr.ObterPorId(id));

            var notafiscal = _notaFiscalServico.ObterPorId(id);

            _mockNotaFiscalRepositorio.Verify(dr => dr.ObterPorId(id));
            notafiscal.Should().BeNull();
        }

        [Test]
        public void Teste_Aplicacao_NotaFiscal_ObterPorId_EsperadoOK()
        {
            _mockNotaFiscalRepositorio
                .Setup(nfr => nfr.ObterPorId(_notaFiscal.ID))
                .Returns(new NotaFiscal
                {
                    ID = 1,
                    Destinatario = new Destinatario { ID = 1 },
                    Emitente = new Emitente { ID = 1 },
                    Transportador = new Transportador { ID = 1 },
                });

            _mockDestinatarioRepositorio
                .Setup(dr => dr.ObterPorId(_notaFiscal.ID))
                .Returns(new Destinatario { Endereco = new Endereco { ID = 1 } });

            _mockEmitenteRepositorio
                .Setup(er => er.ObterPorId(_notaFiscal.ID))
                .Returns(new Emitente { Endereco = new Endereco { ID = 1 } });

            _mockTransportadorRepositorio
                .Setup(tr => tr.ObterPorId(_notaFiscal.ID))
                .Returns(new Transportador { Endereco = new Endereco { ID = 1 } });

            _mockEnderecoRepositorio
                .Setup(er => er.ObterPorId(_notaFiscal.ID))
                .Returns(new Endereco());

            var notaFiscal = _notaFiscalServico.ObterPorId(_notaFiscal.ID);

            _mockNotaFiscalRepositorio.Verify(nfr => nfr.ObterPorId(_notaFiscal.ID));
            notaFiscal.ID.Should().BeGreaterThan(0);
        }

        [Test]
        public void NotaFiscal_Aplicacao_ObterTodos_EsperadoOK()
        {
            _mockNotaFiscalRepositorio
                .Setup(nfr => nfr.ObterTodos())
                .Returns(new List<NotaFiscal> { new NotaFiscal
                {
                    ID = 1,
                    Destinatario = new Destinatario { ID = 1 },
                    Emitente = new Emitente{ ID = 1 },
                    Transportador = new Transportador{ ID = 1 }, }
                });

            _mockDestinatarioRepositorio
                .Setup(dr => dr.ObterPorId(_notaFiscal.ID))
                .Returns(new Destinatario { Endereco = new Endereco { ID = 1 } });

            _mockEmitenteRepositorio
                .Setup(er => er.ObterPorId(_notaFiscal.ID))
                .Returns(new Emitente { Endereco = new Endereco { ID = 1 } });

            _mockTransportadorRepositorio
                .Setup(tr => tr.ObterPorId(_notaFiscal.ID))
                .Returns(new Transportador { Endereco = new Endereco { ID = 1 } });

            _mockEnderecoRepositorio
                .Setup(er => er.ObterPorId(_notaFiscal.ID))
                .Returns(new Endereco());

            var notasFiscais = _notaFiscalServico.ObterTodos();

            _mockNotaFiscalRepositorio.Verify(nfr => nfr.ObterTodos());
            notasFiscais.Count.Should().BeGreaterThan(0);
        }


        [Test]
        public void NotaFiscal_Aplicacao_ObterTodos_RetornoNull_EsperadoOK()
        {
            _mockNotaFiscalRepositorio
                .Setup(nfr => nfr.ObterTodos());

            var notasFiscais = _notaFiscalServico.ObterTodos();

            _mockNotaFiscalRepositorio.Verify(nfr => nfr.ObterTodos());
            notasFiscais.Should().BeNull();
        }
        [Test]
        public void Teste_Aplicacao_NotaFiscal_Atualizar_EsperadoOK()
        {
            _notaFiscal.ValorFrete = 50;

            _mockNotaFiscalRepositorio
                .Setup(nfr => nfr.Atualizar(_notaFiscal))
                .Returns(new NotaFiscal { ValorFrete = 50 });

            var notaFiscal = _notaFiscalServico.Atualizar(_notaFiscal);

            _mockNotaFiscalRepositorio.Verify(nfr => nfr.Atualizar(_notaFiscal));
            notaFiscal.ValorFrete.Should().Be(_notaFiscal.ValorFrete);
        }

        [Test]
        public void NotaFiscal_Aplicacao_Deletar_EsperadoOK()
        {
            _mockNotaFiscalRepositorio
                .Setup(nfr => nfr.Deletar(_notaFiscal.ID))
                .Returns(true);


            _mockNfeRepositorio
                .Setup(nfr => nfr.DeletarPorNotaFiscalID(_notaFiscal.ID))
                .Returns(true);

            var result = _notaFiscalServico.Deletar(_notaFiscal.ID);

            _mockNotaFiscalRepositorio.Verify(nfr => nfr.Deletar(_notaFiscal.ID));
            result.Should().BeTrue();
        }

        [Test]
        public void NotaFiscal_Aplicacao_EmitirNota_EsperadoOK()
        {
            _mockNotaFiscalRepositorio
                .Setup(nfr => nfr.InserirNotaFiscalEmitida(_notaFiscal));

            _mockNotaFiscalRepositorio
                .Setup(nfr => nfr.Deletar(_notaFiscal.ID))
                .Returns(true);

            _mockNfeRepositorio
               .Setup(nfr => nfr.DeletarPorNotaFiscalID(_notaFiscal.ID))
               .Returns(true);

            var result = _notaFiscalServico.EmitirNota(_notaFiscal);

            _mockNotaFiscalRepositorio.Verify(nfr => nfr.InserirNotaFiscalEmitida(_notaFiscal));
            result.Should().BeTrue();
        }

        [Test]
        public void NotaFiscal_Aplicacao_ExportarNota_EsperadoOK()
        {
            _mockNotaFiscalRepositorio
                .Setup(nfr => nfr.ObterPorChave(_notaFiscal.Chave))
                .Returns(_notaFiscal);

            _mockExportacaoXML
                .Setup(xml => xml.Exportar(_notaFiscal))
                .Returns(true);

            _mockExportacaoPDF
                .Setup(pdf => pdf.Exportar(_notaFiscal))
                .Returns(true);

            _notaFiscalServico.ExportarNota(_notaFiscal);

            _mockNotaFiscalRepositorio.Verify(nfr => nfr.ObterPorChave(_notaFiscal.Chave));
            _mockExportacaoXML.Verify(xml => xml.Exportar(_notaFiscal));
            _mockExportacaoPDF.Verify(pdf => pdf.Exportar(_notaFiscal));
        }

        [Test]
        public void NotaFiscal_Aplicacao_Inserir_ValorTotalInvalido_EsperadoFalha()
        {
            _notaFiscal.ValorTotalNota = 0;

            Action action = () => _notaFiscalServico.Inserir(_notaFiscal);
            action.Should().Throw<ExcecaoValorTotalInvalido>();
        }

        [Test]
        public void NotaFiscal_Aplicacao_Inserir_NaturezaOperacaoVazia_EsperadoFalha()
        {
            _notaFiscal.NaturezaOperacao = String.Empty;

            Action action = () => _notaFiscalServico.Inserir(_notaFiscal);
            action.Should().Throw<ExcecaoNaturezaOperacaoVazia>();
        }

        [Test]
        public void NotaFiscal_Aplicacao_Inserir_DataEntradaInvalida_EsperadoFalha()
        {
            _notaFiscal.DataEntrada = DateTime.Now.AddDays(-1);

            Action action = () => _notaFiscalServico.Inserir(_notaFiscal);
            action.Should().Throw<ExcecaoDataEntradaInvalida>();
        }

        [Test]
        public void NotaFiscal_Aplicacao_Inserir_DataEmissaoInvalida_EsperadoFalha()
        {
            _notaFiscal.DataEmissao = DateTime.Now.AddDays(-1);

            Action action = () => _notaFiscalServico.Inserir(_notaFiscal);
            action.Should().Throw<ExcecaoDataEmissaoInvalida>();
        }

        [Test]
        public void NotaFiscal_Aplicacao_Inserir_ChaveAcessoInvalida_EsperadoFalha()
        {
            _notaFiscal.Chave = String.Empty;

            Action action = () => _notaFiscalServico.Inserir(_notaFiscal);
            action.Should().Throw<ExcecaoChaveInvalida>();
        }

        [Test]
        public void NotaFiscal_Aplicacao_Inserir_DestinatarioNulo_EsperadoFalha()
        {
            _notaFiscal.Destinatario = null;

            Action action = () => _notaFiscalServico.Inserir(_notaFiscal);
            action.Should().Throw<ExcecaoDestinatarioNulo>();
        }

        [Test]
        public void NotaFiscal_Aplicacao_Inserir_EmitenteNulo_EsperadoFalha()
        {
            _notaFiscal.Emitente = null;

            Action action = () => _notaFiscalServico.Inserir(_notaFiscal);
            action.Should().Throw<ExcecaoEmitenteNulo>();
        }

        [Test]
        public void NotaFiscal_Aplicacao_Inserir_ProdutosVazio_EsperadoFalha()
        {
            _notaFiscal.Produtos = new List<ProdutoNfe>();

            Action action = () => _notaFiscalServico.Inserir(_notaFiscal);
            action.Should().Throw<ExcecaoProdutosVazio>();
        }

        [Test]
        public void NotaFiscal_Aplicacao_Atualizar_IdentificadorInvalido_EsperadoFalha()
        {
            _notaFiscal.ID = 0;

            Action action = () => _notaFiscalServico.Atualizar(_notaFiscal);
            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void NotaFiscal_Aplicacao_Atualizar_ValorTotalInvalido_EsperadoFalha()
        {
            _notaFiscal.ValorTotalNota = 0;

            Action action = () => _notaFiscalServico.Atualizar(_notaFiscal);
            action.Should().Throw<ExcecaoValorTotalInvalido>();
        }

        [Test]
        public void NotaFiscal_Aplicacao_Atualizar_NaturezaOperacaoVazia_EsperadoFalha()
        {
            _notaFiscal.NaturezaOperacao = String.Empty;

            Action action = () => _notaFiscalServico.Atualizar(_notaFiscal);
            action.Should().Throw<ExcecaoNaturezaOperacaoVazia>();
        }

        [Test]
        public void NotaFiscal_Aplicacao_Atualizar_DataEntradaInvalida_EsperadoFalha()
        {
            _notaFiscal.DataEntrada = DateTime.Now.AddDays(-1);

            Action action = () => _notaFiscalServico.Atualizar(_notaFiscal);
            action.Should().Throw<ExcecaoDataEntradaInvalida>();
        }

        [Test]
        public void NotaFiscal_Aplicacao_Atualizar_DataEmissaoInvalida_EsperadoFalha()
        {
            _notaFiscal.DataEmissao = DateTime.Now.AddDays(-1);

            Action action = () => _notaFiscalServico.Atualizar(_notaFiscal);
            action.Should().Throw<ExcecaoDataEmissaoInvalida>();
        }

        [Test]
        public void NotaFiscal_Aplicacao_Atualizar_ChaveAcessoInvalida_EsperadoFalha()
        {
            _notaFiscal.Chave = String.Empty;

            Action action = () => _notaFiscalServico.Atualizar(_notaFiscal);
            action.Should().Throw<ExcecaoChaveInvalida>();
        }

        [Test]
        public void NotaFiscal_Aplicacao_Atualizar_DestinatarioNulo_EsperadoFalha()
        {
            _notaFiscal.Destinatario = null;

            Action action = () => _notaFiscalServico.Atualizar(_notaFiscal);
            action.Should().Throw<ExcecaoDestinatarioNulo>();
        }

        [Test]
        public void NotaFiscal_Aplicacao_Atualizar_EmitenteNulo_EsperadoFalha()
        {
            _notaFiscal.Emitente = null;

            Action action = () => _notaFiscalServico.Atualizar(_notaFiscal);
            action.Should().Throw<ExcecaoEmitenteNulo>();
        }

        [Test]
        public void NotaFiscal_Aplicacao_Atualizar_ProdutosVazio_EsperadoFalha()
        {
            _notaFiscal.Produtos = new List<ProdutoNfe>();

            Action action = () => _notaFiscalServico.Atualizar(_notaFiscal);
            action.Should().Throw<ExcecaoProdutosVazio>();
        }

        [Test]
        public void NotaFiscal_Aplicacao_Deletar_IdentificadorInvalido_EsperadoFalha()
        {
            _notaFiscal.ID = 0;

            Action action = () => _notaFiscalServico.Deletar(_notaFiscal.ID);
            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void NotaFiscal_Aplicacao_ObterPorId_IdentificadorInvalido_EsperadoFalha()
        {
            _notaFiscal.ID = 0;

            Action action = () => _notaFiscalServico.ObterPorId(_notaFiscal.ID);
            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }
    }
}

using FluentAssertions;
using Moq;
using NFe.Aplicacao.Features.Notas_Fiscais;
using NFe.Common.Testes.Features;
using NFe.Dominio.Exceptions;
using NFe.Dominio.Features.Notas_Fiscais;
using NFe.Infra.XML.Features.NotasFiscais;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NFe.Aplicacao.Testes.Features.Notas_Fiscais
{
    [TestFixture]
    public class NotaFiscalAplicacaoTeste
    {
        NotaFiscalServico notaFiscalServico;
        Mock<INotaFiscalRepositorio> mockRepositorio;

        [SetUp]
        public void SetUp()
        {
            mockRepositorio = new Mock<INotaFiscalRepositorio>();
            notaFiscalServico = new NotaFiscalServico(mockRepositorio.Object);
        }

        [Test]
        public void NotaFiscal_Aplicacao_Salvar_DeveInserirOk()
        {
            NotaFiscal nota = ObjectMother.ObterNotaValida();
            nota.Id = 1;
            mockRepositorio.Setup(x => x.Salvar(nota)).Returns(nota);
            mockRepositorio.Setup(x => x.PegarPorId(nota.Id)).Returns(nota);

            NotaFiscal novaNota = notaFiscalServico.Salvar(nota);

            novaNota.Id.Should().BeGreaterThan(0);
            mockRepositorio.Verify(x => x.Salvar(nota));
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void NotaFiscal_Aplicacao_Emitir_DeveEmitirOk()
        {
            NotaFiscal nota = ObjectMother.ObterNotaValida();
            mockRepositorio.Setup(x => x.Salvar(nota)).Returns(new NotaFiscal() { Id = 1, Emitido = true });

            NotaFiscal novaNota = notaFiscalServico.Emitir(nota);

            novaNota.Id.Should().BeGreaterThan(0);
            novaNota.Emitido.Should().BeTrue();
            mockRepositorio.Verify(x => x.Salvar(nota));
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void NotaFiscal_Aplicacao_Emitir_DeveJogarExcecaoNotaJaEmitida()
        {
            NotaFiscal nota = ObjectMother.ObterNotaValida();
            nota.Emitido = true;
            Action act = () => { notaFiscalServico.Emitir(nota); };
            act.Should().Throw<SalvarNotaJaEmitidaException>();
        }

        [Test]
        public void NotaFiscal_Aplicacao_Salvar_DeveJogarExcecaoAoSalvarNotaEmitida()
        {
            NotaFiscal nota = ObjectMother.ObterNotaValida();
            nota.Emitido = true;
            Action act = () => { notaFiscalServico.Salvar(nota); };
            act.Should().Throw<SalvarNotaJaEmitidaException>();
        }

        [Test]
        public void NotaFiscal_Aplicacao_Atualizar_DeveAtualizarOk()
        {
            NotaFiscal nota = ObjectMother.ObterNotaValida();
            var valorEsperado = "Retorno de mostruario";
            nota.Id = 1;
            nota.NaturezaOperacao = valorEsperado;
            mockRepositorio.Setup(x => x.Atualizar(nota)).Returns(nota);
            mockRepositorio.Setup(x => x.PegarPorId(nota.Id)).Returns(nota);

            NotaFiscal notaAtualizada = notaFiscalServico.Atualizar(nota);

            notaAtualizada.NaturezaOperacao.Should().Be(valorEsperado);
            mockRepositorio.Verify(x => x.Atualizar(nota));
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void NotaFiscal_Aplicacao_PegarPorId_DevePegarOk()
        {
            NotaFiscal nota = ObjectMother.ObterNotaValida();
            nota.Id = 1;
            mockRepositorio.Setup(x => x.PegarPorId(nota.Id)).Returns(nota);

            NotaFiscal notaObtida = notaFiscalServico.PegarPorId(nota.Id);

            notaObtida.Id.Should().BeGreaterThan(0);
            mockRepositorio.Verify(x => x.PegarPorId(nota.Id));
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void NotaFiscal_Aplicacao_PegarTodos_DevePegarOk()
        {
            IList<NotaFiscal> listaNotas = new List<NotaFiscal>();
            NotaFiscal nota = ObjectMother.ObterNotaEmitidaValida();
            nota.Id = 1;

            NotaXmlRepositorio notaXml = new NotaXmlRepositorio();
            notaXml.NotaFiscalParaXml(nota);
            nota.NotaFiscalXml = notaXml.XmlNotaFiscal;

            listaNotas.Add(nota);

            mockRepositorio.Setup(x => x.PegarTodos()).Returns(listaNotas);

            IEnumerable<NotaFiscal> notas = notaFiscalServico.PegarTodos();

            var idEsperado = 1;
            notas.Count().Should().BeGreaterThan(0);
            notas.Last().Id.Should().Be(idEsperado);
            mockRepositorio.Verify(x => x.PegarTodos());
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void NotaFiscal_Aplicacao_Deletar_DeveDeletarOk()
        {
            NotaFiscal nota = ObjectMother.ObterNotaValida();
            nota.Id = 1;
            mockRepositorio.Setup(x => x.Deletar(nota));

            notaFiscalServico.Deletar(nota);

            mockRepositorio.Verify(x => x.Deletar(nota));
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void NotaFiscal_Aplicacao_Atualizar_DeveRetornarExcessaoIdZeradoAoAtualizar()
        {
            NotaFiscal nota = ObjectMother.ObterNotaValida();

            Action action = () => notaFiscalServico.Atualizar(nota);

            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void NotaFiscal_Aplicacao_PegarPorId_DeveRetornarExcessaoIdZeradoAoObterPorId()
        {
            NotaFiscal nota = ObjectMother.ObterNotaValida();

            Action action = () => notaFiscalServico.PegarPorId(nota.Id);

            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void NotaFiscal_Aplicacao_Deletar_DeveRetornarExcessaoIdZeradoAoDeletar()
        {
            NotaFiscal nota = ObjectMother.ObterNotaValida();

            Action action = () => notaFiscalServico.Deletar(nota);

            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void NotaFiscal_Aplicacao_Salvar_DeveRetornarExcessaoEmitenteVazio()
        {
            NotaFiscal nota = ObjectMother.ObterNotaValida();
            nota.Emitente = null;

            Action action = () => notaFiscalServico.Salvar(nota);

            action.Should().Throw<NotaFiscalEmitenteVazioException>();
        }

        [Test]
        public void NotaFiscal_Aplicacao_Salvar_DeveRetornarExcessaoDestinataraioVazio()
        {
            NotaFiscal nota = ObjectMother.ObterNotaValida();
            nota.Destinatario = null;

            Action action = () => notaFiscalServico.Salvar(nota);

            action.Should().Throw<NotaFiscalDestinatarioVazioException>();
        }


        [Test]
        public void NotaFiscal_Dominio_Validar_DevePreencherTransportadorVazioComOsDadosDeDestinatario()
        {
            NotaFiscal notaFiscal = ObjectMother.ObterNotaValidaSemTransportador();
            notaFiscal.Transportador = null;

            notaFiscal.Validar();

            notaFiscal.Transportador.Nome.Should().Be(notaFiscal.Destinatario.Nome);
        }

        [Test]
        public void NotaFiscal_Aplicacao_ExportarXml_DeveRetornarExcessaoExportarXmlCaminhoVazio()
        {
            NotaFiscal nota = ObjectMother.ObterNotaValida();
            var caminho = "";

            Action action = () => notaFiscalServico.ExportaXml(caminho, nota);

            action.Should().Throw<PathNullOrNotFound>();
        }

        [Test]
        public void NotaFiscal_Aplicacao_ExportarXml_DeveExportarXmlOk()
        {
            NotaFiscal nota = ObjectMother.ObterNotaValida();
            var caminho = AppDomain.CurrentDomain.BaseDirectory + "\\..\\teste.xml";

            Action action = () => notaFiscalServico.ExportaXml(caminho, nota);

            action.Should().NotThrow();
        }

        [Test]
        public void NotaFiscal_Aplicacao_ExportarPdf_DeveRetornarExcessaoExportarPdfCaminhoVazio()
        {
            NotaFiscal nota = ObjectMother.ObterNotaValida();
            var caminho = "";

            Action action = () => notaFiscalServico.ExportarPdf(caminho, nota);

            action.Should().Throw<PathNullOrNotFound>();
        }

        [Test]
        public void NotaFiscal_Aplicacao_ExportarPdf_DeveExportarPdfOk()
        {
            NotaFiscal nota = ObjectMother.ObterNotaEmitidaValida();
            var caminho = AppDomain.CurrentDomain.BaseDirectory + "\\..\\teste.pdf";
            nota.Emitir();

            Action action = () => notaFiscalServico.ExportarPdf(caminho, nota);

            action.Should().NotThrow();
        }

        [Test]
        public void NotaFiscal_Aplicacao_Atualizar_DeveRetornarExcessaoOperacaoNaoSuportadaAoAtualizarNotaEmitida()
        {
            NotaFiscal nota = ObjectMother.ObterNotaEmitidaValida();

            Action action = () => notaFiscalServico.Atualizar(nota);

            action.Should().Throw<UnsupportedOperationException>();
        }

        [Test]
        public void NotaFiscal_Aplicacao_PegarPorId_DeveRetornarNuloQuandoNaoEncontrarNota()
        {
            var id = 99;
            mockRepositorio.Setup(x => x.PegarPorId(id)).Returns((NotaFiscal)null);

            NotaFiscal nota = notaFiscalServico.PegarPorId(id);

            nota.Should().BeNull();
            mockRepositorio.Verify(x => x.PegarPorId(id));
            mockRepositorio.VerifyNoOtherCalls();
        }
    }
}

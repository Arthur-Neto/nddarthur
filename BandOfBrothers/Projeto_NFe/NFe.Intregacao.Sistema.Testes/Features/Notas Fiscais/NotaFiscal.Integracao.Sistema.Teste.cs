using FluentAssertions;
using NFe.Aplicacao.Features.Notas_Fiscais;
using NFe.Common.Testes.Base;
using NFe.Common.Testes.Features;
using NFe.Dominio.Exceptions;
using NFe.Dominio.Features.Notas_Fiscais;
using NFe.Infra.Data.Features.Notas_Fiscais;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NFe.Intregacao.Sistema.Testes.Features.Notas_Fiscais
{
    [TestFixture]
    public class NotaFiscalIntegracaoSistemaTeste
    {
        NotaFiscalServico notaFiscalServico;
        INotaFiscalRepositorio repositorio;
        NotaFiscalXml notaXml;

        [SetUp]
        public void SetUp()
        {
            repositorio = new NotaFiscalRepositorio();
            notaFiscalServico = new NotaFiscalServico(repositorio);
            notaXml = new NotaFiscalXml();
            BaseSqlTest.SeedDatabase();
        }

        [Test]
        public void NotaFiscal_IntegracaoSistema_Salvar_DeveInserirOk()
        {
            NotaFiscal nota = ObjectMother.ObterNotaValida();

            NotaFiscal novaNota = notaFiscalServico.Salvar(nota);

            novaNota.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void NotaFiscal_IntegracaoSistema_Atualizar_DeveAtualizarOk()
        {
            NotaFiscal nota = ObjectMother.ObterNotaValida();

            NotaFiscal novaNota = notaFiscalServico.Salvar(nota);

            var valorEsperado = "Retorno de mostruario";
            nota.NaturezaOperacao = valorEsperado;

            NotaFiscal notaAtualizada = notaFiscalServico.Atualizar(nota);

            notaAtualizada.NaturezaOperacao.Should().Be(valorEsperado);
        }

        [Test]
        public void NotaFiscal_IntegracaoSistema_PegarPorId_DevePegarPorId()
        {
            NotaFiscal nota = ObjectMother.ObterNotaValida();
            nota = notaFiscalServico.Salvar(nota);

            NotaFiscal notaObtida = notaFiscalServico.PegarPorId(nota.Id);

            notaObtida.Id.Should().Be(nota.Id);
        }

        [Test]
        public void NotaFiscal_IntegracaoSistema_PegarTodos_DevePegarTodasAsNotas()
        {
            NotaFiscal nota = ObjectMother.ObterNotaValida();
            nota = notaFiscalServico.Salvar(nota);

            IEnumerable<NotaFiscal> notas = notaFiscalServico.PegarTodos();
            
            notas.Count().Should().BeGreaterThan(0);
            notas.Last().Id.Should().Be(nota.Id);
        }

        [Test]
        public void NotaFiscal_IntegracaoSistema_Deletar_DeveExcluirUmaNota()
        {
            NotaFiscal nota = ObjectMother.ObterNotaValida();
            nota = notaFiscalServico.Salvar(nota);

            notaFiscalServico.Deletar(nota);
            IEnumerable<NotaFiscal> notas = notaFiscalServico.PegarTodos();

            notas.Should().NotContain(nota);
        }

        [Test]
        public void NotaFiscal_IntegracaoSistema_Atualizar_DeveRetornarExcessaoIdZeradoAoAtualizar()
        {
            NotaFiscal nota = ObjectMother.ObterNotaValida();

            Action action = () => notaFiscalServico.Atualizar(nota);

            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void NotaFiscal_IntegracaoSistema_Atualizar_DeveRetornarExcessaoAoAtualizarNotaEmitida()
        {
            NotaFiscal nota = ObjectMother.ObterNotaEmitidaValida();

            Action action = () => notaFiscalServico.Atualizar(nota);

            action.Should().Throw<UnsupportedOperationException>();
        }

        [Test]
        public void NotaFiscal_IntegracaoSistema_PegarPorId_DeveRetornarExcessaoIdZeradoAoObterPorId()
        {
            NotaFiscal nota = ObjectMother.ObterNotaValida();

            Action action = () => notaFiscalServico.PegarPorId(nota.Id);

            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void NotaFiscal_IntegracaoSistema_Deletar_DeveRetornarExcessaoIdZeradoAoDeletar()
        {
            NotaFiscal nota = ObjectMother.ObterNotaValida();

            Action action = () => notaFiscalServico.Deletar(nota);

            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void NotaFiscal_IntegracaoSistema_PegarPorId_DeveRetornarNuloQuandoNaoEncontradoUmIdValido()
        {
            var id = 99;
            NotaFiscal nota = notaFiscalServico.PegarPorId(id);

            nota.Should().BeNull();
        }

        [Test]
        public void NotaFiscal_IntegracaoSistema_Salvar_DeveRetornarExcessao_NotaJaEmitida()
        {
            NotaFiscal nota = ObjectMother.ObterNotaValida();
            nota.Emitido = true;

            Action action = () => notaFiscalServico.Salvar(nota);

            action.Should().Throw<SalvarNotaJaEmitidaException>();
        }

        [Test]
        public void NotaFiscal_IntegracaoSistema_Emitir_DeveEmitirOk()
        {
            NotaFiscal nota = ObjectMother.ObterNotaValida();

            Action action = () => notaFiscalServico.Emitir(nota);

            action.Should().NotThrow();
        }

        [Test]
        public void NotaFiscal_IntegracaoSistema_Emitir_DeveRetornarExcessaoNotaJaEmitida()
        {
            NotaFiscal nota = ObjectMother.ObterNotaEmitidaValida();

            Action action = () => notaFiscalServico.Emitir(nota);

            action.Should().Throw<SalvarNotaJaEmitidaException>();
        }

        [Test]
        public void NotaFiscal_IntegracaoSistema_ExportarXml_DeveExportarOk()
        {
            NotaFiscal nota = ObjectMother.ObterNotaValida();
            var caminho = AppDomain.CurrentDomain.BaseDirectory + "\\..\\teste.xml";

            Action action = () => notaFiscalServico.ExportaXml(caminho, nota);

            action.Should().NotThrow();
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
    }
}

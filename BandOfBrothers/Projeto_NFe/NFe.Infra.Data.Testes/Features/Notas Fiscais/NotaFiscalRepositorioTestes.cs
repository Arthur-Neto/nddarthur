using FluentAssertions;
using NFe.Common.Testes.Base;
using NFe.Common.Testes.Features;
using NFe.Dominio.Features.Notas_Fiscais;
using NFe.Infra.Data.Features.Notas_Fiscais;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace NFe.Infra.Data.Testes.Features.Notas_Fiscais
{
    [TestFixture]
    public class NotaFiscalRepositorioTestes
    {
        INotaFiscalRepositorio repositorio;
        NotaFiscal notaFiscal;

        [SetUp]
        public void SetUp()
        {
            BaseSqlTest.SeedDatabase();

            repositorio = new NotaFiscalRepositorio();
            notaFiscal = new NotaFiscal();
        }

        [Test]
        public void NotaFiscal_InfraData_Salvar_DeveInserirOK()
        {
            notaFiscal = ObjectMother.ObterNotaValida();
            notaFiscal.Destinatario.Id = 1;
            notaFiscal.Emitente.Id = 1;
            notaFiscal.Transportador.Id = 1;
            notaFiscal.GerarChaveAcesso();

            NotaFiscal _notaInserida = repositorio.Salvar(notaFiscal);

            var idEsperado = 2;
            _notaInserida.Id.Should().Be(idEsperado);
        }

        [Test]
        public void NotaFiscal_InfraData_Atualizar_DeveAtualizarOk()
        {
            notaFiscal = ObjectMother.ObterNotaValida();
            notaFiscal.GerarChaveAcesso();
            notaFiscal = repositorio.Salvar(notaFiscal);
            notaFiscal.Destinatario.Id = 1;
            notaFiscal.Emitente.Id = 1;
            notaFiscal.Transportador.Id = 1;
            var _novoNome = "COMPRA";
            notaFiscal.NaturezaOperacao = _novoNome;

            NotaFiscal _notaAtualizado = repositorio.Atualizar(notaFiscal);

            _notaAtualizado.NaturezaOperacao.Should().Be(_novoNome);
        }

        [Test]
        public void NotaFiscal_InfraData_PegarTodos_DevePegarTodos()
        {
            notaFiscal = ObjectMother.ObterNotaValida();
            notaFiscal.Destinatario.Id = 1;
            notaFiscal.Emitente.Id = 1;
            notaFiscal.Transportador.Id = 1;
            notaFiscal.GerarChaveAcesso();
            notaFiscal = repositorio.Salvar(notaFiscal);

            IEnumerable<NotaFiscal> notas = repositorio.PegarTodos();

            notas.Count().Should().BeGreaterThan(0);
            notas.Last().Id.Should().Be(notaFiscal.Id);
        }

        [Test]
        public void NotaFiscal_InfraData_PegarPorId_DevePegarPorId()
        {
            IEnumerable<NotaFiscal> notas = repositorio.PegarTodos();

            NotaFiscal _notaEncontrada = repositorio.PegarPorId(notas.Last().Id);

            _notaEncontrada.Should().NotBeNull();
            _notaEncontrada.Id.Should().Be(notas.Last().Id);
        }

        [Test]
        public void NotaFiscal_InfraData_Deletar_DeveDeletar()
        {
            notaFiscal = ObjectMother.ObterNotaValida();
            notaFiscal.Destinatario.Id = 1;
            notaFiscal.Emitente.Id = 1;
            notaFiscal.Transportador.Id = 1;
            notaFiscal.GerarChaveAcesso();
            notaFiscal = repositorio.Salvar(notaFiscal);

            repositorio.Deletar(notaFiscal);

            NotaFiscal _notaEncontrada = repositorio.PegarPorId(notaFiscal.Id);
            _notaEncontrada.Should().BeNull();
        }
    }
}

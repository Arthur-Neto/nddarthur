using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TutorialORM.Aplicacao.Features.Turmas;
using TutorialORM.Common.Testes.Features;
using TutorialORM.Dominio.Exceptions;
using TutorialORM.Dominio.Features.Turmas;
using TutorialORM.Infra.Data.Features.Turmas;

namespace TutorialORM.Aplicacao.Testes.Features.Turmas
{
    [TestFixture]
    public class TurmaServicoTestes
    {
        Mock<ITurmaRepositorio> repositorio;
        Turma turma;
        TurmaServico servico;

        [SetUp]
        public void SetUp()
        {
            turma = ObjectMother.ObterTurmaValida();
            repositorio = new Mock<ITurmaRepositorio>();
            servico = new TurmaServico(repositorio.Object);
        }

        [Test]
        public void Turma_Aplicacao_Salvar_NaoDeveJogarExcecao()
        {
            turma = ObjectMother.ObterTurmaValida();
            turma.Id = 1;
            repositorio.Setup(tr => tr.Salvar(turma)).Returns(new Turma { Id = turma.Id });

            var turmaSalva = servico.Salvar(turma);

            turmaSalva.Id.Should().Be(turma.Id);
            repositorio.Verify(tr => tr.Salvar(turma));
            repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Turma_Aplicacao_PegarPorId_NaoDeveJogarExcecao()
        {
            turma.Id = 1;
            repositorio.Setup(tr => tr.PegarPorId(turma.Id)).Returns(new Turma { Id = turma.Id });

            var turmaPega = servico.PegarPorId(turma.Id);

            turma.Id.Should().Be(turma.Id);
            repositorio.Verify(tr => tr.PegarPorId(turma.Id));
            repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Turma_Aplicacao_PegarPorId_DeveJogarExcecaoIdentificadorInvalido()
        {
            var turma = 0;

            Action acao = () => servico.PegarPorId(turma);

            acao.Should().Throw<IdentificadorInvalidoException>();
            repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Turma_Aplicacao_PegarTodos_NaoDeveJogarExcecao()
        {
            var turma = 1;
            repositorio.Setup(tr => tr.PegarTodos()).Returns(new List<Turma> { new Turma { Id = turma } });

            var turmas = servico.PegarTodos();

            turmas.First().Id.Should().Be(turma);
            repositorio.Verify(tr => tr.PegarTodos());
            repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Turma_Aplicacao_Atualizar_NaoDeveJogarExcecao()
        {
            turma = ObjectMother.ObterTurmaValida();
            turma.Descricao = "atualizado";
            turma.Id = 1;
            repositorio.Setup(tr => tr.Atualizar(turma)).Returns(new Turma { Descricao = "atualizado" });

            var turmaAtualizada = servico.Atualizar(turma);

            turmaAtualizada.Descricao.Should().Be(turma.Descricao);
            repositorio.Verify(tr => tr.Atualizar(turma));
            repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Turma_Aplicacao_Atualizar_DeveJogarIdentificadorInvalidoExcecao()
        {
            turma = ObjectMother.ObterTurmaValida();
            turma.Id = 0;

            Action acao = () => servico.Atualizar(turma);

            acao.Should().Throw<IdentificadorInvalidoException>();
            repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Turma_Aplicacao_Deletar_NaoDeveJogarExcecao()
        {
            turma.Id = 1;
            repositorio.Setup(tr => tr.Deletar(turma));
            repositorio.Setup(tr => tr.PegarPorId(turma.Id));
            repositorio.Setup(tr => tr.VerificaDependencia(turma));

            Action acao = () => servico.Deletar(turma);

            var turmaDeletada = servico.PegarPorId(turma.Id);

            acao.Should().NotThrow<Exception>();
            turmaDeletada.Should().BeNull();
            repositorio.Verify(tr => tr.VerificaDependencia(turma));
            repositorio.Verify(tr => tr.Deletar(turma));
            repositorio.Verify(tr => tr.PegarPorId(turma.Id));
            repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Turma_Aplicacao_Deletar_DeveJogarExcecaoTurmaReferenciada()
        {
            turma.Id = 1;
            repositorio.Setup(tr => tr.Deletar(turma)).Throws<TurmaReferenciadaException>();
            repositorio.Setup(tr => tr.VerificaDependencia(turma));

            Action acao = () => servico.Deletar(turma);
            
            acao.Should().Throw<TurmaReferenciadaException>();
            repositorio.Verify(tr => tr.Deletar(turma));
            repositorio.Verify(tr => tr.VerificaDependencia(turma));
            repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Turma_Aplicacao_Deletar_DeveJogarIdentificadorInvalidoExcecao()
        {
            turma.Id = 0;

            Action acao = () => servico.Deletar(turma);

            acao.Should().Throw<IdentificadorInvalidoException>();
            repositorio.VerifyNoOtherCalls();
        }
    }
}

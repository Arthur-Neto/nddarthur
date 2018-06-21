using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TutorialORM.Aplicacao.Features.Alunos;
using TutorialORM.Common.Testes.Features;
using TutorialORM.Dominio.Exceptions;
using TutorialORM.Dominio.Features.Alunos;

namespace TutorialORM.Aplicacao.Testes.Features.Alunos
{
    [TestFixture]
    public class AlunoServicoTestes
    {
        Mock<IAlunoRepositorio> repositorio;
        Aluno aluno;
        AlunoServico servico;

        [SetUp]
        public void SetUp()
        {
            repositorio = new Mock<IAlunoRepositorio>();
            servico = new AlunoServico(repositorio.Object);
        }

        [Test]
        public void Aluno_Aplicacao_Salvar_NaoDeveJogarExcecao()
        {
            var id = 1;
            aluno = ObjectMother.ObterAlunoValido();
            repositorio.Setup(ar => ar.Salvar(aluno)).Returns(new Aluno { Id = id });

            var alunoSalva = servico.Salvar(aluno);

            alunoSalva.Id.Should().Be(id);
            repositorio.Verify(ar => ar.Salvar(aluno));
            repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Aluno_Aplicacao_PegarPorId_NaoDeveJogarExcecao()
        {
            var id = 1;
            repositorio.Setup(ar => ar.PegarPorId(id)).Returns(new Aluno { Id = id });

            var aluno = servico.PegarPorId(id);

            aluno.Id.Should().Be(id);
            repositorio.Verify(ar => ar.PegarPorId(id));
            repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Aluno_Aplicacao_PegarPorId_DeveJogarExcecaoIdentificadorInvalido()
        {
            var id = 0;

            Action acao = () => servico.PegarPorId(id);

            acao.Should().Throw<IdentificadorInvalidoException>();
            repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Aluno_Aplicacao_PegarTodos_NaoDeveJogarExcecao()
        {
            var id = 1;
            repositorio.Setup(ar => ar.PegarTodos()).Returns(new List<Aluno> { new Aluno { Id = id } });

            var alunos = servico.PegarTodos();

            alunos.First().Id.Should().Be(id);
            repositorio.Verify(ar => ar.PegarTodos());
            repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Aluno_Aplicacao_Atualizar_NaoDeveJogarExcecao()
        {
            aluno = ObjectMother.ObterAlunoValido();
            aluno.Nome = "atualizado";
            aluno.Id = 1;
            repositorio.Setup(ar => ar.Atualizar(aluno)).Returns(new Aluno { Nome = "atualizado" });

            var alunoAtualizada = servico.Atualizar(aluno);

            alunoAtualizada.Nome.Should().Be(aluno.Nome);
            repositorio.Verify(ar => ar.Atualizar(aluno));
            repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Aluno_Aplicacao_Atualizar_DeveJogarIdentificadorInvalidoExcecao()
        {
            aluno = ObjectMother.ObterAlunoValido();
            aluno.Id = 0;

            Action acao = () => servico.Atualizar(aluno);

            acao.Should().Throw<IdentificadorInvalidoException>();
            repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Aluno_Aplicacao_Deletar_NaoDeveJogarExcecao()
        {
            aluno.Id = 1;
            repositorio.Setup(ar => ar.Deletar(aluno));
            repositorio.Setup(ar => ar.PegarPorId(aluno.Id));

            Action acao = () => servico.Deletar(aluno);

            var alunoDeletada = servico.PegarPorId(aluno.Id);

            acao.Should().NotThrow<Exception>();
            alunoDeletada.Should().BeNull();
            repositorio.Verify(ar => ar.Deletar(aluno));
            repositorio.Verify(ar => ar.PegarPorId(aluno.Id));
            repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Aluno_Aplicacao_Deletar_DeveJogarIdentificadorInvalidoExcecao()
        {
            aluno.Id = 0;

            Action acao = () => servico.Deletar(aluno);

            acao.Should().Throw<IdentificadorInvalidoException>();
            repositorio.VerifyNoOtherCalls();
        }
    }
}

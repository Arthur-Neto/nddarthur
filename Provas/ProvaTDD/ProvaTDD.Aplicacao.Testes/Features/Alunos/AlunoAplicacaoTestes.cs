using FluentAssertions;
using Moq;
using NUnit.Framework;
using ProvaTDD.Aplicacao.Features.Alunos;
using ProvaTDD.Common.Testes.Features;
using ProvaTDD.Dominio.Features.Alunos;
using System.Collections.Generic;
using System.Linq;

namespace ProvaTDD.Aplicacao.Testes.Features.Alunos
{
    [TestFixture]
    public class AlunoAplicacaoTestes
    {
        Mock<IAlunoRepositorio> repositorio;
        AlunoServico servico;
        Aluno aluno;

        [SetUp]
        public void SetUp()
        {
            repositorio = new Mock<IAlunoRepositorio>();
            servico = new AlunoServico(repositorio.Object);
        }

        [Test]
        public void Aluno_Servico_Salvar_DeveSalvarOk()
        {
            aluno = ObjectMother.ObterAlunoValido();
            repositorio.Setup(m => m.Salvar(aluno)).Returns(new Aluno { Id = 1 });

            aluno = servico.Salvar(aluno);

            aluno.Id.Should().BeGreaterThan(0);
            repositorio.Verify(m => m.Salvar(aluno));
            repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Aluno_Servico_Atualizar_DeveAtualizarOk()
        {
            aluno = ObjectMother.ObterAlunoValido();
            repositorio.Setup(m => m.Salvar(aluno)).Returns(new Aluno { Id = 1 });
            repositorio.Setup(m => m.Atualizar(aluno)).Returns(new Aluno { Id = 1 });
            repositorio.Setup(m => m.PegarPorId(aluno.Id)).Returns(new Aluno { Id = 1 });
            aluno = servico.Salvar(aluno);
            aluno = servico.PegarPorId(aluno.Id);
            aluno.Idade = 30;

            aluno = servico.Atualizar(aluno);

            aluno.Id.Should().BeGreaterThan(0);
            aluno.Idade.Should().Be(30);
            repositorio.Verify(m => m.Atualizar(aluno));
            repositorio.Verify(m => m.Salvar(aluno));
            repositorio.Verify(m => m.PegarPorId(aluno.Id));
            repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Aluno_Servico_PegarPorId_DevePegarPorIdOk()
        {
            aluno = ObjectMother.ObterAlunoValido();
            repositorio.Setup(m => m.Salvar(aluno)).Returns(new Aluno { Id = 1 });
            repositorio.Setup(m => m.PegarPorId(aluno.Id)).Returns(new Aluno { Id = 1 });
            aluno = servico.Salvar(aluno);

            Aluno alunoPego = servico.PegarPorId(aluno.Id);

            alunoPego.Id.Should().Equals(aluno.Id);
            repositorio.Verify(m => m.PegarPorId(aluno.Id));
            repositorio.Verify(m => m.Salvar(aluno));
            repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Aluno_Servico_PegarTodos_DevePegarTodosOk()
        {
            aluno = ObjectMother.ObterAlunoValido();
            repositorio.Setup(m => m.Salvar(aluno)).Returns(new Aluno { Id = 1 });
            repositorio.Setup(m => m.PegarTodos()).Returns(new List<Aluno>());
            aluno = servico.Salvar(aluno);

            IList<Aluno> alunos = servico.PegarTodos();

            alunos.Count.Should().BeGreaterThan(0);
            alunos.Last().Id.Should().Be(aluno.Id);
            repositorio.Verify(m => m.PegarTodos());
            repositorio.Verify(m => m.Salvar(aluno));
            repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Aluno_Servico_Deletar_DeveDeletarOk()
        {
            aluno = ObjectMother.ObterAlunoValido();
            repositorio.Setup(m => m.Salvar(aluno)).Returns(new Aluno { Id = 1 });
            repositorio.Setup(m => m.Deletar(aluno));
            aluno = servico.Salvar(aluno);

            servico.Deletar(aluno);

            aluno = servico.PegarPorId(aluno.Id);
            aluno.Should().BeNull();
            repositorio.Verify(m => m.Deletar(aluno));
            repositorio.Verify(m => m.Salvar(aluno));
            repositorio.VerifyNoOtherCalls();
        }
    }
}

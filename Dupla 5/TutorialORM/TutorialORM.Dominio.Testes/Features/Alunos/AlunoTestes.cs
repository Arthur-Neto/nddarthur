using FluentAssertions;
using NUnit.Framework;
using System;
using TutorialORM.Common.Testes.Features;
using TutorialORM.Dominio.Features.Alunos;

namespace TutorialORM.Dominio.Testes.Features.Alunos
{
    [TestFixture]
    public class AlunoTestes
    {
        Aluno aluno;

        [Test]
        public void Aluno_Dominio_Validar_DeveSerOk()
        {
            aluno = ObjectMother.ObterAlunoValido();

            Action acao = aluno.Validar;

            acao.Should().NotThrow<Exception>();
        }

        [Test]
        public void Aluno_Dominio_Validar_DeveJogarExcecao_AlunoNomeVazio()
        {
            aluno = ObjectMother.ObterAlunoSemNome();

            Action acao = aluno.Validar;

            acao.Should().Throw<AlunoNomeVazioException>();
        }

        [Test]
        public void Aluno_Dominio_Validar_DeveJogarExcecao_AlunoDataNascimentoInvalida()
        {
            aluno = ObjectMother.ObterAlunoDataNascimentoInvalida();

            Action acao = aluno.Validar;

            acao.Should().Throw<AlunoDataNascimentoInvalidaException>();
        }

        [Test]
        public void Aluno_Dominio_Validar_DeveJogarExcecao_AlunoTurmaNulo()
        {
            aluno = ObjectMother.ObterAlunoSemTurma();

            Action acao = aluno.Validar;

            acao.Should().Throw<AlunoTurmaNuloException>();
        }

        [Test]
        public void Aluno_Dominio_Validar_DeveJogarExcecao_AlunoEnderecoNulo()
        {
            aluno = ObjectMother.ObterAlunoSemEndereco();

            Action acao = aluno.Validar;

            acao.Should().Throw<AlunoEnderecoNuloException>();
        }
    }
}

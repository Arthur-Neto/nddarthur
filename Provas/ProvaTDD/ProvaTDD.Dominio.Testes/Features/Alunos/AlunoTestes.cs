using FluentAssertions;
using NUnit.Framework;
using ProvaTDD.Common.Testes.Features;
using ProvaTDD.Dominio.Features.Alunos;
using ProvaTDD.Dominio.Features.Avaliacoes;
using System;
using System.Collections.Generic;

namespace ProvaTDD.Dominio.Testes.Features.Alunos
{
    [TestFixture]
    public class AlunoTestes
    {
        Aluno aluno;

        [SetUp]
        public void SetUp()
        {
            aluno = ObjectMother.ObterAlunoValido();
        }

        [Test]
        public void Aluno_Dominio_DeveValidarOk()
        {
            aluno = ObjectMother.ObterAlunoValido();

            Action acao = aluno.Validar;

            acao.Should().NotThrow();
        }

        [Test]
        public void Aluno_Dominio_DeveJogarExcecaoNomeVazio()
        {
            aluno.Nome = "";

            Action acao = aluno.Validar;

            acao.Should().Throw<AlunoNomeVazioException>();
        }

        [Test]
        public void Aluno_Dominio_DeveJogarExcecaoIdadeInvalida()
        {
            aluno.Idade = -1;

            Action acao = aluno.Validar;

            acao.Should().Throw<AlunoIdadeInvalidaException>();
        }

        [Test]
        public void Aluno_Dominio_DeveCalcularMediaAluno()
        {
            var mediaEsperada = 5;
            IList<Avaliacao> avaliacoes = new List<Avaliacao>();
            avaliacoes.Add(ObjectMother.ObterAvaliacaoComResultados());

            aluno.CalcularMedia(avaliacoes);

            aluno.Media.Should().Be(mediaEsperada);
        }

        [Test]
        public void Aluno_Dominio_DeveCalcularMediaAlunoArredondarParaZero()
        {
            var mediaEsperada = 5.0;
            IList<Avaliacao> avaliacoes = new List<Avaliacao>();
            avaliacoes.Add(ObjectMother.ObterAvaliacaoComResultados());

            aluno.CalcularMedia(avaliacoes);

            aluno.Media.Should().Be(mediaEsperada);
        }

        [Test]
        public void Aluno_Dominio_DeveCalcularMediaAlunoArredondarParaMetade()
        {
            var mediaEsperada = 5.5;
            IList<Avaliacao> avaliacoes = new List<Avaliacao>();
            avaliacoes.Add(ObjectMother.ObterAvaliacaoComResultadosNotaCincoMeio());

            aluno.CalcularMedia(avaliacoes);

            aluno.Media.Should().Be(mediaEsperada);
        }

        [Test]
        public void Aluno_Dominio_DeveCalcularMediaAlunoArredondarParaCima()
        {
            var mediaEsperada = 6;
            IList<Avaliacao> avaliacoes = new List<Avaliacao>();
            avaliacoes.Add(ObjectMother.ObterAvaliacaoComResultadosAlunoNotaSeis());

            aluno.CalcularMedia(avaliacoes);

            aluno.Media.Should().Be(mediaEsperada);
        }
    }
}

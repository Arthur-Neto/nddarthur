using FluentAssertions;
using NUnit.Framework;
using ProvaTDD.Common.Testes.Features;
using ProvaTDD.Common.Testes.Features.Resultados;
using ProvaTDD.Dominio.Features.Alunos;
using ProvaTDD.Dominio.Features.Avaliacoes;
using System;

namespace ProvaTDD.Dominio.Testes.Features.Avaliacoes
{
    [TestFixture]
    public class AvaliacaoTestes
    {
        Avaliacao avaliacao;

        [SetUp]
        public void SetUp()
        {
            avaliacao = ObjectMother.ObterAvaliacaoValida();
        }

        [Test]
        public void Avaliacao_Dominio_DeveValidarOk()
        {
            ResultadoFake resultado = new ResultadoFake();
            resultado.Aluno = ObjectMother.ObterAlunoValido();
            avaliacao.Resultados.Add(resultado);

            Action acao = avaliacao.Validar;

            acao.Should().NotThrow();
        }

        [Test]
        public void Avaliacao_Dominio_DeveValidarOkMaisResultados()
        {
            ResultadoFake resultado = new ResultadoFake();
            ResultadoFake resultadoAdicional = new ResultadoFake();
            resultadoAdicional.Aluno = new Aluno() { Nome = "Ciclano" };
            resultado.Aluno = ObjectMother.ObterAlunoValido();
            avaliacao.Resultados.Add(resultado);
            avaliacao.Resultados.Add(resultadoAdicional);

            Action acao = avaliacao.Validar;

            acao.Should().NotThrow();
        }

        [Test]
        public void Avaliacao_Dominio_DeveJogarExcecaoDoisResultadosParaMesmoAluno()
        {
            ResultadoFake resultado = new ResultadoFake();
            resultado.Aluno = ObjectMother.ObterAlunoValido();
            avaliacao.Resultados.Add(resultado);
            avaliacao.Resultados.Add(resultado);

            Action acao = avaliacao.Validar;

            acao.Should().Throw<AvalicaoResultadosMesmoAlunoException>();
        }

        [Test]
        public void Avaliacao_Dominio_DeveJogarExcecaoAvaliacaoAssuntoVazio()
        {
            avaliacao.Assunto = "";

            Action acao = avaliacao.Validar;

            acao.Should().Throw<AvaliacaoAssuntoVazioException>();
        }
    }
}

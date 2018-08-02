using FluentAssertions;
using NUnit.Framework;
using ProvaTDD.Common.Testes.Features;
using ProvaTDD.Dominio.Features.Avaliacoes;
using ProvaTDD.Dominio.Features.Resultados;
using System;
using System.Collections.Generic;

namespace ProvaTDD.Dominio.Testes.Features.Resultados
{
    [TestFixture]
    public class ResultadoTeste
    {
        Resultado resultado;

        [Test]
        public void Resultado_Dominio_DeveValidarOk()
        {
            resultado = ObjectMother.ObterResultadoValido();
            resultado.Aluno = ObjectMother.ObterAlunoValido();

            Action acao = resultado.Validar;

            acao.Should().NotThrow();
        }

        [Test]
        public void Resultado_Dominio_DeveJogarExcecaoNotaInvalida()
        {
            resultado = ObjectMother.ObterResultadoInvalido();
            resultado.Aluno = ObjectMother.ObterAlunoValido();

            Action acao = resultado.Validar;

            acao.Should().Throw<ResultadoNotaInvalidaException>();
        }

        [Test]
        public void Resultado_Dominio_DeveJogarExcecaoAlunoNulo()
        {
            resultado = ObjectMother.ObterResultadoValido();

            Action acao = resultado.Validar;

            acao.Should().Throw<ResultadoAlunoNuloException>();
        }
    }
}

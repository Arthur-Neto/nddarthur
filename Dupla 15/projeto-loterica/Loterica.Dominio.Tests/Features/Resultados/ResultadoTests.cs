using FluentAssertions;
using Loterica.Common.Tests;
using Loterica.Dominio.Features.Apostas;
using Loterica.Dominio.Features.Boloes;
using Loterica.Dominio.Features.Concursos;
using Loterica.Dominio.Features.Resultados;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Loterica.Dominio.Tests.Features.Resultados
{
    [TestFixture]
    public class ResultadoTests
    {
        Resultado resultado;
        Mock<Concurso> _concurso;
        Mock<Aposta> _aposta;
        Mock<Bolao> _bolao;

        [SetUp]
        public void SetUp()
        {
            _concurso = new Mock<Concurso>();
            _bolao = new Mock<Bolao>();
            _aposta = new Mock<Aposta>();
        }

        [Test]
        public void Test_Resultado_ShouldValidateAllOk()
        {
            resultado = ObjectMother.GetValidResultado();

            Action action = () => resultado.Validar();

            action.Should().NotThrow();
        }

        [Test]
        public void Test_Resultado_ShouldThrowInsufficientNumbers()
        {
            resultado = ObjectMother.GetResultadoNumeroSorteadosInsufficient(_concurso.Object);

            Action action = () => resultado.Validar();

            action.Should().Throw<ResultadoNumerosSorteadosInsufficientException>();
        }

        [Test]
        public void Test_Resultado_ShouldGerarNovosNumerosOk()
        {
            resultado = ObjectMother.GetValidResultado();

            Action action = () => resultado.GerarNovosNumeros();

            action.Should().NotThrow();
        }

        [Test]
        public void Test_Resultado_ShouldReturnDifferentNumbersOnGerarNovosNumeros()
        {
            resultado = ObjectMother.GetValidResultado();

            List<int> numerosAntigos = resultado.NumerosSorteados.Select(num => num).ToList();
            resultado.GerarNovosNumeros();
            List<int> numerosNovos = resultado.NumerosSorteados;

            numerosNovos.Should().NotBeSameAs(numerosAntigos);
        }
    }
}

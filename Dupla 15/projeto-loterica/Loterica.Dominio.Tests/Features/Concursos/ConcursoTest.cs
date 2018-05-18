using System;
using FluentAssertions;
using Loterica.Common.Tests.Base;
using Loterica.Dominio.Features.Apostas;
using Loterica.Dominio.Features.Concursos;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using Loterica.Dominio.Features.Resultados;
using Loterica.Dominio.Features.Boloes;

namespace Loterica.Dominio.Tests.Features.Concursos
{
    [TestFixture]
    public class ConcursoTest
    {
        Concurso _concurso;
        Mock<Aposta> _aposta;
        Mock<Resultado> _resultado;
        Mock<Bolao> _bolao;

        [SetUp]
        public void SetUp()
        {
            _resultado = new Mock<Resultado>();
            _aposta = new Mock<Aposta>();
            _bolao = new Mock<Bolao>();
        }

        [Test]
        public void Test_Concurso_ShouldValidateAllOk()
        {
            _concurso = ObjectMother.GetValidConcursoFechado();

            Action action = () => _concurso.Validar();

            action.Should().NotThrow();
        }

        [Test]
        public void Test_Concurso_ShouldReturnWinnerList()
        {
            _resultado.Setup(x => x.NumerosSorteados).Returns(new List<int>() { 01, 02, 03, 04, 05, 06 });
            _aposta.Setup(x => x.IsGanhadora()).Returns(true);
            _concurso = ObjectMother.GetValidConcursoAberto();
            _concurso.Apostas.Add(_aposta.Object);

            List<Aposta> ganhadores = _concurso.Ganhadores;

            ganhadores.Should().Contain(_aposta.Object);
        }

        [Test]
        public void Test_Concurso_ShouldReturnWinnerListNoWinner()
        {
            _resultado.Setup(x => x.NumerosSorteados).Returns(new List<int>() { 11, 22, 33, 44, 55, 60 });
            _aposta.Setup(x => x.IsGanhadora()).Returns(false);
            _concurso = ObjectMother.GetValidConcursoAberto();
            _concurso.Apostas.Add(_aposta.Object);

            List<Aposta> ganhadores = _concurso.Ganhadores;

            ganhadores.Should().NotContain(_aposta.Object);
        }

        [Test]
        public void Test_Concurso_ShouldReturnPremioNoBolaoWithAposta()
        {
            _aposta.Setup(x => x.Numeros).Returns(new List<int>() { 01, 02, 03, 04, 05, 06 });
            _aposta.Setup(x => x.Valor).Returns(4.0m);
            _concurso = ObjectMother.GetValidConcursoFechado();
            _concurso.Apostas.Add(_aposta.Object);

            decimal result = _concurso.Premio;
            decimal resultQuadra = _concurso.PremioQuadra;
            decimal resultQuina = _concurso.PremioQuina;
            decimal resultSena = _concurso.PremioSena;

            decimal premioEsperado = 4.0m, taxaLoterica = 0.9m, premioComTaxa = premioEsperado * taxaLoterica, corteQuadra = 0.1m, corteQuina = 0.2m, corteSena = 0.7m;

            result.Should().Be(premioEsperado * taxaLoterica);
            resultQuadra.Should().Be(premioComTaxa * corteQuadra);
            resultQuina.Should().Be(premioComTaxa * corteQuina);
            resultSena.Should().Be(premioComTaxa * corteSena);
        }

        [Test]
        public void Test_Concurso_ShouldReturnPremioWithBoloesAndAposta()
        {
            _aposta.Setup(x => x.Numeros).Returns(new List<int>() { 01, 02, 03, 04, 05, 06 });
            _aposta.Setup(x => x.Valor).Returns(4.0m);
            _bolao.Setup(x => x.Apostas).Returns(new List<Aposta>());
            _concurso = ObjectMother.GetValidConcursoFechado();
            _concurso.Apostas.Add(_aposta.Object);
            _concurso.Boloes.Add(_bolao.Object);

            decimal result = _concurso.Premio;
            decimal resultQuadra = _concurso.PremioQuadra;
            decimal resultQuina = _concurso.PremioQuina;
            decimal resultSena = _concurso.PremioSena;

            decimal premioEsperado = 4.0m, taxaLoterica = 0.90m, premioComTaxa = premioEsperado * taxaLoterica, corteQuadra = 0.1m, corteQuina = 0.2m, corteSena = 0.7m;

            result.Should().Be(premioEsperado * taxaLoterica);
            resultQuadra.Should().Be(premioComTaxa * corteQuadra);
            resultQuina.Should().Be(premioComTaxa * corteQuina);
            resultSena.Should().Be(premioComTaxa * corteSena);
        }

        [Test]
        public void Test_Concurso_ShouldReturnPremioNoBolaoNoAposta()
        {
            _concurso = ObjectMother.GetValidConcursoFechado();

            decimal result = _concurso.Premio;
            decimal resultQuadra = _concurso.PremioQuadra;
            decimal resultQuina = _concurso.PremioQuina;
            decimal resultSena = _concurso.PremioSena;

            result.Should().Be(0);
            resultQuadra.Should().Be(0);
            resultQuina.Should().Be(0);
            resultSena.Should().Be(0);
        }

        [Test]
        public void Test_Concurso_ShouldReturnPremioWithBolaoNoAposta()
        {
            _aposta.Setup(x => x.Numeros).Returns(new List<int>() { 01, 02, 03, 04, 05, 06 });
            _aposta.Setup(x => x.Valor).Returns(4.0m);
            _bolao.Setup(x => x.Apostas).Returns(new List<Aposta>() { _aposta.Object });
            _concurso = ObjectMother.GetValidConcursoFechado();
            _concurso.Boloes.Add(_bolao.Object);

            decimal result = _concurso.Premio;
            decimal resultQuadra = _concurso.PremioQuadra;
            decimal resultQuina = _concurso.PremioQuina;
            decimal resultSena = _concurso.PremioSena;

            decimal premioEsperado = 4.0m, taxaLoterica = 0.95m, premioComTaxa = premioEsperado * taxaLoterica, corteQuadra = 0.1m, corteQuina = 0.2m, corteSena = 0.7m;

            result.Should().Be(premioEsperado * taxaLoterica);
            resultQuadra.Should().Be(premioComTaxa * corteQuadra);
            resultQuina.Should().Be(premioComTaxa * corteQuina);
            resultSena.Should().Be(premioComTaxa * corteSena);
        }

        [Test]
        public void Test_Concurso_ShouldSetPremioValue()
        {
            _concurso = ObjectMother.GetValidConcursoAberto();

            Action action = () => _concurso.Premio = 0;

            action.Should().NotThrow();
        }
    }
}

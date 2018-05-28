using FluentAssertions;
using Loterica.Common.Tests;
using Loterica.Dominio.Features.Apostas;
using Loterica.Dominio.Features.Boloes;
using Loterica.Dominio.Features.Concursos;
using Loterica.Dominio.Features.Resultados;
using Moq;
using NUnit.Framework;
using System;

namespace Loterica.Dominio.Tests.Features.Concursos
{
    [TestFixture]
    public class ConcursoTest
    {
        Concurso _concurso;
        Mock<Aposta> _aposta;
        Mock<Aposta> _apostaQuina;
        Mock<Aposta> _apostaQuadra;
        Mock<Resultado> _resultado;
        Mock<Bolao> _bolao;

        [SetUp]
        public void SetUp()
        {
            _resultado = new Mock<Resultado>();
            _aposta = new Mock<Aposta>();
            _bolao = new Mock<Bolao>();
            _apostaQuina = new Mock<Aposta>();
            _apostaQuadra = new Mock<Aposta>();
        }

        [Test]
        public void Test_Concurso_ShouldConcursoFechadoBeOk()
        {
            _concurso = ObjectMother.GetValidConcursoAberto();

            _concurso.IsFechado.Should().Be(false);
        }

        [Test]
        public void Test_Concurso_ShouldThrowOnValidate()
        {
            _concurso = ObjectMother.GetValidConcursoFechado();

            Action action = () => _concurso.Validar();

            action.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void Test_Concurso_ShouldReturnPremioNoBolaoNoAposta()
        {
            _concurso = ObjectMother.GetValidConcursoFechado();

            decimal result = _concurso.Premio.Total;
            decimal resultQuadra = _concurso.Premio.Quadra;
            decimal resultQuina = _concurso.Premio.Quina;
            decimal resultSena = _concurso.Premio.Sena;

            result.Should().Be(0);
            resultQuadra.Should().Be(0);
            resultQuina.Should().Be(0);
            resultSena.Should().Be(0);
        }

        [Test]
        public void Test_Concurso_ShouldSetPremioValue()
        {
            _concurso = ObjectMother.GetValidConcursoAberto();

            Action action = () => _concurso.Premio.Total = 0;

            action.Should().NotThrow();
        }

        [Test]
        public void Test_Concurso_ShouldSetValueQuina()
        {
            _concurso = ObjectMother.GetValidConcursoAberto();

            _concurso.Premio.Quina = 50m;

            _concurso.Premio.Quina.Should().Be(50m);
        }

        [Test]
        public void Test_Concurso_ShouldSetValueSena()
        {
            _concurso = ObjectMother.GetValidConcursoAberto();

            _concurso.Premio.Sena = 50m;

            _concurso.Premio.Sena.Should().Be(50m);
        }

        [Test]
        public void Test_Concurso_ShouldCalculateResultadoConcursoComAposta()
        {
            _concurso = ObjectMother.GetValidConcursoComApostas();

            _concurso.FecharConcurso();

            var valorEsperado = 15.75m;
            _concurso.Premio.Total.Should().Be(valorEsperado);
        }

        [Test]
        public void Test_Concurso_ShouldCalculateResultadoConcursoComApostaeBolao()
        {
            _concurso = ObjectMother.GetValidConcursoComApostaseBolao();

            _concurso.FecharConcurso();

            var valorEsperado = 27.7200m;
            _concurso.Premio.Total.Should().Be(valorEsperado);
        }

        [Test]
        public void Test_Concurso_ShouldCalculateResultadoConcursoSenaVencedora()
        {
            _concurso = ObjectMother.GetValidConcursoAberto();
            _concurso.Apostas.Clear();
            _concurso.Apostas.Add(ObjectMother.GetValidApostaSena(_concurso));

            _concurso.FecharConcurso();

            var premioSena = 3.5m * 0.9m;
            _concurso.Premio.Sena.Should().Be(premioSena);
        }

        [Test]
        public void Test_Concurso_ShouldCalculateResultadoConcursoQuinaVencedora()
        {
            _concurso = ObjectMother.GetValidConcursoAberto();
            _concurso.Apostas.Clear();
            _concurso.Apostas.Add(ObjectMother.GetValidApostaQuina(_concurso));

            _concurso.FecharConcurso();

            var premioQuina = (3.5m * 0.9m) * 0.25m;
            _concurso.Premio.Quina.Should().Be(premioQuina);
        }

        [Test]
        public void Test_Concurso_ShouldCalculateResultadoConcursoQuadraVencedora()
        {
            _concurso = ObjectMother.GetValidConcursoAberto();
            _concurso.Apostas.Clear();
            _concurso.Apostas.Add(ObjectMother.GetValidApostaQuadra(_concurso));

            _concurso.FecharConcurso();

            var premioQuadra = (3.5m * 0.9m) * 0.1m;
            _concurso.Premio.Quadra.Should().Be(premioQuadra);
        }

        [Test]
        public void Test_Concurso_ShouldCalculateResultadoConcursoSenaeQuinaVencedora()
        {
            _concurso = ObjectMother.GetValidConcursoAberto();
            _concurso.Apostas.Clear();
            _concurso.Apostas.Add(ObjectMother.GetValidApostaSena(_concurso));
            _concurso.Apostas.Add(ObjectMother.GetValidApostaQuina(_concurso));

            _concurso.FecharConcurso();

            var premioSena = (7.0m * 0.9m) * 0.8m;
            var premioQuina = (7.0m * 0.9m) * 0.2m;
            _concurso.Premio.Sena.Should().Be(premioSena);
            _concurso.Premio.Quina.Should().Be(premioQuina);
        }

        [Test]
        public void Test_Concurso_ShouldCalculateResultadoConcursoSenaeQuadraVencedora()
        {
            _concurso = ObjectMother.GetValidConcursoAberto();
            _concurso.Apostas.Clear();
            _concurso.Apostas.Add(ObjectMother.GetValidApostaSena(_concurso));
            _concurso.Apostas.Add(ObjectMother.GetValidApostaQuadra(_concurso));

            _concurso.FecharConcurso();

            var premioSena = (7.0m * 0.9m) * 0.9m;
            var premioQuadra = (7.0m * 0.9m) * 0.1m;
            _concurso.Premio.Sena.Should().Be(premioSena);
            _concurso.Premio.Quadra.Should().Be(premioQuadra);

        }

        [Test]
        public void Test_Concurso_ShouldCalculateResultadoConcursoQuinaeQuadraVencedora()
        {
            _concurso = ObjectMother.GetValidConcursoAberto();
            _concurso.Apostas.Clear();
            _concurso.Apostas.Add(ObjectMother.GetValidApostaQuina(_concurso));
            _concurso.Apostas.Add(ObjectMother.GetValidApostaQuadra(_concurso));

            _concurso.FecharConcurso();

            var premioQuina = (7.0m * 0.9m) * 0.2m;
            var premioQuadra = (7.0m * 0.9m) * 0.1m;
            _concurso.Premio.Quina.Should().Be(premioQuina);
            _concurso.Premio.Quadra.Should().Be(premioQuadra);

        }

        [Test]
        public void Test_Concurso_ShouldCalculateResultadoConcursoComBolaoSemAposta()
        {
            _concurso = ObjectMother.GetValidConcursoComApostaseBolaoQuadraQuinaeSena();
            _concurso.Apostas.Clear();

            _concurso.FecharConcurso();

            var premioSena = (10.5m * 0.95m) * 0.7m;
            var premioQuina = (10.5m * 0.95m) * 0.2m;
            var premioQuadra = (10.5m * 0.95m) * 0.1m;
            _concurso.Premio.Sena.Should().Be(premioSena);
            _concurso.Premio.Quina.Should().Be(premioQuina);
            _concurso.Premio.Quadra.Should().Be(premioQuadra);
        }

    }
}

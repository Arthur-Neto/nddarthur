using FluentAssertions;
using Loterica.Common.Tests;
using Loterica.Dominio.Features.Apostas;
using Loterica.Dominio.Features.Boloes;
using Loterica.Dominio.Features.Concursos;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;

namespace Loterica.Dominio.Tests.Features.Boloes
{
    [TestFixture]
    public class BoloesTest
    {
        Bolao _bolao;
        Concurso _concurso;
        Mock<Aposta> _apostas;

        [SetUp]
        public void SetUp()
        {
            _apostas = new Mock<Aposta>();
        }

        [Test]
        public void Test_Boloes_ShouldThrowInvalidBolao()
        {
            _bolao = new Bolao();
            _bolao.Apostas.Add(_apostas.Object);

            Action action = () => _bolao.Validar();

            action.Should().Throw<BolaoApostasInsuficienteException>();
        }

        [Test]
        public void Test_Boloes_ShouldValidBolao()
        {
            _bolao = new Bolao();
            _bolao.Apostas.Add(_apostas.Object);
            _bolao.Apostas.Add(_apostas.Object);

            Action action = () => _bolao.Validar();

            action.Should().NotThrow();
            _bolao.Apostas.Should().HaveCount(2);
        }

        [Test]
        public void Test_Boloes_ShouldGerarBolao()
        {
            _concurso = ObjectMother.GetValidConcursoAberto();
            int _quantidadeApostas = 2;
            _bolao = new Bolao();
            _bolao = _bolao.GerarBolao(_quantidadeApostas, _concurso);

            _bolao.Apostas.Count().Should().BeGreaterThan(0);
        }
    }
}

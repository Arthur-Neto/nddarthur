using FluentAssertions;
using Loterica.Common.Tests.Base;
using Loterica.Dominio.Features.Apostas;
using Loterica.Dominio.Features.Concursos;
using Loterica.Infra.Data.Features.Apostas;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Loterica.Infra.Data.Tests.Features.Apostas
{
    [TestFixture]
    public class ApostaRepositoryTest
    {
        ApostaRepository _repository;
        Aposta _aposta;
        Concurso _concurso;
        Aposta _apostaInserida;

        [SetUp]
        public void SetUp()
        {
            BaseSqlTest.SeedDatabase();
            _repository = new ApostaRepository();
            _concurso = ObjectMother.GetValidConcursoAbertoComId(ObjectMother.GetValidResultado());

        }

        [Test]
        [Order(0)]
        public void Test_ApostaRepository_ShouldAddAposta()
        {
            _concurso = ObjectMother.GetValidConcursoAbertoComId(ObjectMother.GetValidResultado());
            _aposta = ObjectMother.GetValidAposta(_concurso);

            _apostaInserida = _repository.Adicionar(_aposta);

            _apostaInserida.Id.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(1)]
        public void Test_ApostaRepository_ShouldUpdateAposta()
        {
            _apostaInserida = _repository.ObterPorId(1);
            _apostaInserida.Valor = 4.5m;

            Aposta _apostaEditada = _repository.Atualizar(_apostaInserida);

            _apostaEditada.Id.Should().Be(_apostaInserida.Id);
            _apostaEditada.Valor.Should().Be(4.5m);
        }

        [Test]
        [Order(2)]
        public void Test_ApostaRepository_ShouldGetByIdAposta()
        {
            _aposta = ObjectMother.GetValidAposta(_concurso);
            _apostaInserida = _repository.Adicionar(_aposta);

            Aposta _apostaEsperada = _repository.ObterPorId(_apostaInserida.Id);

            _apostaEsperada.Id.Should().Be(_apostaInserida.Id);
        }

        [Test]
        [Order(3)]
        public void Test_ApostaRepository_ShouldGetAllAposta()
        {
            _aposta = ObjectMother.GetValidAposta(_concurso);
            _apostaInserida = _repository.Adicionar(_aposta);

            IEnumerable<Aposta> _apostas = _repository.PegarTodos();

            _apostas.Count().Should().BeGreaterThan(0);
        }

        [Test]
        [Order(4)]
        public void Test_ApostaRepository_ShouldDeleteAposta()
        {
            _aposta = ObjectMother.GetValidAposta(_concurso);
            _apostaInserida = _repository.Adicionar(_aposta);

            _repository.Deletar(_apostaInserida);

            _aposta = _repository.ObterPorId(_apostaInserida.Id);

            _aposta.Should().BeNull();
        }

    }
}

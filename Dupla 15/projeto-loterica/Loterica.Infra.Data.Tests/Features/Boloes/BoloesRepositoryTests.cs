using FluentAssertions;
using Loterica.Common.Tests.Base;
using Loterica.Dominio.Features.Boloes;
using Loterica.Infra.Data.Features.Boloes;
using Loterica.Infra.Data.Features.Concursos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Loterica.Infra.Data.Tests.Features.Boloes
{
    [TestFixture]
    public class BoloesRepositoryTests
    {
        BolaoRepository _repository;
        Bolao _bolao;
        Bolao _bolaoInserido;
        Bolao _bolaoGet;

        [SetUp]
        public void SetUp()
        {
            BaseSqlTest.SeedDatabase();
            _repository = new BolaoRepository();
        }

        [Test]
        [Order(0)]
        public void Test_BolaoRepository_ShouldAddOk()
        {
            _bolao = ObjectMother.GetBolaoValido();
            _bolaoInserido = _repository.Adicionar(_bolao);

            _bolaoInserido.Id.Should().BeGreaterThan(0);
        }
        
        [Test]
        public void Test_BolaoRepository_ShouldThrowOnUpdate()
        {
            _bolao = ObjectMother.GetBolaoValido();
            Action action = () => _repository.Atualizar(_bolao);

            action.Should().Throw<NotImplementedException>();
        }

        [Test]
        [Order(1)]
        public void Test_BolaoRepository_ShouldGetById()
        {
            _bolao = ObjectMother.GetBolaoValido();
            _bolaoInserido = _repository.Adicionar(_bolao);
            _bolaoGet = _repository.ObterPorId(_bolaoInserido.Id);

            _bolaoGet.Id.Should().Be(_bolaoInserido.Id);
            _bolaoGet.Apostas.Should().NotBeNullOrEmpty();
            _bolaoGet.Apostas.Count.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(2)]
        public void Test_BolaoRepository_ShouldGetAll()
        {
            _bolao = ObjectMother.GetBolaoValido();
            _bolaoInserido = _repository.Adicionar(_bolao);

            IEnumerable<Bolao> boloes = _repository.PegarTodos();
            boloes.Last().Id.Should().Be(_bolaoInserido.Id);
        }

        [Test]
        [Order(3)]
        public void Test_BolaoRepository_ShouldDeleteLastBolao()
        {
            _bolao = ObjectMother.GetBolaoVazio();
            _bolaoInserido = _repository.Adicionar(_bolao);
            _repository.Deletar(_bolaoInserido);

            IEnumerable<Bolao> boloes = _repository.PegarTodos();
            boloes.Last().Id.Should().NotBe(_bolaoInserido.Id);
        }
    }
}

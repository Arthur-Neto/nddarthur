using FluentAssertions;
using Loterica.Common.Tests;
using Loterica.Common.Tests.Base;
using Loterica.Dominio.Exceptions;
using Loterica.Dominio.Features.Apostas;
using Loterica.Dominio.Features.Boloes;
using Loterica.Infra.Data.Exceptions;
using Loterica.Infra.Data.Features.Apostas;
using Loterica.Infra.Data.Features.Boloes;
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
        IApostaRepository _apostaRepository;
        Bolao _bolao;
        Bolao _bolaoInserido;
        Bolao _bolaoGet;

        [SetUp]
        public void SetUp()
        {
            BaseSqlTest.SeedDatabase();
            _repository = new BolaoRepository();
            _apostaRepository = new ApostaRepository();
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
        [Order(1)]
        public void Test_BolaoRepository_ShouldGetByIdNoBolao()
        {
            _bolao = ObjectMother.GetBolaoValido();
            _bolaoInserido = _repository.Adicionar(_bolao);
            _bolaoInserido.Id = 5;
            _bolaoGet = _repository.ObterPorId(_bolaoInserido.Id);

            _bolaoGet.Should().BeNull();
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
            _bolao = ObjectMother.GetBolaoValido();
            _bolaoInserido = _repository.Adicionar(_bolao);
            foreach (var item in _bolaoInserido.Apostas)
            {
                _apostaRepository.Deletar(item);
            }
            _repository.Deletar(_bolaoInserido);

            IEnumerable<Bolao> boloes = _repository.PegarTodos();
            boloes.Last().Id.Should().NotBe(_bolaoInserido.Id);
        }

        [Test]
        public void Test_BolaoRepository_ShouldThrowOnDelete()
        {
            _bolao = ObjectMother.GetBolaoValido();
            _bolao.Id = 0;
            Action action = () => _repository.Deletar(_bolao);

            action.Should().Throw<IdentifierUndefinedException>();
        }


        [Test]
        public void Test_BolaoRepository_ShouldThrowOnGetById()
        {
            _bolao = ObjectMother.GetBolaoValido();
            _bolao.Id = 0;
            Action action = () => _repository.ObterPorId(_bolao.Id);

            action.Should().Throw<IdentifierUndefinedException>();
        }




        [Test]
        public void Test_BolaoRepository_ShouldThrowOnDeleteBolaoWithApostas()
        {
            _bolao = ObjectMother.GetBolaoValido();

            Bolao _bolaoInserido = _repository.Adicionar(_bolao);

            Action action = () => _repository.Deletar(_bolaoInserido);

            action.Should().Throw<DependenciaException>();
        }
    }
}

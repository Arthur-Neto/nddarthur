using FluentAssertions;
using Loterica.Common.Tests;
using Loterica.Common.Tests.Base;
using Loterica.Dominio.Exceptions;
using Loterica.Dominio.Features.Concursos;
using Loterica.Infra.Data.Exceptions;
using Loterica.Infra.Data.Features.Concursos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Loterica.Infra.Data.Tests.Features.Concursos
{
    [TestFixture]
    public class ConcursoRepositoryTest
    {
        ConcursoRepository _repository;
        Concurso _concurso;
        Concurso _concursoInserido;

        [SetUp]
        public void SetUp()
        {
            BaseSqlTest.SeedDatabase();
            _repository = new ConcursoRepository();
        }

        [Test]
        [Order(0)]
        public void Test_ConcursoRepository_ShouldAddConcurso()
        {
            _concurso = ObjectMother.GetValidConcursoAberto();

            _concursoInserido = _repository.Adicionar(_concurso);

            _concursoInserido.Id.Should().BeGreaterThan(0);
        }

        [Test]
        [Order(1)]
        public void Test_ConcursoRepository_ShouldUpdateConcurso()
        {
            _concursoInserido.Premio.Total = 2000;

            Concurso _concursoEditado = _repository.Atualizar(_concursoInserido);

            _concursoEditado.Premio.Total.Should().Be(2000);
        }

     

        [Test]
        [Order(2)]
        public void Test_ConcursoRepository_ShouldGetByIdConcurso()
        {
            _concurso = ObjectMother.GetValidConcursoAberto();
            _concursoInserido = _repository.Adicionar(_concurso);

            Concurso _concursoEsperado = _repository.ObterPorId(_concursoInserido.Id);

            _concursoEsperado.Id.Should().Be(_concursoInserido.Id);
        }

        [Test]
        [Order(3)]
        public void Test_ConcursoRepository_ShouldGetAllConcurso()
        {
            _concurso = ObjectMother.GetValidConcursoAberto();
            _concursoInserido = _repository.Adicionar(_concurso);

            IEnumerable<Concurso> _concursos = _repository.PegarTodos();

            _concursos.Count().Should().BeGreaterThan(0);
        }

        [Test]
        [Order(4)]
        public void Test_ConcursoRepository_ShouldDeleteConcurso()
        {
            _concurso = ObjectMother.GetValidConcursoAberto();
            _concurso = _repository.Adicionar(_concurso);

            _repository.Deletar(_concurso);

            foreach (var item in _repository.PegarTodos())
            {
                item.Id.Should().NotBe(_concurso.Id);
            }
        }

        [Test]
        [Order(5)]
        public void Test_ConcursoRepository_ShouldThrowDeleteConcursoException()
        {
            _concurso = _repository.ObterPorId(1);

            Action action = () =>_repository.Deletar(_concurso);

            action.Should().Throw<DependenciaException>();
        }

        [Test]
        public void Test_ConcursoRepository_ShouldThrowUpdate()
        {
            _concurso = _repository.ObterPorId(1);
            _concurso.Id = 0;
            Action action = () => _repository.Atualizar(_concurso);

            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Test_ConcursoRepository_ShouldThrowUpdateConcursoFechado()
        {
            _concurso = _repository.ObterPorId(1);
            _concurso.IsFechado = true;
            Action action = () => _repository.Atualizar(_concurso);

            action.Should().Throw<ConcursoFechadoException>();
        }

        [Test]
        public void Test_ConcursoRepository_ShouldThrowDelete()
        {
            _concurso = _repository.ObterPorId(1);
            _concurso.Id = 0;
            Action action = () => _repository.Deletar(_concurso);

            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Test_ConcursoRepository_ShouldThrowGetById()
        {
            _concurso = _repository.ObterPorId(1);
            _concurso.Id = 0;
            Action action = () => _repository.ObterPorId(_concurso.Id);

            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Test_ConcursoServico_ShouldGetFaturamento()
        {
            string result = _repository.RelatorioFaturamento();

            result.Should().NotBeNull();
        }
    }
}

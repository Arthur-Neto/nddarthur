using FluentAssertions;
using Loterica.Common.Tests;
using Loterica.Common.Tests.Base;
using Loterica.Dominio.Exceptions;
using Loterica.Dominio.Features.Resultados;
using Loterica.Infra.Data.Features.Resultados;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Loterica.Infra.Data.Tests.Features.Resultados
{
    [TestFixture]
    public class ResultadoRepositoryTest
    {
        ResultadoRepository _repository;
        Resultado _resultado;
        Resultado _resultadoInserido;

        [SetUp]
        public void SetUp()
        {
            BaseSqlTest.SeedDatabase();
            _repository = new ResultadoRepository();
        }

        [Test]
        public void Test_ResultadoRepository_ShouldAddOk()
        {
            _resultado = ObjectMother.GetValidResultado();
            _resultadoInserido = _repository.Adicionar(_resultado);

            _resultadoInserido.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Test_ResultadoRepository_ShouldGetOk()
        {
            _resultado = ObjectMother.GetValidResultado();
            _resultadoInserido = _repository.Adicionar(_resultado);
            Resultado resultadoObtido = _repository.ObterPorId(_resultadoInserido.Id);

            resultadoObtido.Id.Should().Be(_resultadoInserido.Id);
        }

        [Test]
        public void Test_ResultadoRepository_ShouldUpdateOk()
        {
            List<int> numeroSorteados = new List<int>();
            numeroSorteados.Add(01);
            numeroSorteados.Add(02);
            numeroSorteados.Add(03);
            numeroSorteados.Add(04);
            numeroSorteados.Add(05);
            numeroSorteados.Add(07);

            _resultado = ObjectMother.GetValidResultado();
            _resultadoInserido = _repository.Adicionar(_resultado);
            Resultado resultadoObtido = _repository.ObterPorId(_resultadoInserido.Id);
            resultadoObtido.NumerosSorteados = numeroSorteados;
            Resultado resultadoAtualizado = _repository.Atualizar(resultadoObtido);

            resultadoAtualizado.NumerosSorteados.Equals(numeroSorteados);
        }

        [Test]
        public void Test_ResultadoRepository_ShouldGetAllOk()
        {
            _resultado = ObjectMother.GetValidResultado();
            _resultadoInserido = _repository.Adicionar(_resultado);
            IEnumerable<Resultado> resultadoObtido = _repository.PegarTodos();

            resultadoObtido.Last().Id.Should().Be(_resultadoInserido.Id);
        }

        [Test]
        public void Test_ResultadoRepository_ShouldDeleteOk()
        {
            _resultado = ObjectMother.GetValidResultado();
            _resultadoInserido = _repository.Adicionar(_resultado);
            _repository.Deletar(_resultadoInserido);
            IEnumerable<Resultado> resultadoObtido = _repository.PegarTodos();

            resultadoObtido.Should().NotContain(_resultadoInserido);
        }

        [Test]
        public void Test_resultadoRepository_ShouldThrowOnUpdate()
        {
            _resultado = ObjectMother.GetValidResultado();
            _resultado.Id = 0;
            Action action = () => _repository.Atualizar(_resultado);

            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Test_resultadoRepository_ShouldThrowOnDelete()
        {
            _resultado = ObjectMother.GetValidResultado();
            _resultado.Id = 0;
            Action action = () => _repository.Deletar(_resultado);

            action.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Test_resultadoRepository_ShouldThrowOnGetById()
        {
            _resultado = ObjectMother.GetValidResultado();
            _resultado.Id = 0;
            Action action = () => _repository.ObterPorId(_resultado.Id);

            action.Should().Throw<IdentifierUndefinedException>();
        }
    }
}

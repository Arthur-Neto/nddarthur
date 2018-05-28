using FluentAssertions;
using Loterica.Aplicacao.Features.Resultados;
using Loterica.Common.Tests;
using Loterica.Dominio.Features.Apostas;
using Loterica.Dominio.Features.Concursos;
using Loterica.Dominio.Features.Resultados;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Loterica.Aplicacao.Tests.Features.Resultados
{
    [TestFixture]
    public class ResultadooServicoTests
    {
        ResultadoServico _servico;
        Mock<IResultadoRepository> _repository;
        Aposta _aposta;
        Concurso _concurso;
        Resultado _resultado;

        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<IResultadoRepository>();
            _servico = new ResultadoServico(_repository.Object);
            _concurso = ObjectMother.GetValidConcursoAberto();
            _aposta = ObjectMother.GetValidAposta(_concurso);
            _resultado = ObjectMother.GetValidResultado();
        }

        [Test]
        [Order(0)]
        public void Test_ResultadoServico_ShouldAddOk()
        {
            var idEsperadoNoBD = 2;
            _repository.Setup(x => x.Adicionar(_resultado)).Returns(new Resultado() { Id = idEsperadoNoBD });
            Resultado resultado = _servico.Adicionar(_resultado);

            _repository.Verify(x => x.Adicionar(_resultado));
            resultado.Id.Should().BeGreaterThan(0);
            resultado.Id.Should().Be(idEsperadoNoBD);
        }

        [Test]
        public void Test_ResultadoServico_ShouldGetOk()
        {
            var idEsperadoNoBD = 2;
            _repository.Setup(x => x.Adicionar(_resultado)).Returns(new Resultado() { Id = idEsperadoNoBD });
            _repository.Setup(x => x.ObterPorId(_resultado.Id)).Returns(_resultado);
            Resultado resultadoAdicionar = _servico.Adicionar(_resultado);
            Resultado resultadoGet = _servico.ConsultarPorId(_resultado.Id);

            _repository.Verify(x => x.ObterPorId(_resultado.Id));
            resultadoGet.Id.Should().Equals(resultadoAdicionar.Id);
        }

        [Test]
        [Order(1)]
        public void Test_ResultadoServico_ShouldGetAllOk()
        {
            var idEsperadoNoBD = 2;
            _repository.Setup(x => x.Adicionar(_resultado)).Returns(new Resultado() { Id = idEsperadoNoBD });
            _repository.Setup(x => x.PegarTodos()).Returns(new List<Resultado>() { _resultado });
            Resultado resultadoAdicionar = _servico.Adicionar(_resultado);
            IEnumerable<Resultado> resultadoGetAll = _servico.BuscarTodos();
            _repository.Verify(x => x.PegarTodos());

            resultadoGetAll.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void Test_ResultadoServico_ShouldUpdateOk()
        {
            var idEsperadoNoBD = 2;
            List<int> valorAtualizado = new List<int> { 01, 02, 03, 04, 05, 08 };
            _repository.Setup(x => x.Adicionar(_resultado)).Returns(new Resultado() { Id = idEsperadoNoBD });
            _repository.Setup(x => x.ObterPorId(_resultado.Id)).Returns(_resultado);
            _repository.Setup(x => x.Atualizar(_resultado)).Returns(new Resultado() { NumerosSorteados = { 01, 02, 03, 04, 05, 08 } });
            Resultado resultadoAdicionar = _servico.Adicionar(_resultado);
            Resultado resultadoGet = _servico.ConsultarPorId(_resultado.Id);
            resultadoGet.NumerosSorteados = valorAtualizado;
            Resultado resultadoAtualizar = _servico.Atualizar(resultadoGet);

            _repository.Verify(x => x.Atualizar(resultadoGet));
            resultadoGet.NumerosSorteados.Should().Equals(valorAtualizado);
        }

        [Test]
        public void Test_ResultadoServico_ShouldDeleteOk()
        {
            var idEsperadoNoBD = 2;
            _repository.Setup(x => x.Adicionar(_resultado)).Returns(new Resultado() { Id = idEsperadoNoBD });
            _repository.Setup(x => x.ObterPorId(_resultado.Id)).Returns(_resultado);
            _repository.Setup(x => x.Deletar(_resultado));
            Resultado resultadoAdicionar = _servico.Adicionar(_resultado);
            _servico.Excluir(_resultado);
            Resultado resultadoGet = _servico.ConsultarPorId(resultadoAdicionar.Id);

            _repository.Verify(x => x.Deletar(_resultado));

            resultadoGet.Should().BeNull();
        }
    }
}

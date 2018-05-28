using FluentAssertions;
using Loterica.Aplicacao.Features.Concursos;
using Loterica.Common.Tests;
using Loterica.Dominio.Features.Apostas;
using Loterica.Dominio.Features.Concursos;
using Loterica.Dominio.Features.Premios;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Loterica.Aplicacao.Tests.Features.Concursos
{
    [TestFixture]
    public class ConcursoServicoTests
    {
        ConcursoServico _servico;
        Mock<IConcursoRepository> _repository;
        Aposta _aposta;
        Concurso _concurso;

        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<IConcursoRepository>();
            _servico = new ConcursoServico(_repository.Object);
            _concurso = ObjectMother.GetValidConcursoAberto();
            _aposta = ObjectMother.GetValidAposta(_concurso);
        }

        [Test]
        [Order(0)]
        public void Test_ConcursoServico_ShouldAddOk()
        {
            var idEsperadoNoBD = 2;
            _repository.Setup(x => x.Adicionar(_concurso)).Returns(new Concurso() { Id = idEsperadoNoBD });
            Concurso resultado = _servico.Adicionar(_concurso);

            _repository.Verify(x => x.Adicionar(_concurso));
            resultado.Id.Should().BeGreaterThan(0);
            resultado.Id.Should().Be(idEsperadoNoBD);
        }

        [Test]
        public void Test_ConcursoServico_ShouldGetOk()
        {
            var idEsperadoNoBD = 2;
            _repository.Setup(x => x.Adicionar(_concurso)).Returns(new Concurso() { Id = idEsperadoNoBD });
            _repository.Setup(x => x.ObterPorId(_concurso.Id)).Returns(_concurso);
            Concurso resultadoAdicionar = _servico.Adicionar(_concurso);
            Concurso resultadoGet = _servico.ConsultarPorId(_concurso.Id);

            _repository.Verify(x => x.ObterPorId(_concurso.Id));
            resultadoGet.Id.Should().Equals(resultadoAdicionar.Id);
        }

        [Test]
        [Order(1)]
        public void Test_ConcursoServico_ShouldGetAllOk()
        {
            var idEsperadoNoBD = 2;
            _repository.Setup(x => x.Adicionar(_concurso)).Returns(new Concurso() { Id = idEsperadoNoBD });
            _repository.Setup(x => x.PegarTodos()).Returns(new List<Concurso>() { _concurso });
            Concurso resultadoAdicionar = _servico.Adicionar(_concurso);
            IEnumerable<Concurso> resultadoGetAll = _servico.BuscarTodos();
            _repository.Verify(x => x.PegarTodos());

            resultadoGetAll.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void Test_ConcursoServico_ShouldUpdateOk()
        {
            var idEsperadoNoBD = 2;
            var valorAtualizado = 500;
            _repository.Setup(x => x.Adicionar(_concurso)).Returns(new Concurso() { Id = idEsperadoNoBD });
            _repository.Setup(x => x.ObterPorId(_concurso.Id)).Returns(_concurso);
            _repository.Setup(x => x.Atualizar(_concurso)).Returns(new Concurso() { Premio = new Premio() { Total = 500 } });
            Concurso resultadoAdicionar = _servico.Adicionar(_concurso);
            Concurso resultadoGet = _servico.ConsultarPorId(_concurso.Id);
            resultadoGet.Premio.Total = valorAtualizado;
            Concurso resultadoAtualizar = _servico.Atualizar(resultadoGet);

            _repository.Verify(x => x.Atualizar(resultadoGet));
            resultadoGet.Premio.Total.Should().Be(valorAtualizado);
        }

        [Test]
        public void Test_ConcursoServico_ShouldDeleteOk()
        {
            var idEsperadoNoBD = 2;
            _repository.Setup(x => x.Adicionar(_concurso)).Returns(new Concurso() { Id = idEsperadoNoBD });
            _repository.Setup(x => x.ObterPorId(_concurso.Id)).Returns(_concurso);
            _repository.Setup(x => x.Deletar(_concurso));
            Concurso resultadoAdicionar = _servico.Adicionar(_concurso);
            _servico.Excluir(_concurso);
            Concurso resultadoGet = _servico.ConsultarPorId(resultadoAdicionar.Id);

            _repository.Verify(x => x.Deletar(_concurso));

            resultadoGet.Should().BeNull();
        }

        [Test]
        public void Test_ConcursoServico_ShouldGetFaturamento()
        {
            _repository.Setup(x => x.RelatorioFaturamento()).Returns(It.IsAny<string>);

            string result = _servico.RelatorioFaturamento();

            _repository.Verify(x => x.RelatorioFaturamento());
            result.Should().BeNull();
        }

        [Test]
        public void Test_ConcursoServico_ShouldGenerateCSVOk()
        {
            string caminho = "C:\\temp\\teste.csv";
            Action action = () => _servico.GerarCSVConcursos(caminho);

            action.Should().NotThrow();
        }
    }
}

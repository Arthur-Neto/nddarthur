using FluentAssertions;
using Loterica.Aplicacao.Features.Boloes;
using Loterica.Common.Tests;
using Loterica.Dominio.Features.Apostas;
using Loterica.Dominio.Features.Boloes;
using Loterica.Dominio.Features.Concursos;
using Loterica.Infra.Data.Features.Apostas;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Loterica.Aplicacao.Tests.Features.Boloes
{
    [TestFixture]
    public class ApostaServicoTests
    {
        BolaoServico _servico;
        Mock<IBolaoRepository> _repository;
        IApostaRepository _repositoryAposta;
        Aposta _aposta;
        Concurso _concurso;
        Bolao _bolao;

        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<IBolaoRepository>();
            _repositoryAposta = new ApostaRepository();
            _servico = new BolaoServico(_repository.Object);
            _concurso = ObjectMother.GetValidConcursoAberto();
            _aposta = ObjectMother.GetValidAposta(_concurso);
            _bolao = ObjectMother.GetBolaoValido();
        }

        [Test]
        public void Test_BolaoServico_ShouldAddOk()
        {
            var idEsperadoNoBD = 2;
            _repository.Setup(x => x.Adicionar(_bolao)).Returns(new Bolao() { Id = idEsperadoNoBD });
            Bolao resultado = _servico.Adicionar(_bolao);

            _repository.Verify(x => x.Adicionar(_bolao));
            resultado.Id.Should().BeGreaterThan(0);
            resultado.Id.Should().Be(idEsperadoNoBD);
        }

        [Test]
        public void Test_BolaoServico_ShouldGetOk()
        {
            var idEsperadoNoBD = 2;
            _repository.Setup(x => x.Adicionar(_bolao)).Returns(new Bolao() { Id = idEsperadoNoBD });
            _repository.Setup(x => x.ObterPorId(_bolao.Id)).Returns(_bolao);
            Bolao resultadoAdicionar = _servico.Adicionar(_bolao);
            Bolao resultadoGet = _servico.ConsultarPorId(_bolao.Id);

            _repository.Verify(x => x.ObterPorId(_aposta.Id));
            resultadoGet.Id.Should().Equals(resultadoAdicionar.Id);
        }

        [Test]
        public void Test_BolaoServico_ShouldGetAllOk()
        {
            var idEsperadoNoBD = 2;
            _repository.Setup(x => x.Adicionar(_bolao)).Returns(new Bolao() { Id = idEsperadoNoBD });
            _repository.Setup(x => x.PegarTodos()).Returns(new List<Bolao>() { _bolao });
            Bolao resultadoAdicionar = _servico.Adicionar(_bolao);
            IEnumerable<Bolao> resultadoGetAll = _servico.BuscarTodos();
            _repository.Verify(x => x.PegarTodos());

            resultadoGetAll.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void Test_BolaoServico_ShouldThrowOnUpdate()
        {
            Action action = () => _servico.Atualizar(_bolao);

            action.Should().Throw<NotImplementedException>();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void Test_BolaoServico_ShouldDeleteOk()
        {
            _bolao = ObjectMother.GetBolaoValido();
            var idEsperadoNoBD = 2;
            _repository.Setup(x => x.Adicionar(_bolao)).Returns(new Bolao() { Id = idEsperadoNoBD });
            _repository.Setup(x => x.ObterPorId(_bolao.Id)).Returns(_bolao);
            _repository.Setup(x => x.Deletar(_bolao));
            Bolao resultadoAdicionar = _servico.Adicionar(_bolao);
            foreach (var item in resultadoAdicionar.Apostas)
            {
                _repositoryAposta.Deletar(item);
            }
            _servico.Excluir(_bolao);
            Bolao resultadoGet = _servico.ConsultarPorId(resultadoAdicionar.Id);

            _repository.Verify(x => x.Deletar(_bolao));

            resultadoGet.Should().BeNull();
        }

        [Test]
        public void Test_BolaoServico_ShouldGenerateBolao()
        {
            var idEsperadoNoBD = 2;
            _repository.Setup(x => x.Adicionar(_bolao)).Returns(new Bolao() { Id = idEsperadoNoBD });
            _repository.Setup(x => x.ObterPorId(idEsperadoNoBD)).Returns(new Bolao() { Id = idEsperadoNoBD });

            _servico.GerarBolao(2, _concurso);
            Bolao _bolaoGet = _servico.ConsultarPorId(idEsperadoNoBD);

            _bolaoGet.Id.Should().Be(idEsperadoNoBD);
        }
    }
}

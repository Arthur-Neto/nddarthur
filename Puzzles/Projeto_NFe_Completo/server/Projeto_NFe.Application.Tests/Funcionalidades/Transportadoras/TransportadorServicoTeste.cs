using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Application.Funcionalidades.Transportadoras;
using Projeto_NFe.Application.Funcionalidades.Transportadoras.Comandos;
using Projeto_NFe.Application.Mapeador;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projeto_NFe.Application.Tests.Funcionalidades.Transportadors
{
    [TestFixture]
    public class TransportadorServicoTeste
    {
        Mock<IEnderecoRepositorio> _mockEnderecoRepositorio;
        Mock<ITransportadorRepositorio> _mockRepositorioTransportador;
        ITransportadorServico _servicoTransportador;
        Mock<Transportador> _mockTransportador;
        Mock<Endereco> _mockEndereco;

        [SetUp]
        public void InicializarTestes()
        {
            InicializadorAutoMapper.Resetar();
            InicializadorAutoMapper.Inicializar();
            _mockRepositorioTransportador = new Mock<ITransportadorRepositorio>();
            _mockEnderecoRepositorio = new Mock<IEnderecoRepositorio>();
            _mockTransportador = new Mock<Transportador>();
            _mockEndereco = new Mock<Endereco>();
            _mockRepositorioTransportador = new Mock<ITransportadorRepositorio>();
            _servicoTransportador = new TransportadorServico(_mockRepositorioTransportador.Object, _mockEnderecoRepositorio.Object);
        }

        [Test]
        public void Transportador_Aplicacao_Adicionar_Sucesso()
        {
            Mock<TransportadorAdicionarComando> _mockTransportadorAdicionarComando = new Mock<TransportadorAdicionarComando>();

            _mockRepositorioTransportador.Setup(mrd => mrd.Adicionar(It.IsAny<Transportador>())).Returns(_mockTransportador.Object.Id);

            _servicoTransportador.Adicionar(_mockTransportadorAdicionarComando.Object);

            _mockRepositorioTransportador.Verify(mrd => mrd.Adicionar(It.IsAny<Transportador>()));
        }

        [Test]
        public void Transportador_Aplicacao_Atualizar_Sucesso()
        {
            bool retorno = true;
            Mock<TransportadorEditarComando> _mockTransportadorAtualizarComando = new Mock<TransportadorEditarComando>();
            _mockTransportadorAtualizarComando.Setup(mda => mda.Endereco).Returns(_mockEndereco.Object);
            _mockRepositorioTransportador.Setup(mrd => mrd.BuscarPorId(_mockTransportadorAtualizarComando.Object.Id)).Returns(_mockTransportador.Object);
            _mockEnderecoRepositorio.Setup(mre => mre.BuscarPorId(_mockTransportadorAtualizarComando.Object.Endereco.Id)).Returns(_mockEndereco.Object);
            _mockRepositorioTransportador.Setup(mrd => mrd.Atualizar(It.IsAny<Transportador>())).Returns(retorno);

            bool resultado = _servicoTransportador.Atualizar(_mockTransportadorAtualizarComando.Object);

            resultado.Should().BeTrue();
            _mockRepositorioTransportador.Verify(mrd => mrd.Atualizar(It.IsAny<Transportador>()));
            _mockRepositorioTransportador.Verify(mrd => mrd.BuscarPorId(_mockTransportadorAtualizarComando.Object.Id));
            _mockRepositorioTransportador.VerifyNoOtherCalls();
            _mockEnderecoRepositorio.Verify(mre => mre.BuscarPorId(_mockTransportadorAtualizarComando.Object.Endereco.Id));
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Transportador_Aplicacao_Atualizar_ExcecaoNaoEncontrado_Falha()
        {
            Transportador destinatarioNulo = null;

            Mock<TransportadorEditarComando> _mockTransportadorAtualizarComando = new Mock<TransportadorEditarComando>();
            _mockRepositorioTransportador.Setup(mrd => mrd.BuscarPorId(_mockTransportadorAtualizarComando.Object.Id)).Returns(destinatarioNulo);

            Action acaoParaRetornarExcecaoIdentificadorIndefinido = () => _servicoTransportador.Atualizar(_mockTransportadorAtualizarComando.Object);

            acaoParaRetornarExcecaoIdentificadorIndefinido.Should().Throw<ExcecaoNaoEncontrado>();

            _mockRepositorioTransportador.Verify(mrd => mrd.BuscarPorId(_mockTransportadorAtualizarComando.Object.Id), Times.Once);
            _mockRepositorioTransportador.VerifyNoOtherCalls();
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Transportador_Aplicacao_Excluir_ExcecaoNaoEncontrado_Falha()
        {
            Transportador destinatarioNulo = null;
            Mock<TransportadorRemoverComando> _mockTransportadorRemoverComando = new Mock<TransportadorRemoverComando>();
            _mockRepositorioTransportador.Setup(mrd => mrd.BuscarPorId(_mockTransportadorRemoverComando.Object.Id)).Returns(destinatarioNulo);

            Action acaoParaRetornarExcecaoNaoEncontrado = () => _servicoTransportador.Excluir(_mockTransportadorRemoverComando.Object);

            acaoParaRetornarExcecaoNaoEncontrado.Should().Throw<ExcecaoNaoEncontrado>();

            _mockRepositorioTransportador.Verify(mrd => mrd.BuscarPorId(_mockTransportadorRemoverComando.Object.Id), Times.Once);
            _mockRepositorioTransportador.VerifyNoOtherCalls();
            _mockEnderecoRepositorio.VerifyNoOtherCalls();

        }

        [Test]
        public void Transportador_Aplicacao_Excluir_Sucesso()
        {
            Transportador destinatarioNulo = null;
            Mock<TransportadorRemoverComando> _mockTransportadorRemoverComando = new Mock<TransportadorRemoverComando>();
            _mockRepositorioTransportador.SetupSequence(mrd => mrd.BuscarPorId(_mockTransportadorRemoverComando.Object.Id))
                .Returns(_mockTransportador.Object)
                .Returns(destinatarioNulo);

            _mockRepositorioTransportador.Setup(mrd => mrd.Excluir(_mockTransportador.Object));

            bool resultado = _servicoTransportador.Excluir(_mockTransportadorRemoverComando.Object);

            resultado.Should().BeTrue();
            _mockRepositorioTransportador.Verify(mrd => mrd.Excluir(_mockTransportador.Object), Times.Once);
            _mockRepositorioTransportador.Verify(mrd => mrd.BuscarPorId(_mockTransportadorRemoverComando.Object.Id));
            _mockRepositorioTransportador.VerifyNoOtherCalls();
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Transportador_Aplicacao_Excluir_DeveRetornarFalso()
        {
            Mock<TransportadorRemoverComando> _mockTransportadorRemoverComando = new Mock<TransportadorRemoverComando>();
            _mockRepositorioTransportador.Setup(mrd => mrd.BuscarPorId(_mockTransportadorRemoverComando.Object.Id))
                .Returns(_mockTransportador.Object);

            _mockRepositorioTransportador.Setup(mrd => mrd.Excluir(_mockTransportador.Object));

            bool resultado = _servicoTransportador.Excluir(_mockTransportadorRemoverComando.Object);

            resultado.Should().BeFalse();
            _mockRepositorioTransportador.Verify(mrd => mrd.Excluir(_mockTransportador.Object), Times.Once);
            _mockRepositorioTransportador.Verify(mrd => mrd.BuscarPorId(_mockTransportadorRemoverComando.Object.Id));
            _mockRepositorioTransportador.VerifyNoOtherCalls();
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Transportador_Aplicacao_BuscarPorId_Sucesso()
        {
            long id = 1;

            _mockRepositorioTransportador.Setup(er => er.BuscarPorId(id)).Returns(_mockTransportador.Object);

            _servicoTransportador.BuscarPorId(id);

            _mockRepositorioTransportador.Verify(er => er.BuscarPorId(id), Times.Once);
            _mockRepositorioTransportador.VerifyNoOtherCalls();
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Transportador_Aplicacao_BuscarPorId_ExcecaoIdentificadorIndefinido_Falha()
        {
            long id = 0;
            Transportador destinatarioNulo = null;
            _mockRepositorioTransportador.Setup(er => er.BuscarPorId(id)).Returns(destinatarioNulo);

            Action acaoParaRetornarExcecaoIdentificadorIndefinido = () => _servicoTransportador.BuscarPorId(id);

            acaoParaRetornarExcecaoIdentificadorIndefinido.Should().Throw<ExcecaoNaoEncontrado>();
            _mockRepositorioTransportador.Verify(er => er.BuscarPorId(id), Times.Once);
            _mockRepositorioTransportador.VerifyNoOtherCalls();
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Transportador_Aplicacao_BuscarTodos_Sucesso()
        {
            List<Transportador> transportadores = new List<Transportador>()
            {
                _mockTransportador.Object,
                _mockTransportador.Object
            };

            _mockRepositorioTransportador.Setup(er => er.BuscarTodos()).Returns(transportadores.AsQueryable);

            IQueryable<Transportador> transportadoresEncontrados = _servicoTransportador.BuscarTodos();

            transportadoresEncontrados.Should().NotBeNullOrEmpty();
            transportadoresEncontrados.Should().HaveCount(transportadores.Count);
            _mockRepositorioTransportador.Verify(er => er.BuscarTodos());
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
        }
    }
}

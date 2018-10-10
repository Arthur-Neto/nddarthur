using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Application.Funcionalidades.Destinatarios;
using Projeto_NFe.Application.Funcionalidades.Destinatarios.Comandos;
using Projeto_NFe.Application.Mapeador;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projeto_NFe.Application.Tests.Funcionalidades.Destinatarios
{
    [TestFixture]
    public class DestinatarioServicoTeste
    {
        Mock<IEnderecoRepositorio> _mockEnderecoRepositorio;
        Mock<IDestinatarioRepositorio> _mockRepositorioDestinatario;
        IDestinatarioServico _servicoDestinatario;
        Mock<Destinatario> _mockDestinatario;
        Mock<Endereco> _mockEndereco;

        [SetUp]
        public void InicializarTestes()
        {
            InicializadorAutoMapper.Resetar();
            InicializadorAutoMapper.Inicializar();
            _mockRepositorioDestinatario = new Mock<IDestinatarioRepositorio>();
            _mockEnderecoRepositorio = new Mock<IEnderecoRepositorio>();
            _mockDestinatario = new Mock<Destinatario>();
            _mockEndereco = new Mock<Endereco>();
            _mockRepositorioDestinatario = new Mock<IDestinatarioRepositorio>();
            _servicoDestinatario = new DestinatarioServico(_mockRepositorioDestinatario.Object, _mockEnderecoRepositorio.Object);
        }

        [Test]
        public void Destinatario_Aplicacao_Adicionar_Sucesso()
        {
            Mock<DestinatarioAdicionarComando> _mockDestinatarioAdicionarComando = new Mock<DestinatarioAdicionarComando>();

            _mockRepositorioDestinatario.Setup(mrd => mrd.Adicionar(It.IsAny<Destinatario>())).Returns(_mockDestinatario.Object.Id);

            _servicoDestinatario.Adicionar(_mockDestinatarioAdicionarComando.Object);

            _mockRepositorioDestinatario.Verify(mrd => mrd.Adicionar(It.IsAny<Destinatario>()));
        }

        [Test]
        public void Destinatario_Aplicacao_Atualizar_Sucesso()
        {
            bool retorno = true;
            Mock<DestinatarioEditarComando> _mockDestinatarioAtualizarComando = new Mock<DestinatarioEditarComando>();
            _mockDestinatarioAtualizarComando.Setup(mda => mda.Endereco).Returns(_mockEndereco.Object);
            _mockRepositorioDestinatario.Setup(mrd => mrd.BuscarPorId(_mockDestinatarioAtualizarComando.Object.Id)).Returns(_mockDestinatario.Object);
            _mockEnderecoRepositorio.Setup(mre => mre.BuscarPorId(_mockDestinatarioAtualizarComando.Object.Endereco.Id)).Returns(_mockEndereco.Object);
            _mockRepositorioDestinatario.Setup(mrd => mrd.Atualizar(It.IsAny<Destinatario>())).Returns(retorno);

            bool result = _servicoDestinatario.Atualizar(_mockDestinatarioAtualizarComando.Object);

            result.Should().BeTrue();
            _mockRepositorioDestinatario.Verify(mrd => mrd.Atualizar(It.IsAny<Destinatario>()));
            _mockRepositorioDestinatario.Verify(mrd => mrd.BuscarPorId(_mockDestinatarioAtualizarComando.Object.Id));
            _mockRepositorioDestinatario.VerifyNoOtherCalls();
            _mockEnderecoRepositorio.Verify(mre => mre.BuscarPorId(_mockDestinatarioAtualizarComando.Object.Endereco.Id));
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Destinatario_Aplicacao_Atualizar_ExcecaoNaoEncontrado_Falha()
        {
            Destinatario destinatarioNulo = null;

            Mock<DestinatarioEditarComando> _mockDestinatarioAtualizarComando = new Mock<DestinatarioEditarComando>();
            _mockRepositorioDestinatario.Setup(mrd => mrd.BuscarPorId(_mockDestinatarioAtualizarComando.Object.Id)).Returns(destinatarioNulo);

            Action acaoParaRetornarExcecaoIdentificadorIndefinido = () => _servicoDestinatario.Atualizar(_mockDestinatarioAtualizarComando.Object);

            acaoParaRetornarExcecaoIdentificadorIndefinido.Should().Throw<ExcecaoNaoEncontrado>();

            _mockRepositorioDestinatario.Verify(mrd => mrd.BuscarPorId(_mockDestinatarioAtualizarComando.Object.Id), Times.Once);
            _mockRepositorioDestinatario.VerifyNoOtherCalls();
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Destinatario_Aplicacao_Excluir_ExcecaoNaoEncontrado_Falha()
        {
            Destinatario destinatarioNulo = null;
            Mock<DestinatarioRemoverComando> _mockDestinatarioRemoverComando = new Mock<DestinatarioRemoverComando>();
            _mockRepositorioDestinatario.Setup(mrd => mrd.BuscarPorId(_mockDestinatarioRemoverComando.Object.Id)).Returns(destinatarioNulo);

            Action acaoParaRetornarExcecaoNaoEncontrado = () => _servicoDestinatario.Excluir(_mockDestinatarioRemoverComando.Object);

            acaoParaRetornarExcecaoNaoEncontrado.Should().Throw<ExcecaoNaoEncontrado>();

            _mockRepositorioDestinatario.Verify(mrd => mrd.BuscarPorId(_mockDestinatarioRemoverComando.Object.Id), Times.Once);
            _mockRepositorioDestinatario.VerifyNoOtherCalls();
            _mockEnderecoRepositorio.VerifyNoOtherCalls();

        }

        [Test]
        public void Destinatario_Aplicacao_Excluir_Sucesso()
        {
            Destinatario destinatarioNulo = null;
            Mock<DestinatarioRemoverComando> _mockDestinatarioRemoverComando = new Mock<DestinatarioRemoverComando>();
            _mockRepositorioDestinatario.SetupSequence(mrd => mrd.BuscarPorId(_mockDestinatarioRemoverComando.Object.Id))
                .Returns(_mockDestinatario.Object)
                .Returns(destinatarioNulo);

            _mockRepositorioDestinatario.Setup(mrd => mrd.Excluir(_mockDestinatario.Object));

            bool resultado =_servicoDestinatario.Excluir(_mockDestinatarioRemoverComando.Object);

            resultado.Should().BeTrue();
            _mockRepositorioDestinatario.Verify(mrd => mrd.Excluir(_mockDestinatario.Object), Times.Once);
            _mockRepositorioDestinatario.Verify(mrd => mrd.BuscarPorId(_mockDestinatarioRemoverComando.Object.Id));
            _mockRepositorioDestinatario.VerifyNoOtherCalls();
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Destinatario_Aplicacao_Excluir_DeveRetornarFalso()
        {
            Mock<DestinatarioRemoverComando> _mockDestinatarioRemoverComando = new Mock<DestinatarioRemoverComando>();
            _mockRepositorioDestinatario.Setup(mrd => mrd.BuscarPorId(_mockDestinatarioRemoverComando.Object.Id))
                .Returns(_mockDestinatario.Object);

            _mockRepositorioDestinatario.Setup(mrd => mrd.Excluir(_mockDestinatario.Object));

            bool resultado = _servicoDestinatario.Excluir(_mockDestinatarioRemoverComando.Object);

            resultado.Should().BeFalse();
            _mockRepositorioDestinatario.Verify(mrd => mrd.Excluir(_mockDestinatario.Object), Times.Once);
            _mockRepositorioDestinatario.Verify(mrd => mrd.BuscarPorId(_mockDestinatarioRemoverComando.Object.Id));
            _mockRepositorioDestinatario.VerifyNoOtherCalls();
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Destinatario_Aplicacao_BuscarPorId_Sucesso()
        {
            long id = 1;

            _mockRepositorioDestinatario.Setup(er => er.BuscarPorId(id)).Returns(_mockDestinatario.Object);

            _servicoDestinatario.BuscarPorId(id);

            _mockRepositorioDestinatario.Verify(er => er.BuscarPorId(id), Times.Once);
            _mockRepositorioDestinatario.VerifyNoOtherCalls();
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Destinatario_Aplicacao_BuscarPorId_ExcecaoIdentificadorIndefinido_Falha()
        {
            long id = 0;
            Destinatario destinatarioNulo = null;
            _mockRepositorioDestinatario.Setup(er => er.BuscarPorId(id)).Returns(destinatarioNulo);

            Action acaoParaRetornarExcecaoIdentificadorIndefinido = () => _servicoDestinatario.BuscarPorId(id);

            acaoParaRetornarExcecaoIdentificadorIndefinido.Should().Throw<ExcecaoNaoEncontrado>();
            _mockRepositorioDestinatario.Verify(er => er.BuscarPorId(id), Times.Once);
            _mockRepositorioDestinatario.VerifyNoOtherCalls();
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Destinatario_Aplicacao_BuscarTodos_Sucesso()
        {
            List<Destinatario> destinatarios = new List<Destinatario>()
            {
                _mockDestinatario.Object,
                _mockDestinatario.Object
            };

            _mockRepositorioDestinatario.Setup(er => er.BuscarTodos()).Returns(destinatarios.AsQueryable);

            IQueryable<Destinatario> destinatariosEncontrados = _servicoDestinatario.BuscarTodos();

            destinatariosEncontrados.Should().NotBeNullOrEmpty();
            destinatariosEncontrados.Should().HaveCount(destinatarios.Count);
            _mockRepositorioDestinatario.Verify(er => er.BuscarTodos());
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
        }
    }
}

using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Application.Funcionalidades.Emitentes;
using Projeto_NFe.Application.Funcionalidades.Emitentes.Comandos;
using Projeto_NFe.Application.Mapeador;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projeto_NFe.Application.Tests.Funcionalidades.Emitentes
{
    [TestFixture]
    public class EmitenteServicoTeste
    {
        Mock<IEnderecoRepositorio> _mockEnderecoRepositorio;
        Mock<IEmitenteRepositorio> _mockRepositorioEmitente;
        IEmitenteServico _servicoEmitente;
        Mock<Emitente> _mockEmitente;
        Mock<Endereco> _mockEndereco;

        [SetUp]
        public void InicializarTestes()
        {
            InicializadorAutoMapper.Resetar();
            InicializadorAutoMapper.Inicializar();
            _mockRepositorioEmitente = new Mock<IEmitenteRepositorio>();
            _mockEnderecoRepositorio = new Mock<IEnderecoRepositorio>();
            _mockEmitente = new Mock<Emitente>();
            _mockEndereco = new Mock<Endereco>();
            _mockRepositorioEmitente = new Mock<IEmitenteRepositorio>();
            _servicoEmitente = new EmitenteServico(_mockRepositorioEmitente.Object, _mockEnderecoRepositorio.Object);
        }

        [Test]
        public void Emitente_Aplicacao_Adicionar_Sucesso()
        {
            Mock<EmitenteAdicionarComando> _mockEmitenteAdicionarComando = new Mock<EmitenteAdicionarComando>();

            _mockRepositorioEmitente.Setup(mrd => mrd.Adicionar(It.IsAny<Emitente>())).Returns(_mockEmitente.Object.Id);

            _servicoEmitente.Adicionar(_mockEmitenteAdicionarComando.Object);

            _mockRepositorioEmitente.Verify(mrd => mrd.Adicionar(It.IsAny<Emitente>()));
        }

        [Test]
        public void Emitente_Aplicacao_Atualizar_Sucesso()
        {
            bool retorno = true;
            Mock<EmitenteEditarComando> _mockEmitenteAtualizarComando = new Mock<EmitenteEditarComando>();
            _mockEmitenteAtualizarComando.Setup(mda => mda.Endereco).Returns(_mockEndereco.Object);
            _mockRepositorioEmitente.Setup(mrd => mrd.BuscarPorId(_mockEmitenteAtualizarComando.Object.Id)).Returns(_mockEmitente.Object);
            _mockEnderecoRepositorio.Setup(mre => mre.BuscarPorId(_mockEmitenteAtualizarComando.Object.Endereco.Id)).Returns(_mockEndereco.Object);
            _mockRepositorioEmitente.Setup(mrd => mrd.Atualizar(It.IsAny<Emitente>())).Returns(retorno);

            bool resultado = _servicoEmitente.Atualizar(_mockEmitenteAtualizarComando.Object);

            resultado.Should().BeTrue();
            _mockRepositorioEmitente.Verify(mrd => mrd.Atualizar(It.IsAny<Emitente>()));
            _mockRepositorioEmitente.Verify(mrd => mrd.BuscarPorId(_mockEmitenteAtualizarComando.Object.Id));
            _mockRepositorioEmitente.VerifyNoOtherCalls();
            _mockEnderecoRepositorio.Verify(mre => mre.BuscarPorId(_mockEmitenteAtualizarComando.Object.Endereco.Id));
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Emitente_Aplicacao_Atualizar_ExcecaoNaoEncontrado_Falha()
        {
            Emitente destinatarioNulo = null;

            Mock<EmitenteEditarComando> _mockEmitenteAtualizarComando = new Mock<EmitenteEditarComando>();
            _mockRepositorioEmitente.Setup(mrd => mrd.BuscarPorId(_mockEmitenteAtualizarComando.Object.Id)).Returns(destinatarioNulo);

            Action acaoParaRetornarExcecaoIdentificadorIndefinido = () => _servicoEmitente.Atualizar(_mockEmitenteAtualizarComando.Object);

            acaoParaRetornarExcecaoIdentificadorIndefinido.Should().Throw<ExcecaoNaoEncontrado>();

            _mockRepositorioEmitente.Verify(mrd => mrd.BuscarPorId(_mockEmitenteAtualizarComando.Object.Id), Times.Once);
            _mockRepositorioEmitente.VerifyNoOtherCalls();
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Emitente_Aplicacao_Excluir_ExcecaoNaoEncontrado_Falha()
        {
            Emitente destinatarioNulo = null;
            Mock<EmitenteRemoverComando> _mockEmitenteRemoverComando = new Mock<EmitenteRemoverComando>();
            _mockRepositorioEmitente.Setup(mrd => mrd.BuscarPorId(_mockEmitenteRemoverComando.Object.Id)).Returns(destinatarioNulo);

            Action acaoParaRetornarExcecaoNaoEncontrado = () => _servicoEmitente.Excluir(_mockEmitenteRemoverComando.Object);

            acaoParaRetornarExcecaoNaoEncontrado.Should().Throw<ExcecaoNaoEncontrado>();

            _mockRepositorioEmitente.Verify(mrd => mrd.BuscarPorId(_mockEmitenteRemoverComando.Object.Id), Times.Once);
            _mockRepositorioEmitente.VerifyNoOtherCalls();
            _mockEnderecoRepositorio.VerifyNoOtherCalls();

        }

        [Test]
        public void Emitente_Aplicacao_Excluir_Sucesso()
        {
            Emitente destinatarioNulo = null;
            Mock<EmitenteRemoverComando> _mockEmitenteRemoverComando = new Mock<EmitenteRemoverComando>();
            _mockRepositorioEmitente.SetupSequence(mrd => mrd.BuscarPorId(_mockEmitenteRemoverComando.Object.Id))
                .Returns(_mockEmitente.Object)
                .Returns(destinatarioNulo);

            _mockRepositorioEmitente.Setup(mrd => mrd.Excluir(_mockEmitente.Object));

            bool resultado = _servicoEmitente.Excluir(_mockEmitenteRemoverComando.Object);

            resultado.Should().BeTrue();
            _mockRepositorioEmitente.Verify(mrd => mrd.Excluir(_mockEmitente.Object), Times.Once);
            _mockRepositorioEmitente.Verify(mrd => mrd.BuscarPorId(_mockEmitenteRemoverComando.Object.Id));
            _mockRepositorioEmitente.VerifyNoOtherCalls();
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Emitente_Aplicacao_Excluir_DeveRetornarFalso()
        {
            Mock<EmitenteRemoverComando> _mockEmitenteRemoverComando = new Mock<EmitenteRemoverComando>();
            _mockRepositorioEmitente.Setup(mrd => mrd.BuscarPorId(_mockEmitenteRemoverComando.Object.Id))
                .Returns(_mockEmitente.Object);

            _mockRepositorioEmitente.Setup(mrd => mrd.Excluir(_mockEmitente.Object));

            bool resultado = _servicoEmitente.Excluir(_mockEmitenteRemoverComando.Object);

            resultado.Should().BeFalse();
            _mockRepositorioEmitente.Verify(mrd => mrd.Excluir(_mockEmitente.Object), Times.Once);
            _mockRepositorioEmitente.Verify(mrd => mrd.BuscarPorId(_mockEmitenteRemoverComando.Object.Id));
            _mockRepositorioEmitente.VerifyNoOtherCalls();
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Emitente_Aplicacao_BuscarPorId_Sucesso()
        {
            long id = 1;

            _mockRepositorioEmitente.Setup(er => er.BuscarPorId(id)).Returns(_mockEmitente.Object);

            _servicoEmitente.BuscarPorId(id);

            _mockRepositorioEmitente.Verify(er => er.BuscarPorId(id), Times.Once);
            _mockRepositorioEmitente.VerifyNoOtherCalls();
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Emitente_Aplicacao_BuscarPorId_ExcecaoIdentificadorIndefinido_Falha()
        {
            long id = 0;
            Emitente destinatarioNulo = null;
            _mockRepositorioEmitente.Setup(er => er.BuscarPorId(id)).Returns(destinatarioNulo);

            Action acaoParaRetornarExcecaoIdentificadorIndefinido = () => _servicoEmitente.BuscarPorId(id);

            acaoParaRetornarExcecaoIdentificadorIndefinido.Should().Throw<ExcecaoNaoEncontrado>();
            _mockRepositorioEmitente.Verify(er => er.BuscarPorId(id), Times.Once);
            _mockRepositorioEmitente.VerifyNoOtherCalls();
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Emitente_Aplicacao_BuscarTodos_Sucesso()
        {
            List<Emitente> emitentes = new List<Emitente>()
            {
                _mockEmitente.Object,
                _mockEmitente.Object
            };

            _mockRepositorioEmitente.Setup(er => er.BuscarTodos()).Returns(emitentes.AsQueryable);

            IQueryable<Emitente> emitentesEncontrados = _servicoEmitente.BuscarTodos();

            emitentesEncontrados.Should().NotBeNullOrEmpty();
            emitentesEncontrados.Should().HaveCount(emitentes.Count);
            _mockRepositorioEmitente.Verify(er => er.BuscarTodos());
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
        }
    }
}

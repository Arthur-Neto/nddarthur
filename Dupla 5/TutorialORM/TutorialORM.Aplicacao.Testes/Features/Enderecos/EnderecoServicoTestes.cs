using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TutorialORM.Aplicacao.Features.Enderecos;
using TutorialORM.Common.Testes.Features;
using TutorialORM.Dominio.Exceptions;
using TutorialORM.Dominio.Features.Enderecos;
using TutorialORM.Infra.Data.Features.Enderecos;

namespace TutorialORM.Aplicacao.Testes.Features.Enderecos
{
    [TestFixture]
    public class EnderecoServicoTestes
    {
        Mock<IEnderecoRepositorio> repositorio;
        Endereco endereco;
        EnderecoServico servico;

        [SetUp]
        public void SetUp()
        {
            repositorio = new Mock<IEnderecoRepositorio>();
            servico = new EnderecoServico(repositorio.Object);
        }

        [Test]
        public void Endereco_Aplicacao_Salvar_NaoDeveJogarExcecao()
        {
            var id = 1;
            endereco = ObjectMother.ObterEnderecoValido();
            repositorio.Setup(er => er.Salvar(endereco)).Returns(new Endereco { Id = id });

            var enderecoSalva = servico.Salvar(endereco);

            enderecoSalva.Id.Should().Be(id);
            repositorio.Verify(er => er.Salvar(endereco));
            repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Endereco_Aplicacao_PegarPorId_NaoDeveJogarExcecao()
        {
            var id = 1;
            repositorio.Setup(er => er.PegarPorId(id)).Returns(new Endereco { Id = id });

            var endereco = servico.PegarPorId(id);

            endereco.Id.Should().Be(id);
            repositorio.Verify(er => er.PegarPorId(id));
            repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Endereco_Aplicacao_PegarPorId_DeveJogarExcecaoIdentificadorInvalido()
        {
            var id = 0;

            Action acao = () => servico.PegarPorId(id);

            acao.Should().Throw<IdentificadorInvalidoException>();
            repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Endereco_Aplicacao_PegarTodos_NaoDeveJogarExcecao()
        {
            var id = 1;
            repositorio.Setup(er => er.PegarTodos()).Returns(new List<Endereco> { new Endereco { Id = id } });

            var enderecos = servico.PegarTodos();

            enderecos.First().Id.Should().Be(id);
            repositorio.Verify(er => er.PegarTodos());
            repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Endereco_Aplicacao_Atualizar_NaoDeveJogarExcecao()
        {
            endereco = ObjectMother.ObterEnderecoValido();
            endereco.Cidade = "atualizado";
            endereco.Id = 1;
            repositorio.Setup(er => er.Atualizar(endereco)).Returns(new Endereco { Cidade = "atualizado" });

            var enderecoAtualizada = servico.Atualizar(endereco);

            enderecoAtualizada.Cidade.Should().Be(endereco.Cidade);
            repositorio.Verify(er => er.Atualizar(endereco));
            repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Endereco_Aplicacao_Atualizar_DeveJogarIdentificadorInvalidoExcecao()
        {
            endereco = ObjectMother.ObterEnderecoValido();
            endereco.Id = 0;

            Action acao = () => servico.Atualizar(endereco);

            acao.Should().Throw<IdentificadorInvalidoException>();
            repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Endereco_Aplicacao_Deletar_NaoDeveJogarExcecao()
        {
            endereco = ObjectMother.ObterEnderecoValido();
            endereco.Id = 1;
            repositorio.Setup(er => er.Deletar(endereco));
            repositorio.Setup(er => er.PegarPorId(endereco.Id));
            repositorio.Setup(er => er.VerificaDependencia(endereco));

            Action acao = () => servico.Deletar(endereco);

            var enderecoDeletada = servico.PegarPorId(endereco.Id);

            acao.Should().NotThrow<Exception>();
            enderecoDeletada.Should().BeNull();
            repositorio.Verify(er => er.VerificaDependencia(endereco));
            repositorio.Verify(er => er.Deletar(endereco));
            repositorio.Verify(er => er.PegarPorId(endereco.Id));
            repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Endereco_Aplicacao_Deletar_DeveJogarExcecaoEnderecoReferenciado()
        {
            endereco = ObjectMother.ObterEnderecoValido();
            endereco.Id = 1;

            repositorio.Setup(er => er.Deletar(endereco)).Throws<EnderecoReferenciadoException>();
            repositorio.Setup(er => er.VerificaDependencia(endereco));

            Action acao = () => servico.Deletar(endereco);

            acao.Should().Throw<EnderecoReferenciadoException>();
            repositorio.Verify(er => er.Deletar(endereco));
            repositorio.Verify(er => er.VerificaDependencia(endereco));
            repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Endereco_Aplicacao_Deletar_DeveJogarIdentificadorInvalidoExcecao()
        {
            endereco = ObjectMother.ObterEnderecoValido();
            endereco.Id = 0;

            Action acao = () => servico.Deletar(endereco);

            acao.Should().Throw<IdentificadorInvalidoException>();
            repositorio.VerifyNoOtherCalls();
        }
    }
}

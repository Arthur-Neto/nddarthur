using FluentAssertions;
using Moq;
using NFe.Aplicacao.Features.Destinatarios;
using NFe.Common.Testes.Features;
using NFe.Dominio.Exceptions;
using NFe.Dominio.Features.Destinatarios;
using NFe.Dominio.Features.Enderecos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NFe.Aplicacao.Testes.Features.Destinatarios
{
    [TestFixture]
    public class DestinatarioAplicacaoTeste
    {
        DestinatarioServico destinatarioServico;
        Mock<IDestinatarioRepositorio> mockRepositorio;
        Mock<IEnderecoRepositorio> mockEnderecoRepostorio;

        [SetUp]
        public void InitializeObjects()
        {
            mockRepositorio = new Mock<IDestinatarioRepositorio>();
            mockEnderecoRepostorio = new Mock<IEnderecoRepositorio>();
            destinatarioServico = new DestinatarioServico(mockRepositorio.Object, mockEnderecoRepostorio.Object);
        }

        [Test]
        public void Destinatario_Aplicacao_SalvarDestinatarioComCnpj_DeveFuncionar()
        {
            var id = 1;
            Destinatario destinatario = ObjectMother.ObtemDestinatarioCpfVazio();
            destinatario.Id = 0;
            mockRepositorio.Setup(m => m.Salvar(destinatario)).Returns(new Destinatario { Id = 1 });
            mockRepositorio.Setup(m => m.PegarPorId(id)).Returns(new Destinatario { Id = 1 });

            Destinatario result = destinatarioServico.Salvar(destinatario);

            result.Id.Should().BeGreaterThan(0);
            mockRepositorio.Verify(m => m.Salvar(destinatario));
            mockRepositorio.Verify(m => m.PegarPorId(id));
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Destinatario_Aplicacao_SalvarDestinatarioComCpf_DeveFuncionar()
        {
            var id = 1;
            Destinatario destinatario = ObjectMother.ObtemDestinatarioCnpjVazio();
            destinatario.Id = 0;
            mockRepositorio.Setup(m => m.Salvar(destinatario)).Returns(new Destinatario { Id = 1 });
            mockRepositorio.Setup(m => m.PegarPorId(id)).Returns(new Destinatario { Id = 1 });

            Destinatario result = destinatarioServico.Salvar(destinatario);

            result.Id.Should().BeGreaterThan(0);
            mockRepositorio.Verify(m => m.Salvar(destinatario));
            mockRepositorio.Verify(m => m.PegarPorId(id));
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Destinatario_Aplicacao_BuscaTodos_DeveFuncionar()
        {
            IList<Destinatario> ListaDestinatario = new List<Destinatario>();
            Destinatario destinatario = ObjectMother.ObtemDestinatarioValido();
            ListaDestinatario.Add(destinatario);
            mockRepositorio.Setup(m => m.PegarTodos()).Returns(ListaDestinatario);

            IList<Destinatario> Result = destinatarioServico.PegarTodos().ToList();

            Result.First().Id.Should().Be(1);
            Result.Count().Should().Be(1);
            mockRepositorio.Verify(m => m.PegarTodos());
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Destinatario_Aplicacao_BuscaPorId_DeveFuncionar()
        {
            Destinatario destinatario = ObjectMother.ObtemDestinatarioValido();
            mockRepositorio.Setup(m => m.PegarPorId(destinatario.Id)).Returns(destinatario);

            Destinatario result = destinatarioServico.PegarPorId(destinatario.Id);

            result.Should().NotBeNull();
            result.Id.Should().Be(1);
            mockRepositorio.Verify(m => m.PegarPorId(destinatario.Id));
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Destinatario_Aplicacao_Deletar_DeveFuncionar()
        {
            Destinatario destinatario = ObjectMother.ObtemDestinatarioValido();
            mockRepositorio.Setup(m => m.Deletar(destinatario));

            destinatarioServico.Deletar(destinatario);

            mockRepositorio.Verify(m => m.Deletar(destinatario));
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Destinatario_Aplicacao_Atualizar_DeveFuncionar()
        {
            Destinatario destinatario = ObjectMother.ObtemDestinatarioValido();
            var esperado = "Ciclano XY";
            destinatario.Nome = esperado;
            mockRepositorio.Setup(m => m.Atualizar(destinatario)).Returns(destinatario);
            mockRepositorio.Setup(m => m.PegarPorId(destinatario.Id)).Returns(destinatario);

            Destinatario result = destinatarioServico.Atualizar(destinatario);

            result.Nome.Should().Be(esperado);
            mockRepositorio.Verify(m => m.Atualizar(destinatario));
            mockRepositorio.Verify(m => m.PegarPorId(destinatario.Id));
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Destinatario_Aplicacao_Atualizar_DeveJogarExcecaoIdentificadorNaoDefinido()
        {
            Destinatario destinatario = ObjectMother.ObtemDestinatarioValido();
            destinatario.Id = 0;

            Action act = () => { destinatarioServico.Atualizar(destinatario); };

            act.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Destinatario_Aplicacao_PegarPorId_DeveJogarExcecaoIdentificarNaoDefinido()
        {
            Destinatario destinatario = ObjectMother.ObtemDestinatarioValido();
            destinatario.Id = 0;

            Action act = () => { destinatarioServico.PegarPorId(destinatario.Id); };

            act.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Destinatario_Aplicacao_Deletar_DeveJogarExcecaoIdentificadorNaoDefinido()
        {
            Destinatario destinatario = ObjectMother.ObtemDestinatarioValido();
            destinatario.Id = 0;

            Action act = () => { destinatarioServico.Deletar(destinatario); };

            act.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Destinatario_Aplicacao_Salvar_DeveJogarExcecaoDestinatarioRazaoOuNomeVazio()
        {
            Destinatario destinatario = ObjectMother.ObtemDestinatarioNomeeRazaoSocialVazio();

            Action act = () => { destinatarioServico.Salvar(destinatario); };

            act.Should().Throw<DestinatarioEmptyRazaoNomeException>();
        }

        [Test]
        public void Destinatario_Aplicacao_PegarPorId_DeveRetornarNuloDestinatarioNaoEncontrado()
        {
            var id = 99;
            mockRepositorio.Setup(x => x.PegarPorId(id)).Returns((Destinatario)null);

            Destinatario destinatario = destinatarioServico.PegarPorId(id);

            destinatario.Should().BeNull();
        }

        [Test]
        public void Destinatario_Aplicacao_SalvarDestinatarioSemEndereco()
        {
            var id = 1;
            Destinatario destinatario = ObjectMother.ObtemDestinatarioCnpjVazio();
            destinatario.Id = 0;
            mockRepositorio.Setup(m => m.Salvar(destinatario)).Returns(new Destinatario { Id = 1 });
            mockRepositorio.Setup(m => m.PegarPorId(id)).Returns(new Destinatario { Id = 1 });
            mockEnderecoRepostorio.Setup(m => m.PegarPorId(destinatario.Endereco.Id)).Returns(destinatario.Endereco);
            
            Destinatario result = destinatarioServico.Salvar(destinatario);

            result.Id.Should().BeGreaterThan(0);
            mockRepositorio.Verify(m => m.Salvar(destinatario));
            mockRepositorio.Verify(m => m.PegarPorId(id));
            mockRepositorio.VerifyNoOtherCalls();
        }
    }
}

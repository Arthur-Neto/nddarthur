using FluentAssertions;
using Moq;
using NFe.Aplicacao.Features.Emitentes;
using NFe.Common.Testes.Features;
using NFe.Dominio.Exceptions;
using NFe.Dominio.Features.Emitentes;
using NFe.Dominio.Features.Enderecos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NFe.Aplicacao.Testes.Features.Emitentes
{
    [TestFixture]
    public class EmitenteAplicacaoTeste
    {
        EmitenteServico emitenteServico;
        Mock<IEmitenteRepositorio> mockRepositorio;
        Mock<IEnderecoRepositorio> mockEnderecoRepostorio;

        [SetUp]
        public void InitializeObjects()
        {
            mockRepositorio = new Mock<IEmitenteRepositorio>();
            mockEnderecoRepostorio = new Mock<IEnderecoRepositorio>();

            emitenteServico = new EmitenteServico(mockRepositorio.Object, mockEnderecoRepostorio.Object);
        }

        [Test]
        public void Emitente_Aplicacao_Salvar_EmitenteComCnpj_DeveFuncionar()
        {
            var id = 1;
            Emitente emitente = ObjectMother.ObterEmitenteComCpfVazio();
            emitente.Id = 0;
            mockRepositorio.Setup(m => m.Salvar(emitente)).Returns(new Emitente { Id = 1 });
            mockRepositorio.Setup(m => m.PegarPorId(id)).Returns(new Emitente { Id = 1 });

            Emitente result = emitenteServico.Salvar(emitente);

            result.Id.Should().BeGreaterThan(0);
            mockRepositorio.Verify(m => m.Salvar(emitente));
            mockRepositorio.Verify(m => m.PegarPorId(id));
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Emitente_Aplicacao_Salvar_EmitenteComCpf_DeveFuncionar()
        {
            var id = 1;
            Emitente emitente = ObjectMother.ObterEmitenteComCnpjVazio();
            emitente.Id = 0;
            mockRepositorio.Setup(m => m.Salvar(emitente)).Returns(new Emitente { Id = 1 });
            mockRepositorio.Setup(m => m.PegarPorId(id)).Returns(new Emitente { Id = 1 });

            Emitente result = emitenteServico.Salvar(emitente);

            result.Id.Should().BeGreaterThan(0);
            mockRepositorio.Verify(m => m.Salvar(emitente));
            mockRepositorio.Verify(m => m.PegarPorId(id));
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Emitente_Aplicacao_BuscaTodos_DeveFuncionar()
        {
            IList<Emitente> ListaEmitente = new List<Emitente>();
            Emitente emitente = ObjectMother.ObterEmitenteValido();
            ListaEmitente.Add(emitente);
            mockRepositorio.Setup(m => m.PegarTodos()).Returns(ListaEmitente);

            IList<Emitente> Result = emitenteServico.PegarTodos().ToList();

            Result.First().Id.Should().Be(1);
            Result.Count().Should().Be(1);
            mockRepositorio.Verify(m => m.PegarTodos());
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Emitente_Aplicacao_BuscaPorId_DeveFuncionar()
        {
            Emitente emitente = ObjectMother.ObterEmitenteValido();
            mockRepositorio.Setup(m => m.PegarPorId(emitente.Id)).Returns(emitente);

            Emitente result = emitenteServico.PegarPorId(emitente.Id);

            result.Should().NotBeNull();
            result.Id.Should().Be(1);
            mockRepositorio.Verify(m => m.PegarPorId(emitente.Id));
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Emitente_Aplicacao_Deletar_DeveFuncionar()
        {
            Emitente emitente = ObjectMother.ObterEmitenteValido();

            mockRepositorio.Setup(m => m.Deletar(emitente));

            emitenteServico.Deletar(emitente);
            mockRepositorio.Verify(m => m.Deletar(emitente));
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Emitente_Aplicacao_Atualizar_DeveFuncionar()
        {
            Emitente emitente = ObjectMother.ObterEmitenteValido();
            emitente.Nome = "Ciclano XY";
            mockRepositorio.Setup(m => m.Atualizar(emitente)).Returns(emitente);
            mockRepositorio.Setup(m => m.PegarPorId(emitente.Id)).Returns(emitente);

            Emitente result = emitenteServico.Atualizar(emitente);

            result.Nome.Should().Be("Ciclano XY");
            mockRepositorio.Verify(m => m.Atualizar(emitente));
            mockRepositorio.Verify(m => m.PegarPorId(emitente.Id));
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Emitente_Aplicacao_Atualizar_DeveFalhar()
        {
            Emitente emitente = ObjectMother.ObterEmitenteValido();
            emitente.Id = 0;

            Action act = () => { emitenteServico.Atualizar(emitente); };

            act.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Emitente_Aplicacao_BuscaPorId_DeveJogarExcecaoIdentificadorNaoDefinido()
        {
            Emitente emitente = ObjectMother.ObterEmitenteValido();

            emitente.Id = 0;

            Action act = () => { emitenteServico.PegarPorId(emitente.Id); };

            act.Should().Throw<IdentifierUndefinedException>();

        }

        [Test]
        public void Emitente_Aplicacao_Deletar_DeveJogarExcecaoIdentificadorNaoDefinido()
        {
            Emitente emitente = ObjectMother.ObterEmitenteValido();

            emitente.Id = 0;

            Action act = () => { emitenteServico.Deletar(emitente); };

            act.Should().Throw<IdentifierUndefinedException>();

        }

        [Test]
        public void Emitente_Aplicacao_Salvar_DeveJogarExcecaoSemRazaoSocial()
        {
            Emitente emitente = ObjectMother.ObterEmitenteComRazaoSocialVazio();

            Action act = () => { emitenteServico.Salvar(emitente); };

            act.Should().Throw<EmitenteEmptyRazaoSocialException>();

        }

        [Test]
        public void Emitente_Aplicacao_PegarPorId_DeveRetornarNulo_EmitenteNaoEncontrado()
        {
            var id = 99;
            mockRepositorio.Setup(x => x.PegarPorId(id)).Returns((Emitente)null);

            Emitente emitente = emitenteServico.PegarPorId(id);

            emitente.Should().BeNull();
        }

        [Test]
        public void Emitente_Aplicacao_SalvarEmitenteSemEndereco()
        {
            var id = 1;
            Emitente emitente = ObjectMother.ObterEmitenteComCnpjVazio();
            emitente.Id = 0;
            mockRepositorio.Setup(m => m.Salvar(emitente)).Returns(new Emitente { Id = 1 });
            mockRepositorio.Setup(m => m.PegarPorId(id)).Returns(new Emitente { Id = 1 });
            mockEnderecoRepostorio.Setup(m => m.PegarPorId(emitente.Endereco.Id)).Returns(emitente.Endereco);

            Emitente result = emitenteServico.Salvar(emitente);

            result.Id.Should().BeGreaterThan(0);
            mockRepositorio.Verify(m => m.Salvar(emitente));
            mockRepositorio.Verify(m => m.PegarPorId(id));
            mockRepositorio.VerifyNoOtherCalls();
        }
    }
}

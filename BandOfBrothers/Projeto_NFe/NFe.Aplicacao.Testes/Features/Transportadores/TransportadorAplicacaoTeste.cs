using FluentAssertions;
using Moq;
using NFe.Aplicacao.Features.Transportadores;
using NFe.Common.Testes.Features;
using NFe.Dominio.Exceptions;
using NFe.Dominio.Features.Enderecos;
using NFe.Dominio.Features.Transportadores;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NFe.Aplicacao.Testes.Features.Transportadores
{
    [TestFixture]
    public class TransportadorAplicacaoTeste
    {
        TransportadorServico transportadorServico;
        Mock<ITransportadorRepositorio> mockRepositorio;
        Mock<IEnderecoRepositorio> mockEnderecoRepostorio;

        [SetUp]
        public void InitializeObjects()
        {
            mockRepositorio = new Mock<ITransportadorRepositorio>();
            mockEnderecoRepostorio = new Mock<IEnderecoRepositorio>();

            transportadorServico = new TransportadorServico(mockRepositorio.Object, mockEnderecoRepostorio.Object);
        }

        [Test]
        public void Transportador_Aplicacao_Salvar_DeveFuncionarTranportadorComCnpj()
        {
            var id = 1;
            Transportador transportador = ObjectMother.ObterTransportadorValidoComCnpjENome();
            transportador.Id = 0;
            mockRepositorio.Setup(m => m.Salvar(transportador)).Returns(new Transportador { Id = 1 });
            mockRepositorio.Setup(m => m.PegarPorId(id)).Returns(new Transportador { Id = 1 });

            Transportador result = transportadorServico.Salvar(transportador);

            result.Id.Should().BeGreaterThan(0);
            mockRepositorio.Verify(m => m.Salvar(transportador));
            mockRepositorio.Verify(m => m.PegarPorId(id));
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Transportador_Aplicacao_Salvar_DeveFuncionarTransportadorComCpf()
        {
            var id = 1;
            Transportador transportador = ObjectMother.ObterTransportadorValidoComCpfENome();
            transportador.Id = 0;
            mockRepositorio.Setup(m => m.Salvar(transportador)).Returns(new Transportador { Id = 1 });
            mockRepositorio.Setup(m => m.PegarPorId(id)).Returns(new Transportador { Id = 1 });

            Transportador result = transportadorServico.Salvar(transportador);

            result.Id.Should().BeGreaterThan(0);
            mockRepositorio.Verify(m => m.Salvar(transportador));
            mockRepositorio.Verify(m => m.PegarPorId(id));
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Transportador_Aplicacao_BuscarTodos_DeveFuncionar()
        {
            IList<Transportador> ListaTransportador = new List<Transportador>();
            Transportador transportador = ObjectMother.ObterTransportadorValidoComCnpjENome();
            ListaTransportador.Add(transportador);
            mockRepositorio.Setup(m => m.PegarTodos()).Returns(ListaTransportador);

            IList<Transportador> Result = transportadorServico.PegarTodos().ToList();

            var id = 1;
            Result.First().Id.Should().Be(id);
            Result.Count().Should().BeGreaterThan(0);
            mockRepositorio.Verify(m => m.PegarTodos());
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Transportador_Aplicacao_BuscaPorId_DeveFuncionar()
        {
            Transportador transportador = ObjectMother.ObterTransportadorValidoComCnpjENome();
            mockRepositorio.Setup(m => m.PegarPorId(transportador.Id)).Returns(transportador);

            Transportador result = transportadorServico.PegarPorId(transportador.Id);

            result.Should().NotBeNull();
            result.Id.Should().BeGreaterThan(0);
            mockRepositorio.Verify(m => m.PegarPorId(transportador.Id));
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Transportador_Aplicacao_Deletar_DeveFuncionar()
        {
            Transportador transportador = ObjectMother.ObterTransportadorValidoComCnpjENome();

            mockRepositorio.Setup(m => m.Deletar(transportador));

            transportadorServico.Deletar(transportador);
            mockRepositorio.Verify(m => m.Deletar(transportador));
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Transportador_Aplicacao_Atualizar_DeveFuncionar()
        {
            var responsavelFrete = 1;
            Transportador transportador = ObjectMother.ObterTransportadorValidoComCnpjENome();
            transportador.ResponsabilidadeFrete = (Frete)responsavelFrete;
            mockRepositorio.Setup(m => m.Atualizar(transportador)).Returns(transportador);
            mockRepositorio.Setup(m => m.PegarPorId(transportador.Id)).Returns(transportador);

            Transportador result = transportadorServico.Atualizar(transportador);

            result.ResponsabilidadeFrete.Should().Be(responsavelFrete);
            mockRepositorio.Verify(m => m.Atualizar(transportador));
            mockRepositorio.Verify(m => m.PegarPorId(transportador.Id));
            mockRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Transportador_Aplicacao_Atualizar_DeveJogarExcecaoIdentificadorNaoDefinido()
        {
            Transportador transportador = ObjectMother.ObterTransportadorValidoComCnpjENome();
            transportador.Id = 0;

            Action act = () => { transportadorServico.Atualizar(transportador); };

            act.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Transportador_Aplicacao_BuscaPorId_DeveJogarExcecaoIdentificadorNaoDefinido()
        {
            Transportador transportador = ObjectMother.ObterTransportadorValidoComCnpjENome();
            transportador.Id = 0;

            Action act = () => { transportadorServico.PegarPorId(transportador.Id); };

            act.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Transportador_Aplicacao_Deletar_DeveJogarExcecaoIdentificadorNaoDefinido()
        {
            Transportador transportador = ObjectMother.ObterTransportadorValidoComCnpjENome();
            transportador.Id = 0;

            Action act = () => { transportadorServico.Deletar(transportador); };

            act.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Transportador_Aplicacao_Salvar_DeveJogarExcecaoCpfECnpjVazios()
        {
            Transportador transportador = ObjectMother.ObterTransportadorInvalidoSemCpfOuCnpj();

            Action act = () => { transportadorServico.Salvar(transportador); };

            act.Should().Throw<TransportadorEmptyCpfCnpjException>();
        }

        [Test]
        public void Transportador_Aplicacao_PegarPorId_DeveRetornarNulo_TransportadorNaoEncontrado()
        {
            var id = 99;
            mockRepositorio.Setup(x => x.PegarPorId(id)).Returns((Transportador)null);

            Transportador transportador = transportadorServico.PegarPorId(id);

            transportador.Should().BeNull();
        }

        [Test]
        public void Transportador_Aplicacao_SalvarTransportadorSemEndereco()
        {
            var id = 1;
            Transportador transportador = ObjectMother.ObterTransportadorComCnpjVazio();
            transportador.Id = 0;
            mockRepositorio.Setup(m => m.Salvar(transportador)).Returns(new Transportador { Id = 1 });
            mockRepositorio.Setup(m => m.PegarPorId(id)).Returns(new Transportador { Id = 1 });
            mockEnderecoRepostorio.Setup(m => m.PegarPorId(transportador.Endereco.Id)).Returns(transportador.Endereco);

            Transportador result = transportadorServico.Salvar(transportador);

            result.Id.Should().BeGreaterThan(0);
            mockRepositorio.Verify(m => m.Salvar(transportador));
            mockRepositorio.Verify(m => m.PegarPorId(id));
            mockRepositorio.VerifyNoOtherCalls();
        }
    }
}

using FluentAssertions;
using NFe.Aplicacao.Features.Transportadores;
using NFe.Common.Testes.Base;
using NFe.Common.Testes.Features;
using NFe.Dominio.Exceptions;
using NFe.Dominio.Features.Enderecos;
using NFe.Dominio.Features.Transportadores;
using NFe.Infra.Data.Features.Enderecos;
using NFe.Infra.Data.Features.Transportadores;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NFe.Intregacao.Sistema.Testes.Features.Transportadores
{
    [TestFixture]
    public class TransportadorIntegracaoSistemaTeste
    {
        TransportadorServico transportadorServico;
        ITransportadorRepositorio repositorio;
        IEnderecoRepositorio enderecoRepositorio;

        [SetUp]
        public void InitializeObjects()
        {
            enderecoRepositorio = new EnderecoRepositorio();
            repositorio = new TransportadorRepositorio();

            transportadorServico = new TransportadorServico(repositorio, enderecoRepositorio);

            BaseSqlTest.SeedDatabase();
        }

        [Test]
        public void Transportador_IntegracaoSistema_Salvar_DeveSalvarTransportadorComCnpj()
        {
            Transportador transportador = ObjectMother.ObterTransportadorValidoComCnpjENome();
            transportador.Id = 0;

            Transportador result = transportadorServico.Salvar(transportador);

            result.Id.Should().BeGreaterThan(0);
            IList<Transportador> TransportadorList = transportadorServico.PegarTodos().ToList();
            TransportadorList.Contains(result).Should().BeTrue();
            TransportadorList.Last().Cnpj.valor.Should().Be("06255692000103");
        }

        [Test]
        public void Transportador_IntegracaoSistema_Salvar_DeveSalvarTransportadorComCpf()
        {
            Transportador transportador = ObjectMother.ObterTransportadorValidoComCpfENome();
            transportador.Id = 0;

            Transportador result = transportadorServico.Salvar(transportador);

            result.Id.Should().BeGreaterThan(0);

            IList<Transportador> TransportadorList = transportadorServico.PegarTodos().ToList();
            TransportadorList.Contains(result).Should().BeTrue();
            TransportadorList.Last().Cpf.valor.Should().Be("05919707917");
        }

        [Test]
        public void Transportador_IntegracaoSistema_BuscaTodos_DeveFuncionar()
        {
            Transportador transportador = ObjectMother.ObterTransportadorValidoComCpfENome();
            transportador.Id = 0;

            Transportador result = transportadorServico.Salvar(transportador);

            result.Id.Should().BeGreaterThan(0);

            IList<Transportador> TransportadorList = transportadorServico.PegarTodos().ToList();
            TransportadorList.Contains(result).Should().BeTrue();
            TransportadorList.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void Transportador_IntegracaoSistema_BuscaPorId_DeveFuncionar()
        {
            Transportador transportador = ObjectMother.ObterTransportadorValidoComCpfENome();
            transportador.Id = 0;

            transportador = transportadorServico.Salvar(transportador);

            Transportador resultadoBuscaBanco = transportadorServico.PegarPorId(transportador.Id);

            transportador.Should().NotBeNull();
            resultadoBuscaBanco.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Transportador_IntegracaoSistema_Deletar_DeveFuncionar()
        {
            Transportador transportador = ObjectMother.ObterTransportadorValidoComCpfENome();
            transportador.Id = 0;
            transportador.Endereco.Id = 0;

            transportador = transportadorServico.Salvar(transportador);

            transportadorServico.Deletar(transportador);

            Transportador result = transportadorServico.PegarPorId(transportador.Id);

            result.Should().BeNull();
        }

        [Test]
        public void Transportador_IntegracaoSistema_Atualizar_DeveFuncionar()
        {
            Transportador transportador = ObjectMother.ObterTransportadorValidoComCpfENome();
            transportador.Id = 0;

            transportador = transportadorServico.Salvar(transportador);

            transportador.Endereco.Numero = "111";

            Transportador result = transportadorServico.Atualizar(transportador);

            result.Endereco.Numero.Should().Be("111");
        }

        [Test]
        public void Transportador_IntegracaoSistema_Atualizar_DeveJogarExcecaoIdentificadorNaoDefinido()
        {
            Transportador transportador = ObjectMother.ObterTransportadorValidoComCpfENome();
            transportador.Id = 0;

            Action act = () => { transportadorServico.Atualizar(transportador); };

            act.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Transportador_IntegracaoSistema_BuscaPorIdTransportador_DeveJogarExcecaoIdentificadorNaoDefinido()
        {
            Transportador transportador = ObjectMother.ObterTransportadorValidoComCpfENome();

            transportador.Id = 0;

            Action act = () => { transportadorServico.PegarPorId(transportador.Id); };

            act.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Transportador_IntegracaoSistema_Deletar_DeveJogarExcecaoIdentificadorNaoDefinido()
        {
            Transportador transportador = ObjectMother.ObterTransportadorValidoComCpfENome();

            transportador.Id = 0;

            Action act = () => { transportadorServico.Deletar(transportador); };

            act.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Transportador_IntegracaoSistema_Salvar_DeveJogarExcecaoNomeERazaoSocialVazios()
        {
            Transportador transportador = ObjectMother.ObterTransportadorInvalidoSemNomeOuRazaoSocial();

            Action act = () => { transportadorServico.Salvar(transportador); };

            act.Should().Throw<TransportadorEmptyNomeRazaoException>();
        }
    }
}

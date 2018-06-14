using FluentAssertions;
using NFe.Aplicacao.Features.Emitentes;
using NFe.Common.Testes.Base;
using NFe.Common.Testes.Features;
using NFe.Dominio.Exceptions;
using NFe.Dominio.Features.Emitentes;
using NFe.Dominio.Features.Enderecos;
using NFe.Infra.Data.Features.Emitentes;
using NFe.Infra.Data.Features.Enderecos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NFe.Intregacao.Sistema.Testes.Features.Emitentes
{
    [TestFixture]
    public class EmitenteIntegracaoSistemaTeste
    {
        EmitenteServico emitenteServico;
        IEmitenteRepositorio repositorio;
        IEnderecoRepositorio enderecoRepostorio;

        [SetUp]
        public void InitializeObjects()
        {
            enderecoRepostorio = new EnderecoRepositorio();
            repositorio = new EmitenteRepositorio();

            emitenteServico = new EmitenteServico(repositorio, enderecoRepostorio);

            BaseSqlTest.SeedDatabase();
        }

        [Test]
        public void Emitente_IntegracaoSistema_Salvar_DeveSalvarComCnpj()
        {
            Emitente emitente = ObjectMother.ObterEmitenteValido();
            emitente.Id = 0;

            repositorio.Salvar(emitente);

            Emitente result = emitenteServico.Salvar(emitente);

            result.Id.Should().BeGreaterThan(0);

            IList<Emitente> ListaEmitente = repositorio.PegarTodos().ToList();

            ListaEmitente.Contains(result).Should().BeTrue();

        }

        [Test]
        public void Emitente_IntegracaoSistema_Salvar_DeveSalvarComCpf()
        {
            Emitente emitente = ObjectMother.ObterEmitenteValido();
            emitente.Id = 0;

            repositorio.Salvar(emitente);

            Emitente result = emitenteServico.Salvar(emitente);

            result.Id.Should().BeGreaterThan(0);

            IList<Emitente> ListaEmitente = repositorio.PegarTodos().ToList();

            ListaEmitente.Contains(result).Should().BeTrue();
        }

        [Test]
        public void Emitente_IntegracaoSistema_BuscaTodos_DeveFuncionar()
        {
            IList<Emitente> ListaEmitente = new List<Emitente>();

            Emitente emitente = ObjectMother.ObterEmitenteValido();

            ListaEmitente.Add(emitente);

            repositorio.PegarTodos();

            IList<Emitente> Result = emitenteServico.PegarTodos().ToList();

            Result.First().Id.Should().Be(1);
            Result.Count().Should().BeGreaterThan(0);

        }

        [Test]
        public void Emitente_IntegracaoSistema_BuscaPorId_DeveFuncionar()
        {
            Emitente emitente = ObjectMother.ObterEmitenteValido();

            repositorio.PegarPorId(emitente.Id);

            Emitente result = emitenteServico.PegarPorId(emitente.Id);

            result.Should().NotBeNull();
            result.Id.Should().Be(1);

        }

        [Test]
        public void Emitente_IntegracaoSistema_Deletar_DeveFuncionar()
        {
            Emitente emitente = ObjectMother.ObterEmitenteValido();
            emitente.Endereco.Id = 0;
            emitente = emitenteServico.Salvar(emitente);

            emitenteServico.Deletar(emitente);

            Emitente result = emitenteServico.PegarPorId(emitente.Id);

            result.Should().BeNull();
        }

        [Test]
        public void Emitente_IntegracaoSistema_Atualizar_DeveFuncionar()
        {
            Emitente emitente = ObjectMother.ObterEmitenteValido();
            emitente.Id = 0;
            emitente.Endereco.Id = 0;

            emitente = emitenteServico.Salvar(emitente);

            emitente.RazaoSocial = "Vendedor ETS";

            emitente = emitenteServico.Atualizar(emitente);

            Emitente result = emitenteServico.PegarPorId(emitente.Id);

            result.RazaoSocial.Should().Be("Vendedor ETS");
        }

        [Test]
        public void Emitente_IntegracaoSistema_Atualizar_DeveJogarExcecaoIdentificadorNaoDefinido()
        {
            Emitente emitente = ObjectMother.ObterEmitenteValido();
            emitente.Id = 0;

            Action act = () => { emitenteServico.Atualizar(emitente); };

            act.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Emitente_IntegracaoSistema_BuscaPorId_DeveJogarExcecaoIdentificadorNaoDefinido()
        {
            Emitente emitente = ObjectMother.ObterEmitenteValido();

            emitente.Id = 0;

            Action act = () => { emitenteServico.PegarPorId(emitente.Id); };

            act.Should().Throw<IdentifierUndefinedException>();

        }

        [Test]
        public void Emitente_IntegracaoSistema_Deletar_DeveJogarExcecaoIdentificadorNaoDefinido()
        {
            Emitente emitente = ObjectMother.ObterEmitenteValido();

            emitente.Id = 0;

            Action act = () => { emitenteServico.Deletar(emitente); };

            act.Should().Throw<IdentifierUndefinedException>();


        }

        [Test]
        public void Emitente_IntegracaoSistema_Salvar_DeveJogarExcecaoRazaoSocialVazio()
        {
            Emitente emitente = ObjectMother.ObterEmitenteComRazaoSocialVazio();

            Action act = () => { emitenteServico.Salvar(emitente); };

            act.Should().Throw<EmitenteEmptyRazaoSocialException>();

        }
    }
}

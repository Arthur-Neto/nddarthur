using FluentAssertions;
using NFe.Aplicacao.Features.Destinatarios;
using NFe.Common.Testes.Base;
using NFe.Common.Testes.Features;
using NFe.Dominio.Exceptions;
using NFe.Dominio.Features.Destinatarios;
using NFe.Dominio.Features.Enderecos;
using NFe.Infra.Data.Features.Destinatarios;
using NFe.Infra.Data.Features.Enderecos;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace NFe.Intregacao.Sistema.Testes.Features.Destinatarios
{
    [TestFixture]
    public class DestinatarioIntegracaoSistemaTeste
    {
        DestinatarioServico destinatarioServico;
        IDestinatarioRepositorio repositorio;
        IEnderecoRepositorio enderecoRepositorio;

        [SetUp]
        public void InitializeObjects()
        {
            enderecoRepositorio = new EnderecoRepositorio();
            repositorio = new DestinatarioRepositorio();

            destinatarioServico = new DestinatarioServico(repositorio, enderecoRepositorio);

            BaseSqlTest.SeedDatabase();
        }

        [Test]
        public void Destinatario_IntegracaoSistema_Salvar_DeveSalvarDestinatarioComCpfOk()
        {
            Destinatario destinatario = ObjectMother.ObtemDestinatarioValido();
            destinatario.Id = 0;

            Destinatario result = destinatarioServico.Salvar(destinatario);

            result.Id.Should().BeGreaterThan(0);
            IList<Destinatario> DestinatarioList = (IList<Destinatario>)destinatarioServico.PegarTodos();
            DestinatarioList.Contains(result).Should().BeTrue();
        }

        [Test]
        public void Destinatario_IntegracaoSistema_BuscaTodos_DeveFuncionar()
        {
            IList<Destinatario> ListaDestinatario = new List<Destinatario>();

            Destinatario destinatario = ObjectMother.ObtemDestinatarioValido();

            ListaDestinatario.Add(destinatario);

            IList<Destinatario> Result = (IList<Destinatario>)destinatarioServico.PegarTodos();

            Result.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void Destinatario_IntegracaoSistema_BuscaPorId_DeveFuncionar()
        {
            Destinatario destinatario = ObjectMother.ObtemDestinatarioValido();

            Destinatario result = destinatarioServico.PegarPorId(destinatario.Id);

            result.Should().NotBeNull();
            result.Id.Should().Be(1);

        }

        [Test]
        public void Destinatario_IntegracaoSistema_Deletar_DeveFuncionar()
        {
            Destinatario destinatario = ObjectMother.ObtemDestinatarioValido();
            destinatario.Endereco.Id = 0;
            destinatario = destinatarioServico.Salvar(destinatario);

            destinatarioServico.Deletar(destinatario);

            Destinatario result = destinatarioServico.PegarPorId(destinatario.Id);

            result.Should().BeNull();
        }

        [Test]
        public void Destinatario_IntegracaoSistema_Atualizar_DeveFuncionar()
        {
            var numero = "111";
            Destinatario destinatario = ObjectMother.ObtemDestinatarioValido();
            destinatario.Endereco.Numero = "111";

            Destinatario result = destinatarioServico.Atualizar(destinatario);

            result.Endereco.Numero.Should().Be(numero);
        }

        [Test]
        public void Destinatario_IntegracaoSistema_Atualizar_DeveJogarExcecaoIdentificadorNaoDefinido()
        {
            Destinatario destinatario = ObjectMother.ObtemDestinatarioValido();
            destinatario.Id = 0;

            Action act = () => { destinatarioServico.Atualizar(destinatario); };

            act.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void Destinatario_IntegracaoSistema_BuscaPorId_DeveJogarExcecaoIdentificadorNaoDefinido()
        {
            Destinatario destinatario = ObjectMother.ObtemDestinatarioValido();

            destinatario.Id = 0;

            Action act = () => { destinatarioServico.PegarPorId(destinatario.Id); };

            act.Should().Throw<IdentifierUndefinedException>();

        }

        [Test]
        public void Destinatario_IntegracaoSistema_Deletar_DeveJogarExcecaoIdentificadorNaoDefinido()
        {
            Destinatario destinatario = ObjectMother.ObtemDestinatarioValido();

            destinatario.Id = 0;

            Action act = () => { destinatarioServico.Deletar(destinatario); };

            act.Should().Throw<IdentifierUndefinedException>();

        }

        [Test]
        public void Destinatario_IntegracaoSistema_Salvar_DeveJogarExcecaoSRazaoSocialENomeVazios()
        {
            Destinatario destinatario = ObjectMother.ObtemDestinatarioNomeeRazaoSocialVazio();

            Action act = () => { destinatarioServico.Salvar(destinatario); };

            act.Should().Throw<DestinatarioEmptyRazaoNomeException>();

        }
    }

}

using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TutorialORM.Common.Testes.Base;
using TutorialORM.Common.Testes.Features;
using TutorialORM.Dominio.Features.Enderecos;
using TutorialORM.Infra.Data.Base;
using TutorialORM.Infra.Data.Features.Enderecos;

namespace TutorialORM.Infra.Data.Testes.Features.Enderecos
{
    [TestFixture]
    public class EnderecoRepositorioTestes
    {
        EscolaContext escolaContext;
        IEnderecoRepositorio repositorio;
        Endereco endereco;

        [SetUp]
        public void SetUp()
        {
            escolaContext = new EscolaContext();
            repositorio = new EnderecoRepositorio(escolaContext);
            Database.SetInitializer(new BaseSqlTestes());
            escolaContext.Database.Initialize(true);
        }

        [Test]
        public void Endereco_InfraData_Salvar_DeveInserirOk()
        {
            endereco = ObjectMother.ObterEnderecoValido();

            endereco = repositorio.Salvar(endereco);

            endereco.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Endereco_InfraData_Deletar_DeveRemoverOk()
        {
            endereco = ObjectMother.ObterEnderecoValido();
            endereco = repositorio.Salvar(endereco);

            repositorio.Deletar(endereco);

            endereco = repositorio.PegarPorId(endereco.Id);
            endereco.Should().BeNull();
        }

        [Test]
        public void Endereco_InfraData_PegarPorId_DevePegarEnderecoOk()
        {
            endereco = ObjectMother.ObterEnderecoValido();
            endereco = repositorio.Salvar(endereco);

            var resultado = repositorio.PegarPorId(endereco.Id);

            resultado.Should().NotBeNull();
            resultado.Id.Should().Equals(endereco.Id);
        }

        [Test]
        public void Endereco_InfraData_PegarTodos_DevePegarTodosOk()
        {
            IEnumerable<Endereco> enderecos;
            endereco = ObjectMother.ObterEnderecoValido();
            endereco = repositorio.Salvar(endereco);

            enderecos = repositorio.PegarTodos();

            enderecos.Count().Should().BeGreaterThan(0);
            enderecos.First().Id.Should().Equals(endereco.Id);
        }

        [Test]
        public void Endereco_InfraData_Atualizar_DeveAtualizarOk()
        {
            endereco = ObjectMother.ObterEnderecoValido();
            endereco = repositorio.Salvar(endereco);
            endereco.Bairro = "Atualizado";

            var enderecoAtualizado = repositorio.Atualizar(endereco);
            
            enderecoAtualizado.Bairro.Should().Be(endereco.Bairro);
        }

        [Test]
        public void Endereco_InfraData_VerificaDependencia_DeveJogarExcecaoEnderecoReferenciado()
        {
            endereco = ObjectMother.ObterEnderecoValido();
            endereco.Id = 1;

            Action acao = () => repositorio.VerificaDependencia(endereco);

            acao.Should().Throw<EnderecoReferenciadoException>();
        }

        [Test]
        public void Endereco_InfraData_VerificaDependencia_NaoDeveJogarExcecaoEnderecoReferenciado()
        {
            endereco = ObjectMother.ObterEnderecoValido();
            endereco.Id = 99;

            Action acao = () => repositorio.VerificaDependencia(endereco);

            acao.Should().NotThrow();
        }
    }
}

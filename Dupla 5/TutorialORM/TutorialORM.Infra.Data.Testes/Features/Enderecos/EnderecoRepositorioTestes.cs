using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
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
        EscolaContext escolaContext = new EscolaContext();
        IEnderecoRepositorio repositorio;
        Endereco endereco;

        [SetUp]
        public void SetUp()
        {
            repositorio = new EnderecoRepositorio();
            BaseSqlTestes.SeedDatabase(escolaContext);
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
    }
}

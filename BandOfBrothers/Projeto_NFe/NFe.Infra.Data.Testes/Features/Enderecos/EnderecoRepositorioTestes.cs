using FluentAssertions;
using NFe.Common.Testes.Base;
using NFe.Common.Testes.Features;
using NFe.Dominio.Features.Enderecos;
using NFe.Infra.Data.Features.Enderecos;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace NFe.Infra.Data.Testes.Features.Enderecos
{
    [TestFixture]
    public class EnderecoRepositorioTestes
    {
        IEnderecoRepositorio repositorio;

        [SetUp]
        public void InitializeObjects()
        {
            BaseSqlTest.SeedDatabase();
            repositorio = new EnderecoRepositorio();
        }

        [Test]
        public void Endereco_InfraData_Salvar_DeveSalvarOk()
        {
            Endereco endereco = ObjectMother.ObterEnderecoValido();
            endereco.Id = 0;

            endereco = repositorio.Salvar(endereco);

            endereco.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Endereco_InfraData_ObterTodos_DeveFuncionar()
        {
            IList<Endereco> listaEndereco = repositorio.PegarTodos().ToList();

            listaEndereco.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void Endereco_InfraData_PegarPorId_ObterRepositorioPorId_DeveFuncionar()
        {
            Endereco endereco = ObjectMother.ObterEnderecoValido();
            endereco = repositorio.Salvar(endereco);

            Endereco Result = repositorio.PegarPorId(endereco.Id);

            Result.Id.Should().Be(endereco.Id);
        }

        [Test]
        public void Endereco_InfraData_Atualizar_DeveFuncionar()
        {
            Endereco endereco = ObjectMother.ObterEnderecoValido();
            var resultado = "Trindade";
            endereco.Municipio = "Trindade";

            endereco = repositorio.Atualizar(endereco);

            endereco.Municipio.Should().Be(resultado);
        }

        [Test]
        public void Endereco_InfraData_Deletar_DeveFuncionar()
        {
            Endereco endereco = ObjectMother.ObterEnderecoValidoSemVinculo();

            repositorio.Deletar(endereco);

            Endereco result = repositorio.PegarPorId(endereco.Id);
            result.Should().BeNull();
        }
    }
}

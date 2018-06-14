using FluentAssertions;
using NFe.Common.Testes.Base;
using NFe.Common.Testes.Features;
using NFe.Dominio.Features.Transportadores;
using NFe.Infra.Data.Features.Transportadores;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace NFe.Infra.Data.Testes.Features.Transportadores
{
    [TestFixture]
    public class TransportadorRepositorioTestes
    {
        ITransportadorRepositorio repositorio;

        [SetUp]
        public void InitializeObjects()
        {
            BaseSqlTest.SeedDatabase();
            repositorio = new TransportadorRepositorio();

        }

        [Test]
        public void Transportador_InfraData_Salvar_DeveSalvarOk()
        {
            Transportador transportador = ObjectMother.ObterTransportadorValidoComCpfERazaoSocial();
            transportador.Id = 0;

            transportador = repositorio.Salvar(transportador);

            transportador.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Transportador_InfraData_DeveInserirTransportadorSemEnderecoCadastrado()
        {
            Transportador transportador = ObjectMother.ObterTransportadorValidoComCpfERazaoSocial();

            transportador = repositorio.Salvar(transportador);

            transportador.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Transportador_InfraData_ObterTodos_DeveFuncionar()
        {
            IList<Transportador> listaTransportador = repositorio.PegarTodos().ToList();

            listaTransportador.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void Transportador_InfraData_ObterPorId_DeveFuncionar()
        {
            Transportador transportador = ObjectMother.ObterTransportadorValidoComCnpjERazaoSocial();
            transportador = repositorio.Salvar(transportador);

            Transportador Result = repositorio.PegarPorId(transportador.Id);

            Result.Id.Should().Be(transportador.Id);
        }

        [Test]
        public void Transportador_InfraData_Atualizar_DeveFuncionar()
        {
            Transportador transportador = ObjectMother.ObterTransportadorValidoComCpfENome();
            var resultado = "Transportes Ciclano";
            transportador.Nome = "Transportes Ciclano";

            transportador = repositorio.Atualizar(transportador);

            transportador.Nome.Should().Be(resultado);
        }

        [Test]
        public void Transportador_InfraData_Deletar_DeveFuncionar()
        {
            Transportador transportador = ObjectMother.ObterTransportadorValidoComCnpjENome();

            repositorio.Deletar(transportador);

            Transportador result = repositorio.PegarPorId(transportador.Id);
            result.Should().BeNull();
        }
    }
}

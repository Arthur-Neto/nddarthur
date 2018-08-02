using FluentAssertions;
using NUnit.Framework;
using ProvaTDD.Common.Testes.Base;
using ProvaTDD.Common.Testes.Features;
using ProvaTDD.Dominio.Features.Avaliacoes;
using ProvaTDD.Infra.Data.Features.Avaliacoes;
using System.Collections.Generic;
using System.Linq;

namespace ProvaTDD.Infra.Data.Testes.Features.Avaliacoes
{
    [TestFixture]
    public class AvaliacaoRepositorioTestes
    {
        IAvaliacaoRepositorio repositorio;
        Avaliacao avaliacao;

        [SetUp]
        public void SetUp()
        {
            BaseSqlTeste.SeedDatabase();
            repositorio = new AvaliacaoRepositorio();
            avaliacao = new Avaliacao();
        }

        [Test]
        public void Avaliacao_Repositorio_DeveSalvarNoBanco()
        {
            var idEsperado = 1;
            avaliacao = ObjectMother.ObterAvaliacaoValida();

            avaliacao = repositorio.Salvar(avaliacao);

            avaliacao.Id.Should().Be(idEsperado);
        }

        [Test]
        public void Avaliacao_Repositorio_DeveAtualizar()
        {
            avaliacao = ObjectMother.ObterAvaliacaoValida();
            avaliacao = repositorio.Salvar(avaliacao);
            avaliacao = repositorio.PegarPorId(avaliacao.Id);
            avaliacao.Assunto = "Portugues";

            repositorio.Atualizar(avaliacao);

            avaliacao.Assunto.Should().Be("Portugues");
        }

        [Test]
        public void Avaliacao_Repositorio_PegarPorId_DevePegarOk()
        {
            avaliacao = repositorio.Salvar(avaliacao);

            IList<Avaliacao> avaliacoes = repositorio.PegarTodos();

            avaliacoes.Count.Should().BeGreaterThan(0);
            avaliacoes.First().Id.Should().Be(avaliacao.Id);
        }

        [Test]
        public void Avaliacao_Repositorio_Deletar_DeveDeletarOk()
        {
            avaliacao = ObjectMother.ObterAvaliacaoValida();
            avaliacao = repositorio.Salvar(avaliacao);
            avaliacao = repositorio.PegarPorId(avaliacao.Id);

            repositorio.Deletar(avaliacao);
            avaliacao = repositorio.PegarPorId(avaliacao.Id);

            avaliacao.Should().BeNull();
        }
    }
}

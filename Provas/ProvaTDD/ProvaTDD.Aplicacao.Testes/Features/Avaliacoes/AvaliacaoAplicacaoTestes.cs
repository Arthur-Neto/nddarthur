using FluentAssertions;
using Moq;
using NUnit.Framework;
using ProvaTDD.Aplicacao.Features.Avaliacoes;
using ProvaTDD.Common.Testes.Features;
using ProvaTDD.Dominio.Features.Avaliacoes;
using System.Collections.Generic;
using System.Linq;

namespace ProvaTDD.Aplicacao.Testes.Features.Avaliacoes
{
    [TestFixture]
    public class AvaliacaoAplicacaoTestes
    {
        Mock<IAvaliacaoRepositorio> repositorio;
        AvaliacaoServico servico;
        Avaliacao avaliacao;

        [SetUp]
        public void SetUp()
        {
            repositorio = new Mock<IAvaliacaoRepositorio>();
            servico = new AvaliacaoServico(repositorio.Object);
        }

        [Test]
        public void Avaliacao_Servico_Salvar_DeveSalvarOk()
        {
            avaliacao = ObjectMother.ObterAvaliacaoValida();
            repositorio.Setup(m => m.Salvar(avaliacao)).Returns(new Avaliacao { Id = 1 });

            avaliacao = servico.Salvar(avaliacao);

            avaliacao.Id.Should().BeGreaterThan(0);
            repositorio.Verify(m => m.Salvar(avaliacao));
            repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Avaliacao_Servico_Atualizar_DeveAtualizarOk()
        {
            avaliacao = ObjectMother.ObterAvaliacaoValida();
            repositorio.Setup(m => m.Salvar(avaliacao)).Returns(new Avaliacao { Id = 1 });
            repositorio.Setup(m => m.Atualizar(avaliacao)).Returns(new Avaliacao { Id = 1 });
            repositorio.Setup(m => m.PegarPorId(avaliacao.Id)).Returns(new Avaliacao { Id = 1 });
            avaliacao = servico.Salvar(avaliacao);
            avaliacao = servico.PegarPorId(avaliacao.Id);
            avaliacao.Assunto = "Portugues";

            avaliacao = servico.Atualizar(avaliacao);

            avaliacao.Id.Should().BeGreaterThan(0);
            avaliacao.Assunto.Should().Be("Portugues");
            repositorio.Verify(m => m.Atualizar(avaliacao));
            repositorio.Verify(m => m.Salvar(avaliacao));
            repositorio.Verify(m => m.PegarPorId(avaliacao.Id));
            repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Avaliacao_Servico_PegarPorId_DevePegarPorIdOk()
        {
            avaliacao = ObjectMother.ObterAvaliacaoValida();
            repositorio.Setup(m => m.Salvar(avaliacao)).Returns(new Avaliacao { Id = 1 });
            repositorio.Setup(m => m.PegarPorId(avaliacao.Id)).Returns(new Avaliacao { Id = 1 });
            avaliacao = servico.Salvar(avaliacao);

            Avaliacao avaliacaoPego = servico.PegarPorId(avaliacao.Id);

            avaliacaoPego.Id.Should().Equals(avaliacao.Id);
            repositorio.Verify(m => m.PegarPorId(avaliacao.Id));
            repositorio.Verify(m => m.Salvar(avaliacao));
            repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Avaliacao_Servico_PegarTodos_DevePegarTodosOk()
        {
            avaliacao = ObjectMother.ObterAvaliacaoValida();
            repositorio.Setup(m => m.Salvar(avaliacao)).Returns(new Avaliacao { Id = 1 });
            repositorio.Setup(m => m.PegarTodos()).Returns(new List<Avaliacao>());
            avaliacao = servico.Salvar(avaliacao);

            IList<Avaliacao> avaliacoes = servico.PegarTodos();

            avaliacoes.Count.Should().BeGreaterThan(0);
            avaliacoes.Last().Id.Should().Be(avaliacao.Id);
            repositorio.Verify(m => m.PegarTodos());
            repositorio.Verify(m => m.Salvar(avaliacao));
            repositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Avaliacao_Servico_Deletar_DeveDeletarOk()
        {
            avaliacao = ObjectMother.ObterAvaliacaoValida();
            repositorio.Setup(m => m.Salvar(avaliacao)).Returns(new Avaliacao { Id = 1 });
            repositorio.Setup(m => m.Deletar(avaliacao));
            avaliacao = servico.Salvar(avaliacao);

            servico.Deletar(avaliacao);

            avaliacao = servico.PegarPorId(avaliacao.Id);
            avaliacao.Should().BeNull();
            repositorio.Verify(m => m.Deletar(avaliacao));
            repositorio.Verify(m => m.Salvar(avaliacao));
            repositorio.VerifyNoOtherCalls();
        }
    }
}

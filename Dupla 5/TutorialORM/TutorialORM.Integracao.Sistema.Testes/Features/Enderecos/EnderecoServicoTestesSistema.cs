using FluentAssertions;
using NUnit.Framework;
using System;
using System.Data.Entity;
using System.Linq;
using TutorialORM.Aplicacao.Features.Enderecos;
using TutorialORM.Common.Testes.Base;
using TutorialORM.Common.Testes.Features;
using TutorialORM.Dominio.Exceptions;
using TutorialORM.Dominio.Features.Enderecos;
using TutorialORM.Infra.Data.Base;
using TutorialORM.Infra.Data.Features.Enderecos;

namespace TutorialORM.Integracao.Sistema.Testes.Features.Enderecos
{
    [TestFixture]
    public class EnderecoServicoTestesSistema
    {
        EscolaContext contexto;
        IEnderecoRepositorio repositorio;
        EnderecoServico servico;
        Endereco endereco;

        [SetUp]
        public void SetUp()
        {
            contexto = new EscolaContext();
            repositorio = new EnderecoRepositorio(contexto);
            servico = new EnderecoServico(repositorio);
            Database.SetInitializer(new BaseSqlTestes());
            contexto.Database.Initialize(true);
        }

        [Test]
        public void Endereco_Sistema_Aplicacao_Salvar_NaoDeveJogarExcecao()
        {
            endereco = ObjectMother.ObterEnderecoValido();

            var enderecoSalva = servico.Salvar(endereco);

            enderecoSalva.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Endereco_Sistema_Aplicacao_PegarPorId_NaoDeveJogarExcecao()
        {
            endereco = ObjectMother.ObterEnderecoValido();
            endereco.Id = 1;
            servico.Salvar(endereco);

            var enderecoPego = servico.PegarPorId(endereco.Id);

            enderecoPego.Id.Should().Be(endereco.Id);
        }

        [Test]
        public void Endereco_Sistema_Aplicacao_PegarPorId_DeveJogarExcecaoIdentificadorInvalido()
        {
            var id = 0;

            Action acao = () => servico.PegarPorId(id);

            acao.Should().Throw<IdentificadorInvalidoException>();
        }

        [Test]
        public void Endereco_Sistema_Aplicacao_PegarTodos_NaoDeveJogarExcecao()
        {
            endereco = ObjectMother.ObterEnderecoValido();
            endereco = servico.Salvar(endereco);


            var enderecos = servico.PegarTodos();

            enderecos.Last().Id.Should().Be(endereco.Id);
        }

        [Test]
        public void Endereco_Sistema_Aplicacao_Atualizar_NaoDeveJogarExcecao()
        {
            endereco = ObjectMother.ObterEnderecoValido();
            endereco = servico.Salvar(endereco);
            endereco.Bairro = "atualizado";

            var enderecoAtualizada = servico.Atualizar(endereco);

            enderecoAtualizada.Bairro.Should().Be(endereco.Bairro);
        }

        [Test]
        public void Endereco_Sistema_Aplicacao_Atualizar_DeveJogarIdentificadorInvalidoExcecao()
        {
            endereco = ObjectMother.ObterEnderecoValido();
            endereco.Id = 0;

            Action acao = () => servico.Atualizar(endereco);

            acao.Should().Throw<IdentificadorInvalidoException>();
        }

        [Test]
        public void Endereco_Sistema_Aplicacao_Deletar_NaoDeveJogarExcecao()
        {
            endereco = ObjectMother.ObterEnderecoValido();
            endereco = servico.Salvar(endereco);

            servico.Deletar(endereco);

            var enderecoDeletada = servico.PegarPorId(endereco.Id);

            enderecoDeletada.Should().BeNull();
        }

        [Test]
        public void Endereco_Sistema_Aplicacao_Deletar_DeveJogarIdentificadorInvalidoExcecao()
        {
            endereco.Id = 0;

            Action acao = () => servico.Deletar(endereco);

            acao.Should().Throw<IdentificadorInvalidoException>();
        }

        [Test]
        public void Endereco_Sistema_Aplicacao_Deletar_DeveJogarEnderecoReferenciadoExcecao()
        {
            endereco = new Endereco { Id = 1 };

            Action acao = () => servico.Deletar(endereco);

            acao.Should().Throw<EnderecoReferenciadoException>();
        }
    }
}

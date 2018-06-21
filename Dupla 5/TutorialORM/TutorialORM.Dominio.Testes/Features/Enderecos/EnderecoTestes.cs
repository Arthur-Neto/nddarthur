using FluentAssertions;
using NUnit.Framework;
using System;
using TutorialORM.Common.Testes.Features;
using TutorialORM.Dominio.Features.Enderecos;

namespace TutorialORM.Dominio.Testes.Features.Enderecos
{
    [TestFixture]
    public class EnderecoTestes
    {
        Endereco endereco;
        
        [Test]
        public void Endereco_Dominio_Validar_DeveValidarOk()
        {
            endereco = ObjectMother.ObterEnderecoValido();

            Action acao = endereco.Validar;

            acao.Should().NotThrow();
        }

        [Test]
        public void Endereco_Dominio_Validar_DeveJogarExcecaoEnderecoComBairroVazio()
        {
            endereco = ObjectMother.ObterEnderecoComBairroVazio();

            Action acao = endereco.Validar;

            acao.Should().Throw<EnderecoBairroVazioException>();
        }

        [Test]
        public void Endereco_Dominio_Validar_DeveJogarExcecaoComCidadeVazia()
        {
            endereco = ObjectMother.ObterEnderecoComCidadeVazia();

            Action acao = endereco.Validar;

            acao.Should().Throw<EnderecoCidadeVaziaException>();
        }

        [Test]
        public void Endereco_Dominio_Validar_DeveJogarExcecaoComLogradouroVazio()
        {
            endereco = ObjectMother.ObterEnderecoComLogradouroVazio();

            Action acao = endereco.Validar;

            acao.Should().Throw<EnderecoLogradouroVazioException>();
        }

        [Test]
        public void Endereco_Dominio_Validar_DeveJogarExcecaoNumeroInvalido()
        {
            endereco = ObjectMother.ObterEnderecoComNumeroInvalido();

            Action acao = endereco.Validar;

            acao.Should().Throw<EnderecoNumeroInvalidoException>();
        }

        [Test]
        public void Endereco_Dominio_Validar_DeveJogarExcecaoUfVazio()
        {
            endereco = ObjectMother.ObterEnderecoComUFVazio();

            Action acao = endereco.Validar;

            acao.Should().Throw<EnderecoUfVaziaException>();
        }
    }
}

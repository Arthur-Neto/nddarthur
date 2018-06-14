using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFe.Common.Testes.Features;
using NFe.Dominio.Features.Enderecos;
using NUnit.Framework;
using System;

namespace NFe.Dominio.Testes.Features.Enderecos
{
    [TestClass]

    public class EnderecoTestes
    {
        [SetUp]
        public void InitializeObjects()
        {
        }

        [Test]
        public void Endereco_Dominio_DeveValidarOk()
        {
            Endereco endereco = ObjectMother.ObterEnderecoValido();
            endereco.Validar();
            endereco.Id.Should().Be(1);
            endereco.Numero.Should().NotBeNull();
        }

        [Test]
        public void Endereco_Dominio_DeveJogarExcecaoBairroVazio()
        {
            Endereco endereco = ObjectMother.ObterEnderecoBairroVazio();

            Action act = endereco.Validar;

            act.Should().Throw<EnderecoEmptyBairroException>();
        }

        [Test]
        public void Endereco_Dominio_DeveJogarExcecaoEstadoVazio()
        {
            Endereco endereco = ObjectMother.ObterEnderecoEstadoVazio();

            Action act = endereco.Validar;

            act.Should().Throw<EnderecoEmptyEstadoException>();
        }

        [Test]
        public void Endereco_Dominio_DeveJogarExcecaoLogradouroVazio()
        {
            Endereco endereco = ObjectMother.ObterEnderecoLogradouroVazio();

            Action act = endereco.Validar;

            act.Should().Throw<EnderecoEmptyLogradouroException>();
        }


        [Test]
        public void Endereco_Dominio_DeveValidarComNumeroVazio()
        {
            Endereco endereco = ObjectMother.ObterEnderecoNumeroVazio();

            endereco.Validar();

            endereco.Numero.Should().Be("s/n");
        }

        [Test]
        public void Endereco_Dominio_DeveJogarExcecaoMunicipioVazio()
        {
            Endereco endereco = ObjectMother.ObterEnderecoMunicipioVazio();

            Action act = endereco.Validar;

            act.Should().Throw<EnderecoEmptyMunicipioException>();
        }

        [Test]
        public void Endereco_Dominio_DeveJogarExcecaoPaisVazio()
        {
            Endereco endereco = ObjectMother.ObterEnderecoPaisVazio();

            Action act = endereco.Validar;

            act.Should().Throw<EnderecoEmptyPaisException>();
        }
    }
}

using NUnit.Framework;
using Projeto_NFe.Comuns.Testes.Features.Enderecos;
using Projeto_NFe.Dominio.Features.Enderecos;
using FluentAssertions;
using System;
using Projeto_NFe.Dominio.Features.Enderecos.Excecoes;

namespace Projeto_NFe.Dominio.Testes.Features.Enderecos
{
    [TestFixture]
    public class EnderecoDominioTestes
    {
        Endereco _endereco;

        [SetUp]
        public void Setup()
        {
            _endereco = new Endereco();
        }

        [Test]
        public void Endereco_Dominio_Validar_EsperadoOK()
        {
            //cenário
            _endereco = EnderecoObjetoMae.ObterValido();

            //Ação
            Action action = ()=> _endereco.Validar();

            //Verificação
            action.Should().NotThrow();
        }

        [Test]
        public void Endereco_Dominio_Validar_CepInvalido_EsperadoFalha()
        {
            //cenário
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Cep = String.Empty;

            //Ação
            Action action = () => _endereco.Validar();

            //Verificação
            action.Should().Throw<ExcecaoCepInvalido>();
        }

        [Test]
        public void Endereco_Dominio_Validar_RuaInvalida_EsperadoFalha()
        {
            //cenário
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Rua = String.Empty;

            //Ação
            Action action = () => _endereco.Validar();

            //Verificação
            action.Should().Throw<ExcecaoRuaInvalida>();
        }

        [Test]
        public void Endereco_Dominio_Validar_BairroInvalido_EsperadoFalha()
        {
            //cenário
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Bairro = String.Empty;

            //Ação
            Action action = () => _endereco.Validar();

            //Verificação
            action.Should().Throw<ExcecaoBairroInvalido>();
        }

        [Test]
        public void Endereco_Dominio_Validar_CidadeInvalida_EsperadoFalha()
        {
            //cenário
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Cidade = String.Empty;

            //Ação
            Action action = () => _endereco.Validar();

            //Verificação
            action.Should().Throw<ExcecaoCidadeInvalida>();
        }

        [Test]
        public void Endereco_Dominio_Validar_UFInvalido_EsperadoFalha()
        {
            //cenário
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.UF = String.Empty;

            //Ação
            Action action = () => _endereco.Validar();

            //Verificação
            action.Should().Throw<ExcecaoUFInvalido>();
        }

        [Test]
        public void Endereco_Dominio_Validar_PaisInvalido_EsperadoFalha()
        {
            //cenário
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Pais = String.Empty;

            //Ação
            Action action = () => _endereco.Validar();

            //Verificação
            action.Should().Throw<ExcecaoPaisInvalido>();
        }

        [Test]
        public void Endereco_Dominio_Validar_NumeroInvalido_EsperadoFalha()
        {
            //cenário
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Numero = 0;

            //Ação
            Action action = () => _endereco.Validar();

            //Verificação
            action.Should().Throw<ExcecaoNumeroInvalido>();
        }
    }
}

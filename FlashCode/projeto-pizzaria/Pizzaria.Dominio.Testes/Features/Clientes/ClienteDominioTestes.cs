using FluentAssertions;
using NUnit.Framework;
using Pizzaria.Common.Testes.Features;
using Pizzaria.Dominio.Features.Clientes;
using Pizzaria.Dominio.Features.Clientes.Excecoes;
using System;

namespace Pizzaria.Dominio.Testes.Features.Clientes
{
    [TestFixture]
    public class ClienteDominioTestes
    {
        Cliente _cliente;

        [SetUp]
        public void SetUp()
        {
            _cliente = new Cliente();
        }

        [Test]
        public void Cliente_Dominio_Validar_Deve_Nao_Lancar_Excecao()
        {
            //cenario
            _cliente = ObjetoMae.ObterClienteValidoComCpf();

            //acao
            Action action = () => _cliente.Validar();

            //verificar
            action.Should().NotThrow();
        }

        [Test]
        public void Cliente_Dominio_Validar_Deve_Lancar_Excecao_NomeInvalido()
        {
            //cenario
            _cliente = ObjetoMae.ObterClienteValidoComCpf();
            _cliente.Nome = String.Empty;

            //acao
            Action action = () => _cliente.Validar();

            //verificar
            action.Should().Throw<NomeInvalidoExcecao>();
        }

        [Test]
        public void Cliente_Dominio_Validar_Deve_Lancar_Excecao_EnderecoInvalido()
        {
            //cenario
            _cliente = ObjetoMae.ObterClienteValidoComCpf();
            _cliente.Endereco = null;

            //acao
            Action action = () => _cliente.Validar();

            //verificar
            action.Should().Throw<EnderecoInvalidoExcecao>();
        }

        [Test]
        public void Cliente_Dominio_Validar_Deve_Lancar_Excecao_TelefoneInvalido()
        {
            //cenario
            _cliente = ObjetoMae.ObterClienteValidoComCpf();
            _cliente.Telefone = String.Empty;

            //acao
            Action action = () => _cliente.Validar();

            //verificar
            action.Should().Throw<TelefoneInvalidoExcecao>();
        }

        [Test]
        public void Cliente_Dominio_Validar_Deve_Lancar_Excecao_DataNascimentoInvalida()
        {
            //cenario
            _cliente = ObjetoMae.ObterClienteValidoComCpf();
            _cliente.DataDeNascimento = DateTime.Now.AddDays(1);

            //acao
            Action action = () => _cliente.Validar();

            //verificar
            action.Should().Throw<DataNascimentoInvalidaExcecao>();
        }
    }
}

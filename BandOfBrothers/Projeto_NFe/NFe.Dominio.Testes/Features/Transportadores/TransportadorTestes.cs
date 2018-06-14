using FluentAssertions;
using NFe.Common.Testes.Features;
using NFe.Dominio.Exceptions;
using NFe.Dominio.Features.Transportadores;
using NUnit.Framework;
using System;

namespace NFe.Dominio.Testes.Features.Transportadores
{
    [TestFixture]
    public class TransportadorTestes
    {
        Transportador transportador;

        [SetUp]
        public void SetUp()
        {
            transportador = new Transportador();
        }

        [Test]
        public void Transportador_Dominio_Validar_DeveValidarComCpfENomeOk()
        {
            transportador = ObjectMother.ObterTransportadorValidoComCpfENome();

            Action acao = transportador.Validar;

            acao.Should().NotThrow();
        }

        [Test]
        public void Transportador_Dominio_Validar_DeveValidarComCpfERazaoSocialOk()
        {
            transportador = ObjectMother.ObterTransportadorValidoComCpfERazaoSocial();

            Action acao = transportador.Validar;

            acao.Should().NotThrow();
        }

        [Test]
        public void Transportador_Dominio_Validar_DeveValidarComCnpjENomeOk()
        {
            transportador = ObjectMother.ObterTransportadorValidoComCnpjENome();

            Action acao = transportador.Validar;

            acao.Should().NotThrow();
        }

        [Test]
        public void Transportador_Dominio_Validar_DeveValidarComCnpjERazaoSocialOk()
        {
            transportador = ObjectMother.ObterTransportadorValidoComCnpjERazaoSocial();

            Action acao = transportador.Validar;

            acao.Should().NotThrow();
        }

        [Test]
        public void Transportador_Dominio_Validar_DeveJogarExcecaoComCpfOuCpfVazio()
        {
            transportador = ObjectMother.ObterTransportadorInvalidoSemCpfOuCnpj();

            Action acao = transportador.Validar;

            acao.Should().Throw<TransportadorEmptyCpfCnpjException>();
        }

        [Test]
        public void Transportador_Dominio_Validar_DeveJogarExcecaoComNomeOuRazaoSocialVazio()
        {
            transportador = ObjectMother.ObterTransportadorInvalidoSemNomeOuRazaoSocial();

            Action acao = transportador.Validar;

            acao.Should().Throw<TransportadorEmptyNomeRazaoException>();
        }

        [Test]
        public void Transportador_Dominio_Validar_DeveJogarExcecaoComInscricaoEstadualVazio()
        {
            transportador = ObjectMother.ObterTransportadorInvalidoSemInscricaoEstadual();

            Action acao = transportador.Validar;

            acao.Should().Throw<TransportadorEmptyInscricaoEstadualException>();
        }

        [Test]
        public void Transportador_Dominio_Validar_DeveValidarCpfComCnpjVazio()
        {
            transportador = ObjectMother.ObterTransportadorComCnpjVazio();

            Action acao = transportador.Validar;

            acao.Should().NotThrow();
        }

        [Test]
        public void Transportador_Dominio_Validar_DeveValidarCnpjComCpfVazio()
        {
            transportador = ObjectMother.ObterTransportadorComCpfVazio();

            Action acao = transportador.Validar;

            acao.Should().NotThrow();
        }

        [Test]
        public void Transportador_Dominio_Validar_DeveFalharCpfInvalido()
        {
            transportador = ObjectMother.ObterTransportadorCpfInvalido();
            transportador.Cnpj = "";

            Action acao = transportador.Validar;

            acao.Should().Throw<CpfInvalidoException>();
        }

        [Test]
        public void Transportador_Dominio_Validar_DeveJogarExcecaoCnpjZeradoECpfPenultimoDigitoInvalido()
        {
            transportador = ObjectMother.ObterTransportadorCnpjZeradoCpfInvalidoPenultimoDigito();

            Action acao = transportador.Validar;

            acao.Should().Throw<CpfInvalidoException>();
        }

        [Test]
        public void Transportador_Dominio_Validar_DeveJogarExcecaoCnpjZeradoECpfUltimoDigitoInvalido()
        {
            transportador = ObjectMother.ObterTransportadorCnpjZeradoCpfInvalidoUltimoDigito();

            Action acao = transportador.Validar;

            acao.Should().Throw<CpfInvalidoException>();
        }

        [Test]
        public void Transportador_Dominio_Validar_DeveJogarExcecaoCpfVazioCnpjMenorQue14Digitos()
        {
            transportador = ObjectMother.ObterTransportadorCpfVazioCnpjMenorQue14();

            Action acao = transportador.Validar;

            acao.Should().Throw<CnpjInvalidoException>();
        }
    }
}

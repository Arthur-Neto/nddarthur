using FluentAssertions;
using NFe.Common.Testes.Features;
using NFe.Dominio.Exceptions;
using NFe.Dominio.Features.Destinatarios;
using NUnit.Framework;
using System;

namespace NFe.Dominio.Testes.Features.Destinatarios
{
    [TestFixture]
    public class DestinatarioTestes
    {
        Destinatario destinatario;

        [SetUp]
        public void SetUp()
        {
            destinatario = new Destinatario();
        }

        [Test]
        public void Destinatario_Dominio_DeveValidarOk()
        {
            destinatario = ObjectMother.ObtemDestinatarioCpfVazio();

            Action action = () => destinatario.Validar();

            action.Should().NotThrow();

            destinatario.Cnpj.valorFormatado.Should().Be("06255692000103");
        }

        [Test]
        public void Destinatario_Dominio_NaoDeveEstourarExcecaoNomeVazio()
        {
            destinatario = ObjectMother.ObtemDestinatarioNomeVazio();

            Action action = () => destinatario.Validar();

            action.Should().NotThrow();
        }

        [Test]
        public void Destinatario_Dominio_NaoDeveEstourarExcecaoRazaoSocialVazio()
        {
            destinatario = ObjectMother.ObtemDestinatarioRazaoSocialVazio();

            Action action = () => destinatario.Validar();

            action.Should().NotThrow();
        }

        [Test]
        public void Destinatario_Dominio_DeveEstourarExcecaoNomeeRazaoSocialVazio()
        {
            destinatario = ObjectMother.ObtemDestinatarioNomeeRazaoSocialVazio();

            Action action = () => destinatario.Validar();

            action.Should().Throw<DestinatarioEmptyRazaoNomeException>();
        }

        [Test]
        public void Destinatario_Dominio_NaoDeveEstourarExcecaoCnpjVazio()
        {
            destinatario = ObjectMother.ObtemDestinatarioCnpjVazio();

            Action action = () => destinatario.Validar();

            action.Should().NotThrow();
        }

        [Test]
        public void Destinatario_Dominio_NaoDeveEstourarExcecaoCpfVazio()
        {
            destinatario = ObjectMother.ObtemDestinatarioCpfVazio();

            Action action = () => destinatario.Validar();

            action.Should().NotThrow();
        }

        [Test]
        public void Destinatario_Dominio_DeveEstourarExcecaoCpfeCnpjVazio()
        {
            destinatario = ObjectMother.ObtemDestinatarioCnpjECpfVazio();

            Action action = () => destinatario.Validar();

            action.Should().Throw<DestinatarioEmptyCpfCnpjException>();
        }

        [Test]
        public void Destinatario_Dominio_DeveEstourarExcecaoInscricaoEstadualVazio()
        {
            destinatario = ObjectMother.ObtemDestinatarioInscricaoEstadualVazio();

            Action action = () => destinatario.Validar();

            action.Should().Throw<DestinatarioEmptyInscricaoEstadualException>();
        }
        [Test]
        public void Destinatario_Dominio_DeveEstourarExcecaoCnpjInvalidoUltimoDigitoECpfVazio()
        {
            destinatario = ObjectMother.ObtemDestinatarioCnpjInvalidoUltimoDigitoECpfVazio();

            Action action = () => destinatario.Validar();

            action.Should().Throw<CnpjInvalidoException>();
        }
        [Test]
        public void Destinatario_Dominio_DeveEstourarExcecaoCnpjVazioECpfInvalidoUltimoDigito()
        {
            destinatario = ObjectMother.ObtemDestinatarioCnpjVazioECpfInvalidoUltimoDigito();

            Action action = () => destinatario.Validar();

            action.Should().Throw<CpfInvalidoException>();
        }
    }
}

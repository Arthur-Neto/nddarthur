using FluentAssertions;
using NFe.Common.Testes.Features;
using NFe.Dominio.Exceptions;
using NFe.Dominio.Features.Emitentes;
using NUnit.Framework;
using System;

namespace NFe.Dominio.Testes.Features.Emitentes
{
    [TestFixture]
    public class EmitenteTestes
    {
        Emitente emitente;

        [SetUp]
        public void SetUp()
        {
            emitente = new Emitente();
        }

        [Test]
        public void Emitente_Dominio_DeveValidarOk()
        {
            emitente = ObjectMother.ObterEmitenteValido();

            Action acao = emitente.Validar;

            acao.Should().NotThrow();
        }

        [Test]
        public void Emitente_Dominio_DeveJogarExcecaoNomeVazio()
        {
            emitente = ObjectMother.ObterEmitenteComNomeVazio();

            Action acao = emitente.Validar;

            acao.Should().Throw<EmitenteEmptyNomeException>();
        }

        [Test]
        public void Emitente_Dominio_DeveJogarExcecaoRazaoSocialVazio()
        {
            emitente = ObjectMother.ObterEmitenteComRazaoSocialVazio();

            Action acao = emitente.Validar;

            acao.Should().Throw<EmitenteEmptyRazaoSocialException>();
        }

        [Test]
        public void Emitente_Dominio_DeveJogarExcecaoInscricaoEstadualVazio()
        {
            emitente = ObjectMother.ObterEmitenteComInscricaoEstadualVazio();

            Action acao = emitente.Validar;

            acao.Should().Throw<EmitenteEmptyInscricaoEstadualException>();
        }

        [Test]
        public void Emitente_Dominio_DeveJogarExcecaoInscricaoMunicipalVazio()
        {
            emitente = ObjectMother.ObterEmitenteComInscricaoMunicipalVazio();

            Action acao = emitente.Validar;

            acao.Should().Throw<EmitenteEmptyInscricaoMunicipalException>();
        }

        [Test]
        public void Emitente_Dominio_DeveJogarExcecaoCpfECnpjVazio()
        {
            emitente = ObjectMother.ObterEmitenteComCpnjECpfVazio();

            Action acao = emitente.Validar;

            acao.Should().Throw<EmitenteEmptyCpfCnpjException>();
        }

        [Test]
        public void Emitente_Dominio_DeveValidarComCpnjVazio()
        {
            emitente = ObjectMother.ObterEmitenteComCnpjVazio();

            Action acao = emitente.Validar;

            acao.Should().NotThrow();
        }

        [Test]
        public void Emitente_Dominio_DeveValidarComCpfVazio()
        {
            emitente = ObjectMother.ObterEmitenteComCpfVazio();

            Action acao = emitente.Validar;

            acao.Should().NotThrow();
        }

        [Test]
        public void Emitente_Dominio_NaoDeveJogarExcecaoCpfVazio()
        {
            emitente = ObjectMother.ObterEmitenteValido();

            Action acao = emitente.Validar;

            acao.Should().NotThrow();
        }

        [Test]
        public void Emitente_Dominio_CnpjMenorQue14Digitos_DeveFalhar()
        {
            emitente = ObjectMother.ObterEmitenteComCnpjMenorQue14();

            Action acao = emitente.Validar;

            acao.Should().Throw<CnpjInvalidoException>();
        }
    }
}

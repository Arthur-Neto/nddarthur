using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Comuns.Testes.Features.Emitentes;
using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Dominio.Features.Emitentes;
using Projeto_NFe.Dominio.Features.Emitentes.Excercoes;
using Projeto_NFe.Dominio.Features.Enderecos;
using Projeto_NFe.Infra.Documentos.Features.Cnpjs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Dominio.Testes.Features.Emitentes
{
    [TestFixture]
    public class EmitenteDominioTestes
    {
        private Emitente _emitente;
        private Mock<Cnpj> _mockCnpj;
        private Mock<Endereco> _mockEndereco;

        [SetUp]
        public void Setup()
        {
            _emitente = new Emitente();
            _mockCnpj = new Mock<Cnpj>();
            _mockEndereco = new Mock<Endereco>();
        }
        [Test]
        public void Emitente_Dominio_Validar_EsperadoOK()
        {
            //cenário
            _mockCnpj.Setup(cn => cn.Validar());
            _mockEndereco.Setup(en => en.Validar());
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.CNPJ = _mockCnpj.Object;
            _emitente.Endereco = _mockEndereco.Object;
            //Ação
            Action action = () => _emitente.Validar();

            //Verificação
            action.Should().NotThrow();
            _mockCnpj.Verify(cn => cn.Validar());
            _mockEndereco.Verify(en => en.Validar());
        }
        [Test]
        public void Emitente_Dominio_Validar_EnderecoInvalido_EsperadoFalha()
        {
            //cenário
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.Endereco = null;
            _emitente.CNPJ = _mockCnpj.Object;

            //Ação
            Action action = () => _emitente.Validar();

            //Verificação
            action.Should().Throw<ExcecaoEnderecoEmBranco>();
            _mockCnpj.VerifyNoOtherCalls();
        }

        [Test]
        public void Emitente_Dominio_Validar_CNPJNulo_EsperadoFalha()
        {
            //cenário
            _mockEndereco.Setup(en => en.Validar());
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.CNPJ = null;
            _emitente.Endereco = _mockEndereco.Object;

            //Ação
            Action action = () => _emitente.Validar();

            //Verificação
            action.Should().Throw<ExcecaoCNPJInvalido>();
            _mockEndereco.Verify(en => en.Validar());
        }
        [Test]
        public void Emitente_Dominio_Validar_NomeFantasiaInvalido_EsperadoFalha()
        {
            //cenário
            _mockEndereco.Setup(en => en.Validar());
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.NomeFantasia = String.Empty;
            _emitente.CNPJ = _mockCnpj.Object;
            _emitente.Endereco = _mockEndereco.Object;

            //Ação
            Action action = () => _emitente.Validar();

            //Verificação
            action.Should().Throw<ExcecaoNomeEmBranco>();
            _mockCnpj.VerifyNoOtherCalls();
            _mockEndereco.Verify(en => en.Validar());
        }
        [Test]
        public void Emitente_Dominio_Validar_CNPJInvalido_EsperadoFalha()
        {
            //cenário
            _mockEndereco.Setup(en => en.Validar());
            _mockCnpj.Setup(cn => cn.Validar()).Throws(new ExcecaoCNPJInvalido());
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.CNPJ = _mockCnpj.Object;
            _emitente.Endereco = _mockEndereco.Object;

            //Ação
            Action action = () => _emitente.Validar();

            //Verificação
            action.Should().Throw<ExcecaoCNPJInvalido>();
            _mockCnpj.Verify(cn => cn.Validar());
            _mockEndereco.Verify(en => en.Validar());
        }
        [Test]
        public void Emitente_Dominio_Validar_InscricaoEstadualnvalido_EsperadoFalha()
        {
            //cenário
            _mockEndereco.Setup(en => en.Validar());
            _mockCnpj.Setup(cn => cn.Validar());
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.InscricaoEstadual = String.Empty;
            _emitente.CNPJ = _mockCnpj.Object;
            _emitente.Endereco = _mockEndereco.Object;

            //Ação
            Action action = () => _emitente.Validar();

            //Verificação
            action.Should().Throw<ExcecaoInscricaoEstadualInvalido>();
            _mockCnpj.Verify(cn => cn.Validar());
            _mockEndereco.Verify(en => en.Validar());
        }
        [Test]
        public void Emitente_Dominio_Validar_InscricaoMunicipalInvalido_EsperadoFalha()
        {
            //cenário
            _mockEndereco.Setup(en => en.Validar());
            _mockCnpj.Setup(cn => cn.Validar());
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.InscricaoMunicipal = String.Empty;
            _emitente.CNPJ = _mockCnpj.Object;
            _emitente.Endereco = _mockEndereco.Object;

            //Ação
            Action action = () => _emitente.Validar();

            //Verificação
            action.Should().Throw<ExcecaoInscricaoMunicipalInvalido>();
            _mockCnpj.Verify(cn => cn.Validar());
            _mockEndereco.Verify(en => en.Validar());
        }

        [Test]
        public void Emitente_Dominio_Validar_RazaoSocialNula_EsperadoFalha()
        {
            //cenário
            _mockEndereco.Setup(en => en.Validar());
            _mockCnpj.Setup(cn => cn.Validar());
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.RazaoSocial = String.Empty;
            _mockCnpj.Setup(cn => cn.Validar());
            _emitente.CNPJ = _mockCnpj.Object;
            _emitente.Endereco = _mockEndereco.Object;

            //Ação
            Action action = () => _emitente.Validar();

            //Verificação
            action.Should().Throw<ExcecaoRazaoSocialInvalida>();
            _mockCnpj.Verify(cn => cn.Validar());
            _mockEndereco.Verify(en => en.Validar());
        }
    }
}

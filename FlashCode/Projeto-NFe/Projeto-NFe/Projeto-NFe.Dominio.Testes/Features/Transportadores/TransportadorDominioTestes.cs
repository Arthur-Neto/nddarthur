using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Comuns.Testes.Features.Cnpjs;
using Projeto_NFe.Comuns.Testes.Features.Cpfs;
using Projeto_NFe.Comuns.Testes.Features.Transportadores;
using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Dominio.Features.Enderecos;
using Projeto_NFe.Dominio.Features.Transportadores;
using Projeto_NFe.Infra.Documentos.Features.Cnpjs;
using Projeto_NFe.Infra.Documentos.Features.Cpfs;
using System;

namespace Projeto_NFe.Dominio.Testes.Features.Transportadores
{
    [TestFixture]
    public class TransportadorDominioTestes
    {
        private Transportador _transportador;
        private Mock<Cnpj> _mockCnpj;
        private Mock<Cpf> _mockCpf;
        private Mock<Endereco> _mockEndereco;

        [SetUp]
        public void Setup()
        {
            _transportador = new Transportador();
            _mockCnpj = new Mock<Cnpj>();
            _mockCpf = new Mock<Cpf>();
            _mockEndereco = new Mock<Endereco>();
        }

        [Test]
        public void Transportador_Dominio_Validar_Empresa_EsperadoOK()
        {
            //cenário
            _mockEndereco.Setup(en => en.Validar());
            _mockCnpj.Setup(cn => cn.Validar());
            _transportador = TransportadorObjetoMae.ObterValidoEmpresa();
            _transportador.Endereco = _mockEndereco.Object;
            _transportador.Cnpj = _mockCnpj.Object;
            //Ação
            Action action = () => _transportador.Validar();

            //Verificação
            action.Should().NotThrow();
            _mockEndereco.Verify(en => en.Validar());
            _mockCnpj.Verify(cn => cn.Validar());
        }
        [Test]
        public void Transportador_Dominio_Validar_Pessoa_EsperadoOK()
        {
            //cenário
            _mockEndereco.Setup(en => en.Validar());
            _mockCpf.Setup(cp => cp.Validar());

            _transportador = TransportadorObjetoMae.ObterValidoPessoa();
            _transportador.Cpf = _mockCpf.Object;
            _transportador.Endereco = _mockEndereco.Object;

            //Ação
            Action action = () => _transportador.Validar();

            //Verificação
            action.Should().NotThrow();
            _mockEndereco.Verify(en => en.Validar());
            _mockCpf.Verify(cp => cp.Validar());
        }
        [Test]
        public void Transportador_Dominio_Validar_Pessoa_NomeEmBranco_EsperandoFalha()
        {
            //Cenário
            _mockEndereco.Setup(en => en.Validar());
            _transportador = TransportadorObjetoMae.ObterValidoPessoa();
            _transportador.Nome = String.Empty;
            _transportador.Endereco = _mockEndereco.Object;

            //Ação
            Action action = () => _transportador.Validar();

            //Verificação
            action.Should().Throw<ExcecaoNomeEmBranco>();
            _mockEndereco.Verify(en => en.Validar());
        }

        [Test]
        public void Transportador_Dominio_Validar_Pessoa_ComRazaoSocial_EsperandoFalha()
        {
            //Cenário
            _mockEndereco.Setup(en => en.Validar());
            _mockCpf.Setup(cp => cp.Validar());

            _transportador = TransportadorObjetoMae.ObterValidoPessoa();
            _transportador.RazaoSocial = "RazaoSocial";
            _transportador.Cpf = _mockCpf.Object;
            _transportador.Endereco = _mockEndereco.Object;

            //Ação
            Action action = () => _transportador.Validar();

            //Verificação
            action.Should().Throw<ExcecaoPessoaComRazaoSocial>();
            _mockCpf.Verify(cp => cp.Validar());
            _mockEndereco.Verify(en => en.Validar());
        }
        [Test]
        public void Transportador_Dominio_Validar_Pessoa_ComCpfNull_EsperandoFalha()
        {
            //Cenário
            _mockEndereco.Setup(en => en.Validar());

            _transportador = TransportadorObjetoMae.ObterValidoPessoa();
            _transportador.Cpf = null;
            _transportador.Endereco = _mockEndereco.Object;

            //Ação
            Action action = () => _transportador.Validar();

            //Verificação
            action.Should().Throw<ExcecaoCpfNaoDefinido>();
            _mockEndereco.Verify(en => en.Validar());
        }
        [Test]
        public void Transportador_Dominio_Validar_Pessoa_ComCnpj_EsperandoFalha()
        {
            //Cenário
            _mockEndereco.Setup(en => en.Validar());
            _mockCpf.Setup(cp => cp.Validar());

            _transportador = TransportadorObjetoMae.ObterValidoPessoa();
            _transportador.Cnpj = CnpjObjetoMae.ObterValidoComPontosTracos();
            _transportador.Cpf = _mockCpf.Object;
            _transportador.Endereco = _mockEndereco.Object;

            //Ação
            Action action = () => _transportador.Validar();

            //Verificação
            action.Should().Throw<ExcecaoPessoaComCnpj>();
            _mockEndereco.Verify(en => en.Validar());
            _mockCpf.Verify(cp => cp.Validar());
        }
        [Test]
        public void Transportador_Dominio_Validar_Empresa_RazaoSocialEmBranco_EsperandoFalha()
        {
            //Cenário
            _mockEndereco.Setup(en => en.Validar());

            _transportador = TransportadorObjetoMae.ObterValidoEmpresa();
            _transportador.RazaoSocial = String.Empty;
            _transportador.Endereco = _mockEndereco.Object;

            //Ação
            Action action = () => _transportador.Validar();

            //Verificação
            action.Should().Throw<ExcecaoRazaoSocialInvalida>();
            _mockEndereco.Verify(en => en.Validar());
        }

        [Test]
        public void Transportador_Dominio_Validar_Empresa_CnpjNumerosIguais_EsperandoFalha()
        {
            //Cenário

            _mockEndereco.Setup(en => en.Validar()).Throws(new ExcecaoCNPJInvalido());
            _mockCnpj.Setup(cn => cn.Validar());

            _transportador = TransportadorObjetoMae.ObterValidoEmpresa();
            _transportador.Cnpj = _mockCnpj.Object;
            _transportador.Endereco = _mockEndereco.Object;

            //Ação
            Action action = () => _transportador.Validar();

            //Verificação
            action.Should().Throw<ExcecaoCNPJInvalido>();
            _mockEndereco.Verify(en => en.Validar());
            _mockCnpj.VerifyNoOtherCalls();
        }

        [Test]
        public void Transportador_Dominio_Validar_Empresa_EnderecoEmBranco_EsperandoFalha()
        {
            //Cenário
            _transportador = TransportadorObjetoMae.ObterValidoEmpresa();
            _transportador.Endereco = null;

            //Ação
            Action action = () => _transportador.Validar();

            //Verificação
            action.Should().Throw<ExcecaoEnderecoEmBranco>();
        }
        [Test]
        public void Transportador_Dominio_Validar_Empresa_ComCpf_EsperandoFalha()
        {
            //Cenário
            _mockCpf.Setup(cp => cp.Validar());
            _mockEndereco.Setup(en => en.Validar());

            _transportador = TransportadorObjetoMae.ObterValidoEmpresa();
            _transportador.Cpf = _mockCpf.Object;
            _transportador.Endereco = _mockEndereco.Object;

            //Ação
            Action action = () => _transportador.Validar();

            //Verificação
            action.Should().Throw<ExcecaoEmpresaComCpf>();
            _mockEndereco.Verify(en => en.Validar());
            _mockCpf.VerifyNoOtherCalls();
        }
        [Test]
        public void Transportador_Dominio_Validar_Empresa_ComCnpjNulo_EsperandoFalha()
        {
            //Cenário
            _mockEndereco.Setup(en => en.Validar());
            _transportador = TransportadorObjetoMae.ObterValidoEmpresa();
            _transportador.Cnpj = null;
            _transportador.Endereco = _mockEndereco.Object;
            //Ação
            Action action = () => _transportador.Validar();

            //Verificação
            action.Should().Throw<ExcecaoCNPJInvalido>();
            _mockEndereco.Verify(en => en.Validar());
        }
    }
}

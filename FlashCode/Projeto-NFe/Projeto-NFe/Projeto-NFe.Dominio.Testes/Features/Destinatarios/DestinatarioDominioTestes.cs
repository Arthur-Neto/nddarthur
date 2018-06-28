using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Comuns.Testes.Features.Cnpjs;
using Projeto_NFe.Comuns.Testes.Features.Cpfs;
using Projeto_NFe.Comuns.Testes.Features.Destinatarios;
using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Dominio.Features.Destinatarios;
using Projeto_NFe.Dominio.Features.Enderecos;
using Projeto_NFe.Dominio.Features.Impostos;
using Projeto_NFe.Dominio.Features.Produtos;
using Projeto_NFe.Infra.Documentos.Features.Cnpjs;
using Projeto_NFe.Infra.Documentos.Features.Cpfs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Dominio.Testes.Features.Destinatarios
{
    [TestFixture]
    public class DestinatarioDominioTestes
    {
        private Destinatario _destinatario;
        private Mock<Endereco> _mockEndereco;
        private Mock<Cnpj> _mockCnpj;
        private Mock<Cpf> _mockCpf;

        [SetUp]
        public void Setup()
        {
            _destinatario = new Destinatario();
            _mockCnpj = new Mock<Cnpj>();
            _mockCpf = new Mock<Cpf>();
            _mockEndereco = new Mock<Endereco>();
        }
        [Test]
        public void Destinatario_Dominio_Validar_Empresa_EsperadoOK()
        {
            //Cenário
            _mockCnpj.Setup(cn => cn.Validar());
            _mockEndereco.Setup(en => en.Validar());
            _destinatario = DestinatarioObjetoMae.ObterValidoEmpresa();
            _destinatario.Endereco = _mockEndereco.Object;
            _destinatario.Cnpj = _mockCnpj.Object;

            //Ação
            Action action = () => _destinatario.Validar();

            //Verificação
            action.Should().NotThrow();
            _mockCnpj.Verify(cn => cn.Validar());
            _mockEndereco.Verify(en => en.Validar());
        }
        [Test]
        public void Destinatario_Dominio_Validar_Pessoa_EsperadoOK()
        {
            //Cenário
            _mockCpf.Setup(cp => cp.Validar());
            _mockEndereco.Setup(en => en.Validar());
            _destinatario = DestinatarioObjetoMae.ObterValidoPessoa();
            _destinatario.Cpf = _mockCpf.Object;
            _destinatario.Endereco = _mockEndereco.Object;
            //Ação
            Action action = () => _destinatario.Validar();

            //Verificação
            action.Should().NotThrow();
            _mockCpf.Verify(cp => cp.Validar());
            _mockEndereco.Verify(en => en.Validar());
        }
        [Test]
        public void Destinatario_Dominio_Validar_PessoaNomeEmBranco_EsperandoFalha()
        {
            //Cenário
            _mockEndereco.Setup(en => en.Validar());
            _mockCpf.Setup(cp => cp.Validar());
            _destinatario = DestinatarioObjetoMae.ObterValidoPessoa();
            _destinatario.Nome = String.Empty;
            _destinatario.Cpf = _mockCpf.Object;
            _destinatario.Endereco = _mockEndereco.Object;

            //Ação
            Action action = () => _destinatario.Validar();

            //Verificação
            action.Should().Throw<ExcecaoNomeEmBranco>();
            _mockEndereco.Verify(en => en.Validar());
            _mockCpf.VerifyNoOtherCalls();
        }
        [Test]
        public void Destinatario_Dominio_Validar_PessoaComCnpj_EsperandoFalha()
        {
            //Cenário
            _mockCpf.Setup(cp => cp.Validar());
            _mockEndereco.Setup(en => en.Validar());
            _destinatario = DestinatarioObjetoMae.ObterValidoPessoa();
            _destinatario.Cnpj = _mockCnpj.Object;
            _destinatario.Cpf = _mockCpf.Object;
            _destinatario.Endereco = _mockEndereco.Object;
            //Ação
            Action action = () => _destinatario.Validar();

            //Verificação
            action.Should().Throw<ExcecaoPessoaComCnpj>();
            _mockCpf.Verify(cp => cp.Validar());
            _mockEndereco.Verify(en => en.Validar());            
        }
        [Test]
        public void Destinatario_Dominio_Validar_PessoaComRazaoSocial_EsperandoFalha()
        {
            //Cenário
            _mockCpf.Setup(cp => cp.Validar());
            _mockEndereco.Setup(en => en.Validar());
            _destinatario = DestinatarioObjetoMae.ObterValidoPessoa();
            _destinatario.RazaoSocial = "RazaoSocial";
            _destinatario.Cpf = _mockCpf.Object;
            _destinatario.Endereco = _mockEndereco.Object;

            //Ação
            Action action = () => _destinatario.Validar();

            //Verificação
            action.Should().Throw<ExcecaoPessoaComRazaoSocial>();
            _mockCpf.Verify(cp => cp.Validar());
            _mockEndereco.Verify(en => en.Validar());
        }
        [Test]
        public void Destinatario_Dominio_Validar_PessoaComCpfNulo_EsperandoFalha()
        {
            //Cenário
            _mockEndereco.Setup(en => en.Validar());
            _destinatario = DestinatarioObjetoMae.ObterValidoPessoa();
            _destinatario.Cpf = null;
            _destinatario.Endereco = _mockEndereco.Object;
            //Ação
            Action action = () => _destinatario.Validar();

            //Verificação
            action.Should().Throw<ExcecaoCpfNaoDefinido>();
            _mockEndereco.Verify(en => en.Validar());
        }
        [Test]
        public void Destinatario_Dominio_Validar_EmpresaRazaoSocialEmBranco_EsperandoFalha()
        {
            //Cenário
            _mockEndereco.Setup(en => en.Validar());
            _destinatario = DestinatarioObjetoMae.ObterValidoEmpresa();
            _destinatario.RazaoSocial = String.Empty;
            _destinatario.Endereco = _mockEndereco.Object;
            //Ação
            Action action = () => _destinatario.Validar();

            //Verificação
            action.Should().Throw<ExcecaoRazaoSocialInvalida>();
            _mockEndereco.Verify(en => en.Validar());
        }
        [Test]
        public void Destinatario_Dominio_Validar_EmpresaComCpf_EsperandoFalha()
        {
            //Cenário
            _mockEndereco.Setup(en => en.Validar());
            _destinatario = DestinatarioObjetoMae.ObterValidoEmpresa();
            _destinatario.Cpf = CpfObjetoMae.ObterValidoComPontosTracos();
            _destinatario.Endereco = _mockEndereco.Object;
            //Ação
            Action action = () => _destinatario.Validar();

            //Verificação
            action.Should().Throw<ExcecaoEmpresaComCpf>();
            _mockEndereco.Verify(en => en.Validar());
        }
        [Test]
        public void Destinatario_Dominio_Validar_EmpresaCnpjNulo_EsperandoFalha()
        {
            //Cenário
            _mockEndereco.Setup(en => en.Validar());
            _destinatario = DestinatarioObjetoMae.ObterValidoEmpresa();
            _destinatario.Cnpj = null;
            _destinatario.Endereco = _mockEndereco.Object;
            //Ação
            Action action = () => _destinatario.Validar();

            //Verificação
            action.Should().Throw<ExcecaoCNPJInvalido>();
            _mockEndereco.Verify(en => en.Validar());
        }
        [Test]
        public void Destinatario_Dominio_Validar_EnderecoEmBranco_EsperandoFalha()
        {
            //Cenário
            _destinatario = DestinatarioObjetoMae.ObterValidoEmpresa();
            _destinatario.Endereco = null;

            //Ação
            Action action = () => _destinatario.Validar();

            //Verificação
            action.Should().Throw<ExcecaoEnderecoEmBranco>();
        }
    }
}

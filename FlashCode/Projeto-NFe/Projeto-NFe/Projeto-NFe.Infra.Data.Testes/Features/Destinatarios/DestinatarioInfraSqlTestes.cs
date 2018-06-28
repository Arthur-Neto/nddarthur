using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Comuns.Testes.Features.Base;
using Projeto_NFe.Comuns.Testes.Features.Cnpjs;
using Projeto_NFe.Comuns.Testes.Features.Cpfs;
using Projeto_NFe.Comuns.Testes.Features.Destinatarios;
using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Dominio.Features.Destinatarios;
using Projeto_NFe.Dominio.Features.Enderecos;
using Projeto_NFe.Infra.Data.Features.Destinatarios;
using Projeto_NFe.Infra.Data.Features.Enderecos;
using Projeto_NFe.Infra.Documentos.Features.Cpfs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Data.Testes.Features.Destinatarios
{
    [TestFixture]
    public class DestinatarioInfraSqlTestes
    {
        private IDestinatarioRepositorio _destinatarioRepositorio;
        private Destinatario _destinatario;

        [SetUp]
        public void Setup()
        {
            _destinatario = new Destinatario();
            _destinatarioRepositorio = new DestinatarioRepositorioSql();
        }

        [Test]
        public void Destinatario_InfraData_Inserir_Empresa_EsperadoOK()
        {
            //Cenário
            BaseSqlTeste.SemearBancoParaDestinatario();
            _destinatario = DestinatarioObjetoMae.ObterValidoEmpresa();

            //Ação
            Destinatario destinatario = _destinatarioRepositorio.Inserir(_destinatario);

            //Verificação
            destinatario.ID.Should().BeGreaterThan(0);
        }

        [Test]
        public void Destinatario_InfraData_Inserir_Pessoa_EsperadoOK()
        {
            //Cenário
            _destinatario = DestinatarioObjetoMae.ObterValidoPessoa();
            BaseSqlTeste.SemearBancoParaDestinatario();

            //Ação
            Destinatario destinatario = _destinatarioRepositorio.Inserir(_destinatario);

            //Verificação
            destinatario.ID.Should().BeGreaterThan(0);
        }

        [Test]
        public void Destinatario_InfraData_Atualizar_Pessoa_EsperadoOK()
        {
            //Cenário
            _destinatario = DestinatarioObjetoMae.ObterValidoPessoa();
            BaseSqlTeste.SemearBancoParaDestinatario();

            //Ação
            Destinatario destinatario = _destinatarioRepositorio.Atualizar(_destinatario);

            //Verificação
            destinatario.Nome.Should().Be(_destinatario.Nome);
        }

        [Test]
        public void Destinatario_InfraData_Atualizar_Empresa_EsperadoOK()
        {
            //Cenário
            BaseSqlTeste.SemearBancoParaDestinatario();
            _destinatario = DestinatarioObjetoMae.ObterValidoEmpresa();
            _destinatario.Nome = "Nome";
            //Ação
            Destinatario destinatario = _destinatarioRepositorio.Atualizar(_destinatario);

            //Verificação
            destinatario.RazaoSocial.Should().Be(_destinatario.RazaoSocial);
        }

        [Test]
        public void Destinatario_InfraData_Deletar_EsperadoOK()
        {
            //Cenário
            BaseSqlTeste.SemearBancoParaDestinatario();
            _destinatario.ID = 2;

            //Ação
            bool destinatario = _destinatarioRepositorio.Deletar(_destinatario.ID);

            //Verificação
            destinatario.Should().BeTrue();
        }

        [Test]
        public void Destinatario_InfraData_ObterPorId_EsperadoOK()
        {
            //Cenário
            BaseSqlTeste.SemearBancoParaDestinatario();
            _destinatario.ID = 2;

            //Ação
            Destinatario destinatario = _destinatarioRepositorio.ObterPorId(_destinatario.ID);

            //Verificação
            destinatario.ID.Should().Be(_destinatario.ID);
        }

        [Test]
        public void Destinatario_InfraData_ObterTodos_EsperadoOK()
        {
            BaseSqlTeste.SemearBancoParaDestinatario();

            //Ação
            List<Destinatario> listDestinatario = _destinatarioRepositorio.ObterTodos();

            //Verificação
            listDestinatario.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void Destinatario_InfraData_ObterTodos_Empresa_EsperadoOK()
        {
            //Cenario
            BaseSqlTeste.SemearBancoParaDestinatario();
            _destinatario = DestinatarioObjetoMae.ObterValidoEmpresa();
            _destinatarioRepositorio.Inserir(_destinatario);

            //Ação
            List<Destinatario> listDestinatario = _destinatarioRepositorio.ObterTodos();

            //Verificação
            listDestinatario.Count.Should().BeGreaterThan(0);
        }
        [Test]
        public void Destinatario_InfraData_ObterTodos_Pessoa_EsperadoOK()
        {
            //Cenario
            BaseSqlTeste.SemearBancoParaDestinatario();
            _destinatario = DestinatarioObjetoMae.ObterValidoPessoa();
            _destinatarioRepositorio.Inserir(_destinatario);

            //Ação
            List<Destinatario> listDestinatario = _destinatarioRepositorio.ObterTodos();

            //Verificação
            listDestinatario.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void Destinatario_InfraData_Deletar_IDZero_EsperadoFalha()
        {
            //Cenário
            _destinatario.ID = 0;

            //Ação
            Action action = () => _destinatarioRepositorio.Deletar(_destinatario.ID);

            //Verificação
            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void Destinatario_InfraData_Atualizar_EmpresaComIDZero_EsperadoFalha()
        {
            //Cenário
            _destinatario = DestinatarioObjetoMae.ObterValidoEmpresa();
            _destinatario.ID = 0;

            //Ação
            Action action = () => _destinatarioRepositorio.Atualizar(_destinatario);

            //Verificação
            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void Destinatario_InfraData_ObterPorId_IDZero_EsperadoFalha()
        {
            //Cenário
            _destinatario.ID = 0;

            //Ação
            Action action = () => _destinatarioRepositorio.ObterPorId(_destinatario.ID);

            //Verificação
            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void Destinatario_InfraData_Deletar_IDInexistente_EsperadoFalha()
        {
            //Cenário
            BaseSqlTeste.SemearBancoParaDestinatario();

            _destinatario.ID = 10;

            //Ação
            bool destinatario = _destinatarioRepositorio.Deletar(_destinatario.ID);

            //Verificação
            destinatario.Should().BeFalse();
        }

        [Test]
        public void Destinatario_InfraData_ObterPorId_IDInexistente_EsperadoFalha()
        {
            //Cenário
            BaseSqlTeste.SemearBancoParaDestinatario();
            _destinatario.ID = 10;

            //Ação
            Destinatario destinatario = _destinatarioRepositorio.ObterPorId(_destinatario.ID);

            //Verificação
            destinatario.Should().BeNull();
        }
        [Test]
        public void Destinatario_InfraData_Inserir_EmpresaComCpf_EsperadoFalha()
        {
            //Cenário
            _destinatario = DestinatarioObjetoMae.ObterValidoEmpresa();
            _destinatario.Cpf = CpfObjetoMae.ObterValidoComPontosTracos();

            //Ação
            Action action = () => _destinatarioRepositorio.Inserir(_destinatario);

            //Verificação
            action.Should().Throw<ExcecaoEmpresaComCpf>();
        }
        [Test]
        public void Destinatario_InfraData_Inserir_EmpresaComCnpjNulo_EsperadoFalha()
        {
            //Cenário
            _destinatario = DestinatarioObjetoMae.ObterValidoEmpresa();
            _destinatario.Cnpj = null;

            //Ação
            Action action = () => _destinatarioRepositorio.Inserir(_destinatario);

            //Verificação
            action.Should().Throw<ExcecaoCNPJInvalido>();
        }
        [Test]
        public void Destinatario_InfraData_Inserir_EmpresaComRazaoSocialInvalida_EsperadoFalha()
        {
            //Cenário
            _destinatario = DestinatarioObjetoMae.ObterValidoEmpresa();
            _destinatario.RazaoSocial = String.Empty;

            //Ação
            Action action = () => _destinatarioRepositorio.Inserir(_destinatario);

            //Verificação
            action.Should().Throw<ExcecaoRazaoSocialInvalida>();
        }

        [Test]
        public void Destinatario_InfraData_Inserir_PessoaComNomeInvalido_EsperadoFalha()
        {
            //Cenário
            _destinatario = DestinatarioObjetoMae.ObterValidoPessoa();
            _destinatario.Nome = String.Empty;

            //Ação
            Action action = () => _destinatarioRepositorio.Inserir(_destinatario);

            //Verificação
            action.Should().Throw<ExcecaoNomeEmBranco>();
        }
        [Test]
        public void Destinatario_InfraData_Inserir_PessoaComCpfNulo_EsperadoFalha()
        {
            //Cenário
            _destinatario = DestinatarioObjetoMae.ObterValidoPessoa();
            _destinatario.Cpf = null;

            //Ação
            Action action = () => _destinatarioRepositorio.Inserir(_destinatario);

            //Verificação
            action.Should().Throw<ExcecaoCpfNaoDefinido>();
        }
        [Test]
        public void Destinatario_InfraData_Inserir_PessoaComRazaoSocial_EsperadoFalha()
        {
            //Cenário
            _destinatario = DestinatarioObjetoMae.ObterValidoPessoa();
            _destinatario.RazaoSocial = "RazaoSocial";

            //Ação
            Action action = () => _destinatarioRepositorio.Inserir(_destinatario);

            //Verificação
            action.Should().Throw<ExcecaoPessoaComRazaoSocial>();
        }
        [Test]
        public void Destinatario_InfraData_Inserir_PessoaComEnderecoInvalido_EsperadoFalha()
        {
            //Cenário
            _destinatario = DestinatarioObjetoMae.ObterValidoPessoa();
            _destinatario.Endereco = null;

            //Ação
            Action action = () => _destinatarioRepositorio.Inserir(_destinatario);

            //Verificação
            action.Should().Throw<ExcecaoEnderecoEmBranco>();
        }

        [Test]
        public void Destinatario_InfraData_Inserir_EmpresaComEnderecoInvalido_EsperadoFalha()
        {
            //Cenário
            _destinatario = DestinatarioObjetoMae.ObterValidoEmpresa();
            _destinatario.Endereco = null;

            //Ação
            Action action = () => _destinatarioRepositorio.Inserir(_destinatario);

            //Verificação
            action.Should().Throw<ExcecaoEnderecoEmBranco>();
        }

        [Test]
        public void Destinatario_InfraData_Inserir_PessoaComCpfInvalido_EsperadoFalha()
        {
            //Cenário
            _destinatario = DestinatarioObjetoMae.ObterValidoPessoa();
            _destinatario.Cpf = CpfObjetoMae.ObterPrimeiroDigitoInvalido();

            //Ação
            Action action = () => _destinatarioRepositorio.Inserir(_destinatario);

            //Verificação
            action.Should().Throw<ExcecaoCPFInvalido>();
        }

        [Test]
        public void Destinatario_InfraData_Inserir_PessoaComCnpj_EsperadoFalha()
        {
            //Cenário
            _destinatario = DestinatarioObjetoMae.ObterValidoPessoa();
            _destinatario.Cnpj = CnpjObjetoMae.ObterValidoComPontosTracos();

            //Ação
            Action action = () => _destinatarioRepositorio.Inserir(_destinatario);

            //Verificação
            action.Should().Throw<ExcecaoPessoaComCnpj>();
        }

        [Test]
        public void Destinatario_InfraData_Inserir_EmpresaComCnpjInvalido_EsperadoFalha()
        {
            //Cenário
            _destinatario = DestinatarioObjetoMae.ObterValidoEmpresa();
            _destinatario.Cnpj = CnpjObjetoMae.ObterPrimeiroDigitoInvalido();

            //Ação
            Action action = () => _destinatarioRepositorio.Inserir(_destinatario);

            //Verificação
            action.Should().Throw<ExcecaoCNPJInvalido>();
        }

        [Test]
        public void Teste_InfraData_Destinatario_ObterPorEnderecoID_EsperadoOK()
        {
            _destinatario.ID = 1;

            var destinatario = _destinatarioRepositorio.ObterPorEnderecoID(_destinatario.ID);

            destinatario.ID.Should().Be(_destinatario.ID);
        }

        [Test]
        public void Teste_InfraData_Destinatario_ObterPorEnderecoID_IDInvalido_EsperadoNulo()
        {
            _destinatario.ID = 1234;

            var destinatario = _destinatarioRepositorio.ObterPorEnderecoID(_destinatario.ID);

            destinatario.Should().BeNull();
        }
    }
}

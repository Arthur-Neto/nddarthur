using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Comuns.Testes.Features.Base;
using Projeto_NFe.Comuns.Testes.Features.Cnpjs;
using Projeto_NFe.Comuns.Testes.Features.Cpfs;
using Projeto_NFe.Comuns.Testes.Features.Transportadores;
using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Dominio.Features.Transportadores;
using Projeto_NFe.Infra.Data.Features.Transportadores;
using Projeto_NFe.Infra.Documentos.Features.Cpfs;
using System;
using System.Collections.Generic;

namespace Projeto_NFe.Infra.Data.Testes.Features.Transportadores
{
    [TestFixture]
    public class TransportadorInfraSqlTestes
    {
        private ITransportadorRepositorio _transportadorRepositorio;
        private Transportador _transportador;

        [SetUp]
        public void Setup()
        {
            _transportador = new Transportador();
            _transportadorRepositorio = new TransportadorRepositorioSql();
        }

        [Test]
        public void Transportador_InfraData_Inserir_Empresa_EsperadoOK()
        {
            //Cenário
            BaseSqlTeste.SemearBancoParaTransportador();
            _transportador = TransportadorObjetoMae.ObterValidoEmpresa();

            //Ação
            Transportador transportador = _transportadorRepositorio.Inserir(_transportador);

            //Verificação
            transportador.ID.Should().BeGreaterThan(0);
        }

        [Test]
        public void Transportador_InfraData_Inserir_Pessoa_EsperadoOK()
        {
            //Cenário
            BaseSqlTeste.SemearBancoParaTransportador();
            _transportador = TransportadorObjetoMae.ObterValidoPessoa();

            //Ação
            Transportador transportador = _transportadorRepositorio.Inserir(_transportador);

            //Verificação
            transportador.ID.Should().BeGreaterThan(0);
        }

        [Test]
        public void Transportador_InfraData_ObterPorId_EsperadoOK()
        {
            //Cenário
            BaseSqlTeste.SemearBancoParaTransportador();
            _transportador.ID = 1;

            //Ação
            Transportador transportador = _transportadorRepositorio.ObterPorId(_transportador.ID);

            //Verificação
            transportador.ID.Should().Be(_transportador.ID);
        }

        [Test]
        public void Transportador_InfraData_ObterTodos_EsperadoOK()
        {
            //Ação
            List<Transportador> listTransportador = _transportadorRepositorio.ObterTodos();

            //Verificação
            listTransportador.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void Transportador_InfraData_ObterTodos_Empresa_EsperadoOK()
        {
            //Cenario
            _transportador = TransportadorObjetoMae.ObterValidoEmpresa();
            _transportadorRepositorio.Inserir(_transportador);

            //Ação
            List<Transportador> listTransportador = _transportadorRepositorio.ObterTodos();

            //Verificação
            listTransportador.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void Transportador_InfraData_ObterTodos_Pessoa_EsperadoOK()
        {
            //Cenario
            _transportador = TransportadorObjetoMae.ObterValidoPessoa();
            _transportadorRepositorio.Inserir(_transportador);

            //Ação
            List<Transportador> listTransportador = _transportadorRepositorio.ObterTodos();

            //Verificação
            listTransportador.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void Transportador_InfraData_Atualizar_Pessoa_EsperadoOK()
        {
            //Cenário
            BaseSqlTeste.SemearBancoParaTransportador();
            _transportador = TransportadorObjetoMae.ObterValidoPessoa();

            //Ação
            Transportador transportador = _transportadorRepositorio.Atualizar(_transportador);

            //Verificação
            transportador.Nome.Should().Be(_transportador.Nome);
        }

        [Test]
        public void Transportador_InfraData_Atualizar_Empresa_EsperadoOK()
        {
            //Cenário
            BaseSqlTeste.SemearBancoParaTransportador();
            _transportador = TransportadorObjetoMae.ObterValidoEmpresa();

            //Ação
            Transportador transportador = _transportadorRepositorio.Atualizar(_transportador);

            //Verificação
            transportador.Nome.Should().Be(_transportador.Nome);
        }

        [Test]
        public void Transportador_InfraData_Deletar_EsperadoOK()
        {
            //Cenário
            BaseSqlTeste.SemearBancoParaTransportador();
            _transportador.ID = 2;

            //Ação
            bool transportador = _transportadorRepositorio.Deletar(_transportador.ID);

            //Verificação
            transportador.Should().BeTrue();
        }

        [Test]
        public void Transportador_InfraData_Deletar_IDZero_EsperadoFalha()
        {
            //Cenário
            _transportador.ID = 0;

            //Ação
            Action action = () => _transportadorRepositorio.Deletar(_transportador.ID);

            //Verificação
            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void Transportador_InfraData_Atualizar_IDZero_EsperadoFalha()
        {
            //Cenário
            _transportador = TransportadorObjetoMae.ObterValidoEmpresa();
            _transportador.ID = 0;

            //Ação
            Action action = () => _transportadorRepositorio.Atualizar(_transportador);

            //Verificação
            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void Transportador_InfraData_ObterPorId_IDZero_EsperadoFalha()
        {
            //Cenário
            _transportador.ID = 0;

            //Ação
            Action action = () => _transportadorRepositorio.ObterPorId(_transportador.ID);

            //Verificação
            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void Transportador_InfraData_Deletar_IDInexistente_EsperadoFalha()
        {
            //Cenário
            BaseSqlTeste.SemearBancoParaTransportador();
            _transportador.ID = 10;

            //Ação
            bool transportador = _transportadorRepositorio.Deletar(_transportador.ID);

            //Verificação
            transportador.Should().BeFalse();
        }

        [Test]
        public void Transportador_InfraData_ObterPorId_IDInexistente_EsperadoFalha()
        {
            //Cenário
            BaseSqlTeste.SemearBancoParaTransportador();
            _transportador.ID = 10;

            //Ação
            Transportador transportador = _transportadorRepositorio.ObterPorId(_transportador.ID);

            //Verificação
            transportador.Should().BeNull();
        }

        [Test]
        public void Transportador_InfraData_Inserir_Empresa_ComRazaoSocialInvalida_EsperandoFalha()
        {
            //Cenário
            _transportador = TransportadorObjetoMae.ObterValidoEmpresa();
            _transportador.RazaoSocial = String.Empty;

            //Ação
            Action action = () => _transportadorRepositorio.Inserir(_transportador);

            //Verificação
            action.Should().Throw<ExcecaoRazaoSocialInvalida>();
        }

        [Test]
        public void Transportador_InfraData_Inserir_Pessoa_ComNomeInvalido_EsperandoFalha()
        {
            //Cenário
            _transportador = TransportadorObjetoMae.ObterValidoPessoa();
            _transportador.Nome = String.Empty;

            //Ação
            Action action = () => _transportadorRepositorio.Inserir(_transportador);

            //Verificação
            action.Should().Throw<ExcecaoNomeEmBranco>();
        }

        [Test]
        public void Transportador_InfraData_Inserir_Pessoa_EnderecoInvalido_EsperandoFalha()
        {
            //Cenário
            _transportador = TransportadorObjetoMae.ObterValidoPessoa();
            _transportador.Endereco = null;

            //Ação
            Action action = () => _transportadorRepositorio.Inserir(_transportador);

            //Verificação
            action.Should().Throw<ExcecaoEnderecoEmBranco>();
        }

        [Test]
        public void Transportador_InfraData_Inserir_Empresa_EnderecoInvalido_EsperandoFalha()
        {
            //Cenário
            _transportador = TransportadorObjetoMae.ObterValidoEmpresa();
            _transportador.Endereco = null;

            //Ação
            Action action = () => _transportadorRepositorio.Inserir(_transportador);

            //Verificação
            action.Should().Throw<ExcecaoEnderecoEmBranco>();
        }

        [Test]
        public void Transportador_InfraData_Inserir_Pessoa_CpfInvalido_EsperandoFalha()
        {
            //Cenário
            _transportador = TransportadorObjetoMae.ObterValidoPessoa();
            _transportador.Cpf = CpfObjetoMae.ObterPrimeiroDigitoInvalido();

            //Ação
            Action action = () => _transportadorRepositorio.Inserir(_transportador);

            //Verificação
            action.Should().Throw<ExcecaoCPFInvalido>();
        }

        [Test]
        public void Transportador_InfraData_Inserir_Empresa_CnpjInvalido_EsperandoFalha()
        {
            //Cenário
            _transportador = TransportadorObjetoMae.ObterValidoEmpresa();
            _transportador.Cnpj = CnpjObjetoMae.ObterSegundoDigitoInvalido();

            //Ação
            Action action = () => _transportadorRepositorio.Inserir(_transportador);

            //Verificação
            action.Should().Throw<ExcecaoCNPJInvalido>();
        }


        [Test]
        public void Transportador_InfraData_Inserir_Empresa_ComCpf_EsperadoFalha()
        {
            _transportador = TransportadorObjetoMae.ObterValidoEmpresa();
            _transportador.Cpf = CpfObjetoMae.ObterValidoSemPontosTracos();

            Action action = () => _transportadorRepositorio.Inserir(_transportador);
            
            action.Should().Throw<ExcecaoEmpresaComCpf>();
        }
        [Test]
        public void Transportador_InfraData_Inserir_Empresa_ComCnpjNulo_EsperadoFalha()
        {
            _transportador = TransportadorObjetoMae.ObterValidoEmpresa();
            _transportador.Cnpj = null;

            Action action = () => _transportadorRepositorio.Inserir(_transportador);

            action.Should().Throw<ExcecaoCNPJInvalido>();
        }
        [Test]
        public void Transportador_InfraData_Inserir_Pessoa_ComCpfNulo_EsperadoFalha()
        {
            _transportador = TransportadorObjetoMae.ObterValidoPessoa();
            _transportador.Cpf = null;

            Action action = () => _transportadorRepositorio.Inserir(_transportador);

            action.Should().Throw<ExcecaoCpfNaoDefinido>();
        }
        [Test]
        public void Transportador_InfraData_Inserir_Pessoa_ComCnpj_EsperadoFalha()
        {
            _transportador = TransportadorObjetoMae.ObterValidoPessoa();
            _transportador.Cnpj = CnpjObjetoMae.ObterValidoComPontosTracos();

            Action action = () => _transportadorRepositorio.Inserir(_transportador);

            action.Should().Throw<ExcecaoPessoaComCnpj>();
        }
        [Test]
        public void Transportador_InfraData_Inserir_Pessoa_ComRazaoSocial_EsperadoFalha()
        {
            _transportador = TransportadorObjetoMae.ObterValidoPessoa();
            _transportador.RazaoSocial = "RazaoSocial";

            Action action = () => _transportadorRepositorio.Inserir(_transportador);

            action.Should().Throw<ExcecaoPessoaComRazaoSocial>();
        }
        [Test]
        public void Transportador_InfraData_Inserir_ComEnderecoNulo_EsperadoFalha()
        {
            _transportador = TransportadorObjetoMae.ObterValidoPessoa();
            _transportador.Endereco = null;
            Action action = () => _transportadorRepositorio.Inserir(_transportador);

            action.Should().Throw<ExcecaoEnderecoEmBranco>();
        }

        [Test]
        public void Teste_InfraData_Transportador_ObterPorEnderecoID_EsperadoOK()
        {
            _transportador.ID = 1;

            var trasnportador = _transportadorRepositorio.ObterPorEnderecoID(_transportador.ID);

            trasnportador.ID.Should().Be(_transportador.ID);
        }

        [Test]
        public void Teste_InfraData_Transportador_ObterPorEnderecoID_IDInvalido_EsperadoNulo()
        {
            _transportador.ID = 1234;

            var tranportador = _transportadorRepositorio.ObterPorEnderecoID(_transportador.ID);

            tranportador.Should().BeNull();
        }
    }
}

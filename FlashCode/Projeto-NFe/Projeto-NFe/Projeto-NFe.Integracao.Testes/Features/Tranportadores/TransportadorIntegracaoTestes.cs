using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Aplicacao.Features.Transportadores;
using Projeto_NFe.Comuns.Testes.Features.Base;
using Projeto_NFe.Comuns.Testes.Features.Transportadores;
using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Dominio.Features.Enderecos;
using Projeto_NFe.Dominio.Features.NotasFiscais;
using Projeto_NFe.Dominio.Features.Transportadores;
using Projeto_NFe.Infra.Data.Features.Enderecos;
using Projeto_NFe.Infra.Data.Features.NotasFiscais;
using Projeto_NFe.Infra.Data.Features.Transportadores;
using Projeto_NFe.Infra.Documentos.Features.Cnpjs;
using Projeto_NFe.Infra.Documentos.Features.Cpfs;
using System;
using System.Linq;

namespace Projeto_NFe.Integracao.Testes.Features.Tranportadores
{
    [TestFixture]
    class TransportadorIntegracaoTestes
    {

        private IEnderecoRepositorio _enderecoRepositorio;
        private INotaFiscalRepositorio _notaFiscalRepositorio;
        private ITransportadorRepositorio _transportadorRepositorio;
        private ITransportadorServico _transportadorServico;
        private Transportador _transportador;

        [SetUp]
        public void SetUp()
        {
            _transportador = new Transportador();
            _enderecoRepositorio = new EnderecoRepositorioSql();
            _notaFiscalRepositorio = new NotaFiscalRepositorioSql();
            _transportadorRepositorio = new TransportadorRepositorioSql();
            _transportadorServico = new TransportadorServico(_transportadorRepositorio, _notaFiscalRepositorio, _enderecoRepositorio);
            BaseSqlTeste.SemearBancoParaTransportador();
        }

        [Test]
        public void Transportador_Integracao_Inserir_EsperadoOK()
        {
            _transportador = TransportadorObjetoMae.ObterValidoPessoa();

            _transportador = _transportadorServico.Inserir(_transportador);

            var inserido = _transportadorServico.ObterPorId(_transportador.ID);

            inserido.ID.Should().Be(_transportador.ID);
        }

        [Test]
        public void Transportador_Integracao_Atualizar_EsperadoOK()
        {
            _transportador = TransportadorObjetoMae.ObterValidoPessoa();

            _transportador = _transportadorServico.Atualizar(_transportador);

            var inserido = _transportadorServico.ObterPorId(_transportador.ID);

            inserido.ID.Should().Be(_transportador.ID);
        }

        [Test]
        public void Transportador_Integracao_Inserir_EnderecoNulo_EsperadoFalha()
        {
            _transportador = TransportadorObjetoMae.ObterValidoPessoa();
            _transportador.Endereco = null;

            Action action = () => _transportadorServico.Inserir(_transportador);

            action.Should().Throw<ExcecaoEnderecoEmBranco>();
        }

        [Test]
        public void Transportador_Integracao_Atualizar_EnderecoNulo_EsperadoFalha()
        {
            _transportador = TransportadorObjetoMae.ObterValidoPessoa();
            _transportador.Endereco = null;

            Action action = () => _transportadorServico.Atualizar(_transportador);

            action.Should().Throw<ExcecaoEnderecoEmBranco>();
        }

        [Test]
        public void Transportador_Integracao_Inserir_RazaoSocialInvalida_EsperadoFalha()
        {
            _transportador = TransportadorObjetoMae.ObterValidoEmpresa();
            _transportador.RazaoSocial = string.Empty;

            Action action = () => _transportadorServico.Inserir(_transportador);

            action.Should().Throw<ExcecaoRazaoSocialInvalida>();
        }

        [Test]
        public void Transportador_Integracao_Atualizar_RazaoSocialInvalida_EsperadoFalha()
        {
            _transportador = TransportadorObjetoMae.ObterValidoEmpresa();
            _transportador.RazaoSocial = string.Empty;

            Action action = () => _transportadorServico.Atualizar(_transportador);

            action.Should().Throw<ExcecaoRazaoSocialInvalida>();
        }

        [Test]
        public void Transportador_Integracao_Inserir_EmpresaComCpf_EsperadoFalha()
        {
            _transportador = TransportadorObjetoMae.ObterValidoEmpresa();
            _transportador.Cpf = new Cpf();

            Action action = () => _transportadorServico.Inserir(_transportador);

            action.Should().Throw<ExcecaoEmpresaComCpf>();
        }

        [Test]
        public void Transportador_Integracao_Atualizar_EmpresaComCpf_EsperadoFalha()
        {
            _transportador = TransportadorObjetoMae.ObterValidoEmpresa();
            _transportador.Cpf = new Cpf();

            Action action = () => _transportadorServico.Atualizar(_transportador);

            action.Should().Throw<ExcecaoEmpresaComCpf>();
        }

        [Test]
        public void Transportador_Integracao_Inserir_CnpjInvalido_EsperadoFalha()
        {
            _transportador = TransportadorObjetoMae.ObterValidoEmpresa();
            _transportador.Cnpj = new Cnpj();

            Action action = () => _transportadorServico.Inserir(_transportador);

            action.Should().Throw<ExcecaoCNPJInvalido>();
        }

        [Test]
        public void Transportador_Integracao_Atualizar_CnpjInvalido_EsperadoFalha()
        {
            _transportador = TransportadorObjetoMae.ObterValidoEmpresa();
            _transportador.Cnpj = new Cnpj();

            Action action = () => _transportadorServico.Atualizar(_transportador);

            action.Should().Throw<ExcecaoCNPJInvalido>();
        }

        [Test]
        public void Transportador_Integracao_Inserir_NomeEmBranco_EsperadoFalha()
        {
            _transportador = TransportadorObjetoMae.ObterValidoPessoa();
            _transportador.Nome = string.Empty;

            Action action = () => _transportadorServico.Inserir(_transportador);

            action.Should().Throw<ExcecaoNomeEmBranco>();
        }

        [Test]
        public void Transportador_Integracao_Atualizar_NomeEmBranco_EsperadoFalha()
        {
            _transportador = TransportadorObjetoMae.ObterValidoPessoa();
            _transportador.Nome = string.Empty;

            Action action = () => _transportadorServico.Atualizar(_transportador);

            action.Should().Throw<ExcecaoNomeEmBranco>();
        }


        [Test]
        public void Transportador_Integracao_Inserir_CpfEmBranco_EsperadoFalha()
        {
            _transportador = TransportadorObjetoMae.ObterValidoPessoa();
            _transportador.Cpf = new Cpf();

            Action action = () => _transportadorServico.Inserir(_transportador);

            action.Should().Throw<ExcecaoCPFInvalido>();
        }

        [Test]
        public void Transportador_Integracao_Atualizar_CpfEmBranco_EsperadoFalha()
        {
            _transportador = TransportadorObjetoMae.ObterValidoPessoa();
            _transportador.Cpf = new Cpf();

            Action action = () => _transportadorServico.Atualizar(_transportador);

            action.Should().Throw<ExcecaoCPFInvalido>();
        }

        [Test]
        public void Transportador_Integracao_Inserir_PessoaComCnpj_EsperadoFalha()
        {
            _transportador = TransportadorObjetoMae.ObterValidoPessoa();
            _transportador.Cnpj = new Cnpj();

            Action action = () => _transportadorServico.Inserir(_transportador);

            action.Should().Throw<ExcecaoPessoaComCnpj>();
        }

        [Test]
        public void Transportador_Integracao_Atualizar_PessoaComCnpj_EsperadoFalha()
        {
            _transportador = TransportadorObjetoMae.ObterValidoPessoa();
            _transportador.Cnpj = new Cnpj();

            Action action = () => _transportadorServico.Atualizar(_transportador);

            action.Should().Throw<ExcecaoPessoaComCnpj>();
        }

        [Test]
        public void Transportador_Integracao_Inserir_PessoaComRazaoSocial_EsperadoFalha()
        {
            _transportador = TransportadorObjetoMae.ObterValidoPessoa();
            _transportador.Cnpj = new Cnpj();

            Action action = () => _transportadorServico.Inserir(_transportador);

            action.Should().Throw<ExcecaoPessoaComCnpj>();
        }

        [Test]
        public void Transportador_Integracao_Atualizar_PessoaComRazaoSocial_EsperadoFalha()
        {
            _transportador = TransportadorObjetoMae.ObterValidoPessoa();
            _transportador.Cnpj = new Cnpj();

            Action action = () => _transportadorServico.Atualizar(_transportador);

            action.Should().Throw<ExcecaoPessoaComCnpj>();
        }

        [Test]
        public void Transportador_Integracao_Atualizar_IDZero_EsperadoFalha()
        {
            _transportador.ID = 0;

            Action action = () => _transportadorServico.Atualizar(_transportador);

            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void Transportador_Integracao_Deletar_IDZero_EsperadoFalha()
        {
            _transportador.ID = 0;

            Action action = () => _transportadorServico.Deletar(_transportador.ID);

            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void Transportador_Integracao_ObterPorID_IDZero_EsperadoFalha()
        {
            _transportador.ID = 0;

            Action action = () => _transportadorServico.ObterPorId(_transportador.ID);

            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void Transportador_Integracao_ObterPorID_IDInvalido_EsperadoFalha()
        {
            _transportador.ID = 1234;

           var tranportador =  _transportadorServico.ObterPorId(_transportador.ID);

            tranportador.Should().BeNull();
        }

        [Test]
        public void Transportador_Integracao_ObterPorTodos_EsperadoFalha()
        {
            var id = 1;

            var ListaTranportador = _transportadorServico.ObterTodos();

            ListaTranportador.First().ID.Should().Be(id);
        }


        [Test]
        public void Transportador_Integracao_Deletar_EsperadoOk()
        {
            _transportador = TransportadorObjetoMae.ObterValidoPessoa();

            _transportador = _transportadorServico.Inserir(_transportador);

            var deletado = _transportadorServico.Deletar(_transportador.ID);

            var buscar = _transportadorServico.ObterPorId(_transportador.ID);

            buscar.Should().BeNull();
            deletado.Should().BeTrue();
        }

        [Test]
        public void Transportador_Integracao_Deletar_IDInvalido_EsperadoFalso()
        {
            _transportador.ID = 223456;

            var deletado = _transportadorServico.Deletar(_transportador.ID);

            deletado.Should().BeFalse();
        }

        [Test]
        public void Transportador_Integracao_Deletar_ChaveEstangeira_EsperadoFalha()
        {
            _transportador.ID = 1;

            Action action = () => _transportadorServico.Deletar(_transportador.ID);

            action.Should().Throw<ExcecaoChaveEstrangeira>();
        }

    }
}

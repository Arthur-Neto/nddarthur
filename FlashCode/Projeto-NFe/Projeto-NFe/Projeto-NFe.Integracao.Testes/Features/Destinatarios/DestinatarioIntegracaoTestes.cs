using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Aplicacao.Features.Destinatarios;
using Projeto_NFe.Comuns.Testes.Features.Base;
using Projeto_NFe.Comuns.Testes.Features.Destinatarios;
using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Dominio.Features.Destinatarios;
using Projeto_NFe.Dominio.Features.Enderecos;
using Projeto_NFe.Dominio.Features.NotasFiscais;
using Projeto_NFe.Infra.Data.Features.Destinatarios;
using Projeto_NFe.Infra.Data.Features.Enderecos;
using Projeto_NFe.Infra.Data.Features.NotasFiscais;
using Projeto_NFe.Infra.Documentos.Features.Cnpjs;
using Projeto_NFe.Infra.Documentos.Features.Cpfs;
using System;
using System.Linq;

namespace Projeto_NFe.Integracao.Testes.Features.Destinatarios
{
    [TestFixture]
    public class DestinatarioIntegracaoTestes
    {
        private IEnderecoRepositorio _enderecoRepositorio;
        private IDestinatarioRepositorio _destinatarioRepositorio;
        private INotaFiscalRepositorio _notaFiscalRepositorio;
        private Destinatario _destinatario;
        private IDestinatarioServico _destinatarioServico;

        [SetUp]
        public void SetUp()
        {
            _destinatario = new Destinatario();
            _enderecoRepositorio = new EnderecoRepositorioSql();
            _notaFiscalRepositorio = new NotaFiscalRepositorioSql();
            _destinatarioRepositorio = new DestinatarioRepositorioSql();
            _destinatarioServico = new DestinatarioServico(_destinatarioRepositorio, _notaFiscalRepositorio, _enderecoRepositorio);

            BaseSqlTeste.SemearBancoParaDestinatario();
        }

        [Test]
        public void Destinatario_Integracao_Inserir_Empresa_EsperadoOK()
        {
            _destinatario = DestinatarioObjetoMae.ObterValidoEmpresa();

            var destinatario = _destinatarioServico.Inserir(_destinatario);

            var destinatarioInserido = _destinatarioServico.ObterPorId(destinatario.ID);

            destinatarioInserido.Should().NotBeNull();
            destinatario.ID.Should().Be(destinatarioInserido.ID);
        }

        [Test]
        public void Destinatario_Integracao_Inserir_Pessoa_EsperadoOK()
        {
            _destinatario = DestinatarioObjetoMae.ObterValidoPessoa();

            var destinatario = _destinatarioServico.Inserir(_destinatario);

            var destinatarioInserido = _destinatarioServico.ObterPorId(destinatario.ID);

            destinatarioInserido.Should().NotBeNull();
            destinatario.ID.Should().Be(destinatarioInserido.ID);
        }

        [Test]
        public void Destinatario_Integracao_Inserir_EnderecoNulo_EsperadoFalha()
        {
            _destinatario = DestinatarioObjetoMae.ObterValidoPessoa();
            _destinatario.Endereco = null;

            Action action = () => _destinatarioServico.Inserir(_destinatario);

            action.Should().Throw<ExcecaoEnderecoEmBranco>();
        }

        [Test]
        public void Destinatario_Integracao_Inserir_RazaoSocialVazia_EsperadoFalha()
        {
            _destinatario = DestinatarioObjetoMae.ObterValidoEmpresa();
            _destinatario.RazaoSocial = String.Empty;

            Action action = () => _destinatarioServico.Inserir(_destinatario);

            action.Should().Throw<ExcecaoRazaoSocialInvalida>();
        }

        [Test]
        public void Destinatario_Integracao_Inserir_ComCpf_EsperadoFalha()
        {
            _destinatario = DestinatarioObjetoMae.ObterValidoEmpresa();
            _destinatario.Cpf = new Cpf();

            Action action = () => _destinatarioServico.Inserir(_destinatario);

            action.Should().Throw<ExcecaoEmpresaComCpf>();
        }

        [Test]
        public void Destinatario_Integracao_Inserir_CnpjNulo_EsperadoFalha()
        {
            _destinatario = DestinatarioObjetoMae.ObterValidoEmpresa();
            _destinatario.Cnpj = null;

            Action action = () => _destinatarioServico.Inserir(_destinatario);

            action.Should().Throw<ExcecaoCNPJInvalido>();
        }

        [Test]
        public void Destinatario_Integracao_Inserir_NomeVazio_EsperadoFalha()
        {
            _destinatario = DestinatarioObjetoMae.ObterValidoPessoa();
            _destinatario.Nome = String.Empty;

            Action action = () => _destinatarioServico.Inserir(_destinatario);

            action.Should().Throw<ExcecaoNomeEmBranco>();
        }

        [Test]
        public void Destinatario_Integracao_Inserir_CpfNulo_EsperadoFalha()
        {
            _destinatario = DestinatarioObjetoMae.ObterValidoPessoa();
            _destinatario.Cpf = null;

            Action action = () => _destinatarioServico.Inserir(_destinatario);

            action.Should().Throw<ExcecaoCpfNaoDefinido>();
        }

        [Test]
        public void Destinatario_Integracao_Inserir_ComCNPJ_EsperadoFalha()
        {
            _destinatario = DestinatarioObjetoMae.ObterValidoPessoa();
            _destinatario.Cnpj = new Cnpj();

            Action action = () => _destinatarioServico.Inserir(_destinatario);

            action.Should().Throw<ExcecaoPessoaComCnpj>();
        }

        [Test]
        public void Destinatario_Integracao_Inserir_ComRazaoSocial_EsperadoFalha()
        {
            _destinatario = DestinatarioObjetoMae.ObterValidoPessoa();
            _destinatario.RazaoSocial = "razao social";

            Action action = () => _destinatarioServico.Inserir(_destinatario);

            action.Should().Throw<ExcecaoPessoaComRazaoSocial>();
        }

        [Test]
        public void Destinatario_Integracao_ObterPorId_EsperadoOK()
        {
            _destinatario = DestinatarioObjetoMae.ObterValidoEmpresa();

            var destinatario = _destinatarioServico.ObterPorId(_destinatario.ID);

            destinatario.Should().NotBeNull();
            destinatario.ID.Should().Be(_destinatario.ID);
        }

        [Test]
        public void Destinatario_Integracao_ObterPorId_IdInvalido_EsperadoFalha()
        {
            _destinatario.ID = -1;

            Action action = () => _destinatarioServico.ObterPorId(_destinatario.ID);

            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void Destinatario_Integracao_ObterPorId_DestinatarioNulo_EsperadoFalha()
        {
            _destinatario.ID = 111;

            var destinatario = _destinatarioServico.ObterPorId(_destinatario.ID);

            destinatario.Should().BeNull();
        }

        [Test]
        public void Destinatario_Integracao_ObterTodos_EsperadoOK()
        {
            var id = 1;
            var destinatarios = _destinatarioServico.ObterTodos();

            destinatarios.Should().NotBeNull();
            destinatarios.First().ID.Should().Be(id);
        }

        [Test]
        public void Destinatario_Integracao_Deletar_EsperadoOK()
        {
            _destinatario = DestinatarioObjetoMae.ObterValidoEmpresa();
            var destinatario = _destinatarioServico.Inserir(_destinatario);

            var resultado = _destinatarioServico.Deletar(destinatario.ID);

            destinatario = _destinatarioServico.ObterPorId(destinatario.ID);

            destinatario.Should().BeNull();
            resultado.Should().BeTrue();
        }

        [Test]
        public void Destinatario_Integracao_Deletar_IdInvalido_EsperadoFalha()
        {
            _destinatario.ID = -1;

            Action action = () => _destinatarioServico.Deletar(_destinatario.ID);

            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void Destinatario_Integracao_Deletar_IdInvalido_EsperadoFalso()
        {
            _destinatario.ID = 12345671;

            var resultado = _destinatarioServico.Deletar(_destinatario.ID);

            resultado.Should().BeFalse();
        }


        [Test]
        public void Destinatario_Integracao_Deletar_ChaveEstrangeira_EsperadoFalha()
        {
            _destinatario.ID = 1;

            Action action = () => _destinatarioServico.Deletar(_destinatario.ID);

            action.Should().Throw<ExcecaoChaveEstrangeira>();
        }

        [Test]
        public void Destinatario_Integracao_Atualizar_EsperadoOK()
        {
            _destinatario = DestinatarioObjetoMae.ObterValidoEmpresa();

            _destinatario = _destinatarioServico.Atualizar(_destinatario);

            var destinatarioAtualizado = _destinatarioServico.ObterPorId(_destinatario.ID);

            destinatarioAtualizado.ID.Should().Be(_destinatario.ID);
        }

        [Test]
        public void Destinatario_Integracao_Atualizar_EsperadoFalha()
        {
            _destinatario.ID = -1;

            Action action = () => _destinatarioServico.Atualizar(_destinatario);

            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void Destinatario_Integracao_Atualizar_EnderecoNulo_EsperadoFalha()
        {
            _destinatario = DestinatarioObjetoMae.ObterValidoPessoa();
            _destinatario.Endereco = null;

            Action action = () => _destinatarioServico.Atualizar(_destinatario);

            action.Should().Throw<ExcecaoEnderecoEmBranco>();
        }

        [Test]
        public void Destinatario_Integracao_Atualizar_RazaoSocialVazia_EsperadoFalha()
        {
            _destinatario = DestinatarioObjetoMae.ObterValidoEmpresa();
            _destinatario.RazaoSocial = String.Empty;

            Action action = () => _destinatarioServico.Atualizar(_destinatario);

            action.Should().Throw<ExcecaoRazaoSocialInvalida>();
        }

        [Test]
        public void Destinatario_Integracao_Atualizar_ComCpf_EsperadoFalha()
        {
            _destinatario = DestinatarioObjetoMae.ObterValidoEmpresa();
            _destinatario.Cpf = new Cpf();

            Action action = () => _destinatarioServico.Atualizar(_destinatario);

            action.Should().Throw<ExcecaoEmpresaComCpf>();
        }

        [Test]
        public void Destinatario_Integracao_Atualizar_CnpjNulo_EsperadoFalha()
        {
            _destinatario = DestinatarioObjetoMae.ObterValidoEmpresa();
            _destinatario.Cnpj = null;

            Action action = () => _destinatarioServico.Atualizar(_destinatario);

            action.Should().Throw<ExcecaoCNPJInvalido>();
        }

        [Test]
        public void Destinatario_Integracao_Atualizar_NomeVazio_EsperadoFalha()
        {
            _destinatario = DestinatarioObjetoMae.ObterValidoPessoa();
            _destinatario.Nome = String.Empty;

            Action action = () => _destinatarioServico.Atualizar(_destinatario);

            action.Should().Throw<ExcecaoNomeEmBranco>();
        }

        [Test]
        public void Destinatario_Integracao_Atualizar_CpfNulo_EsperadoFalha()
        {
            _destinatario = DestinatarioObjetoMae.ObterValidoPessoa();
            _destinatario.Cpf = null;

            Action action = () => _destinatarioServico.Atualizar(_destinatario);

            action.Should().Throw<ExcecaoCpfNaoDefinido>();
        }

        [Test]
        public void Destinatario_Integracao_Atualizar_ComCNPJ_EsperadoFalha()
        {
            _destinatario = DestinatarioObjetoMae.ObterValidoPessoa();
            _destinatario.Cnpj = new Cnpj();

            Action action = () => _destinatarioServico.Atualizar(_destinatario);

            action.Should().Throw<ExcecaoPessoaComCnpj>();
        }

        [Test]
        public void Destinatario_Integracao_Atualizar_ComRazaoSocial_EsperadoFalha()
        {
            _destinatario = DestinatarioObjetoMae.ObterValidoPessoa();
            _destinatario.RazaoSocial = "razao social";

            Action action = () => _destinatarioServico.Atualizar(_destinatario);

            action.Should().Throw<ExcecaoPessoaComRazaoSocial>();
        }
    }
}

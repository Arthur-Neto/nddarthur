using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Aplicacao.Features.Emitentes;
using Projeto_NFe.Comuns.Testes.Features.Base;
using Projeto_NFe.Comuns.Testes.Features.Emitentes;
using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Dominio.Features.Emitentes;
using Projeto_NFe.Dominio.Features.Emitentes.Excercoes;
using Projeto_NFe.Dominio.Features.Enderecos;
using Projeto_NFe.Dominio.Features.NotasFiscais;
using Projeto_NFe.Infra.Data.Features.Emitentes;
using Projeto_NFe.Infra.Data.Features.Enderecos;
using Projeto_NFe.Infra.Data.Features.NotasFiscais;
using Projeto_NFe.Infra.Documentos.Features.Cnpjs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Integracao.Testes.Features.Emitentes
{
    [TestFixture]
    class EmitenteIntegracaoTestes
    {
        private IEnderecoRepositorio _enderecoRepositorio;
        private IEmitenteRepositorio _emitenteRepositorio;
        private INotaFiscalRepositorio _notaFiscalRepositorio;
        private Emitente _emitente;
        private IEmitenteServico _emitenteServico;

        [SetUp]
        public void SetUp()
        {
            _emitente = new Emitente();
            _enderecoRepositorio = new EnderecoRepositorioSql();
            _notaFiscalRepositorio = new NotaFiscalRepositorioSql();
            _emitenteRepositorio = new EmitenteRepositorioSql();
            _emitenteServico = new EmitenteServico(_emitenteRepositorio, _notaFiscalRepositorio, _enderecoRepositorio);

            BaseSqlTeste.SemearBancoParaEmitente();
        }

        [Test]
        public void Emitente_Integracao_Inserir_EsperadoOK()
        {
            _emitente = EmitenteObjetoMae.ObterValido();

            var emitente = _emitenteServico.Inserir(_emitente);

            var emitenteInserido = _emitenteServico.ObterPorId(emitente.ID);
            emitenteInserido.Should().NotBeNull();
            emitente.ID.Should().Be(emitenteInserido.ID);
        }

        [Test]
        public void Emitente_Integracao_Deletar_EsperadoOK()
        {
            _emitente = EmitenteObjetoMae.ObterValido();

            var emitente = _emitenteServico.Inserir(_emitente);

            var emitenteDeletado = _emitenteServico.Deletar(emitente.ID);

            var emitenteBuscar = _emitenteServico.ObterPorId(emitente.ID);
            emitenteBuscar.Should().BeNull();
            emitenteDeletado.Should().BeTrue();
        }

        [Test]
        public void Emitente_Integracao_Atualizar_EsperadoOK()
        {
            _emitente.ID = 1;

            var emitente = _emitenteServico.ObterPorId(_emitente.ID);
            emitente.NomeFantasia = "José das coves";

            var emitenteAtualizado = _emitenteServico.Atualizar(emitente);

            var emitenteBuscar = _emitenteServico.ObterPorId(emitenteAtualizado.ID);
            emitenteBuscar.NomeFantasia.Should().Be(emitenteAtualizado.NomeFantasia);
            emitenteBuscar.ID.Should().Be(emitenteAtualizado.ID);
        }

        [Test]
        public void Emitente_Integracao_ObterPorId_EsperadoOK()
        {
            _emitente.ID = 1;

            var emitente = _emitenteServico.ObterPorId(_emitente.ID);

            emitente.ID.Should().Be(_emitente.ID);
        }

        [Test]
        public void Emitente_Integracao_ObterTodos_EsperadoOK()
        {
            var id = 1;

            var emitentes = _emitenteServico.ObterTodos();

            emitentes.First().ID.Should().Be(id);
        }

        [Test]
        public void Emitente_Integracao_Atualizar_IDZero_EsperadoOK()
        {
            _emitente.ID = 0;

            Action action = ()=> _emitenteServico.ObterPorId(_emitente.ID);

            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void Emitente_Integracao_ObterPorId_IDZero_EsperadoOK()
        {
            _emitente.ID = 0;

            Action action = () => _emitenteServico.ObterPorId(_emitente.ID);

            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }
        [Test]
        public void Emitente_Integracao_Deletar_IDZero_EsperadoOK()
        {
            _emitente.ID = 0;

            Action action = () => _emitenteServico.Deletar(_emitente.ID);

            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void Emitente_Integracao_Inserir_RazaoSocialInvalida_EsperadoOK()
        {
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.RazaoSocial = string.Empty;

            Action action = () => _emitenteServico.Inserir(_emitente);

            action.Should().Throw<ExcecaoRazaoSocialInvalida>();
        }

        [Test]
        public void Emitente_Integracao_Atualizar_RazaoSocialInvalida_EsperadoOK()
        {
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.RazaoSocial = string.Empty;

            Action action = () => _emitenteServico.Atualizar(_emitente);

            action.Should().Throw<ExcecaoRazaoSocialInvalida>();
        }

        [Test]
        public void Emitente_Integracao_Inserir_EnderecoInvalido_EsperadoOK()
        {
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.Endereco = null;

            Action action = () => _emitenteServico.Inserir(_emitente);

            action.Should().Throw<ExcecaoEnderecoEmBranco>();
        }

        [Test]
        public void Emitente_Integracao_Atualizar_EnderecoInvalido_EsperadoOK()
        {
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.Endereco = null;

            Action action = () => _emitenteServico.Atualizar(_emitente);

            action.Should().Throw<ExcecaoEnderecoEmBranco>();
        }

        [Test]
        public void Emitente_Integracao_Inserir_NomeFantasiaInvalido_EsperadoOK()
        {
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.NomeFantasia = string.Empty;

            Action action = () => _emitenteServico.Inserir(_emitente);

            action.Should().Throw<ExcecaoNomeEmBranco>();
        }

        [Test]
        public void Emitente_Integracao_Atualizar_NomeFantasiaInvalido_EsperadoOK()
        {
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.NomeFantasia = string.Empty;

            Action action = () => _emitenteServico.Atualizar(_emitente);

            action.Should().Throw<ExcecaoNomeEmBranco>();
        }

        [Test]
        public void Emitente_Integracao_Inserir_CNPJInvalido_EsperadoOK()
        {
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.CNPJ = new Cnpj() ;

            Action action = () => _emitenteServico.Inserir(_emitente);

            action.Should().Throw<ExcecaoCNPJInvalido>();
        }

        [Test]
        public void Emitente_Integracao_Atualizar_CNPJInvalido_EsperadoOK()
        {
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.CNPJ = new Cnpj();

            Action action = () => _emitenteServico.Atualizar(_emitente);

            action.Should().Throw<ExcecaoCNPJInvalido>();
        }

        [Test]
        public void Emitente_Integracao_Inserir_InscricaoEstadualInvalida_EsperadoOK()
        {
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.InscricaoEstadual = string.Empty;
            
            Action action = () => _emitenteServico.Inserir(_emitente);

            action.Should().Throw<ExcecaoInscricaoEstadualInvalido>();
        }

        [Test]
        public void Emitente_Integracao_Atualizar_InscricaoEstadualInvalida_EsperadoOK()
        {
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.InscricaoEstadual = string.Empty;

            Action action = () => _emitenteServico.Atualizar(_emitente);

            action.Should().Throw<ExcecaoInscricaoEstadualInvalido>();
        }

        [Test]
        public void Emitente_Integracao_Inserir_InscricaoMunicipalInvalida_EsperadoOK()
        {
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.InscricaoMunicipal = string.Empty;

            Action action = () => _emitenteServico.Inserir(_emitente);

            action.Should().Throw<ExcecaoInscricaoMunicipalInvalido>();
        }

        [Test]
        public void Emitente_Integracao_Atualizar_InscricaoMunicipalInvalida_EsperadoOK()
        {
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.InscricaoMunicipal = string.Empty;

            Action action = () => _emitenteServico.Atualizar(_emitente);

            action.Should().Throw<ExcecaoInscricaoMunicipalInvalido>();
        }
    }
}

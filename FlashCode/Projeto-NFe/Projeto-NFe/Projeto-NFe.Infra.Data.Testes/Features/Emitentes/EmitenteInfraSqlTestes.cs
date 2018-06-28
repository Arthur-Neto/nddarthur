using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Comuns.Testes.Features.Emitentes;
using Projeto_NFe.Comuns.Testes.Features.Cnpjs;
using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Dominio.Features.Emitentes;
using Projeto_NFe.Dominio.Features.Emitentes.Excercoes;
using Projeto_NFe.Infra.Data.Features.Emitentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Comuns.Testes.Features.Base;

namespace Projeto_NFe.Infra.Data.Testes.Features.Emitentes
{
    [TestFixture]
    public class EmitenteInfraSqlTestes
    {
        private IEmitenteRepositorio _emitenteRepositorio;
        private Emitente _emitente;

        [SetUp]
        public void SetUp()
        {
            _emitenteRepositorio = new EmitenteRepositorioSql();
            _emitente = new Emitente();
        }

        [Test]
        public void Emitente_InfraData_Inserir_EsperadoOK()
        {
            //cenário
            BaseSqlTeste.SemearBancoParaEmitente();
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.ID = 0;
            //Ação
            Emitente emitente = _emitenteRepositorio.Inserir(_emitente);

            //Verificação
            emitente.ID.Should().BeGreaterThan(0);

        }
        [Test]
        public void Emitente_InfraData_Deletar_EsperadoOK()
        {
            //cenário
            _emitente.ID = 2;
            BaseSqlTeste.SemearBancoParaEmitente();
            
            //Ação
            bool deletado = _emitenteRepositorio.Deletar(_emitente.ID);

            //Verificação
            deletado.Should().BeTrue();
        }
        [Test]
        public void Emitente_InfraData_Atualizar_EsperadoOK()
        {
            //cenário
            BaseSqlTeste.SemearBancoParaEmitente();
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.ID = 1;
            _emitente.InscricaoEstadual = "3333";

            //Ação
            Emitente emitente = _emitenteRepositorio.Atualizar(_emitente);

            //Verificação
            emitente.InscricaoEstadual.Should().Be(_emitente.InscricaoEstadual);
            emitente = _emitenteRepositorio.ObterPorId(emitente.ID);
            emitente.InscricaoEstadual.Should().Be(_emitente.InscricaoEstadual);
        }
        [Test]
        public void Emitente_InfraData_PegarPorID_EsperadoOK()
        {
            //cenário
            BaseSqlTeste.SemearBancoParaEmitente();
            _emitente.ID = 1;

            //Ação
            Emitente emitente = _emitenteRepositorio.ObterPorId(_emitente.ID);

            //Verificação
            emitente.Should().NotBeNull();
            emitente.ID.Should().Be(_emitente.ID);
            emitente.InscricaoEstadual.Should().NotBeNullOrEmpty();
        }
        [Test]
        public void Emitente_InfraData_PegarTodos_EsperadoOK()
        {
            //Cenário
            BaseSqlTeste.SemearBancoParaEmitente();

            //Ação
            List<Emitente> listaEmitentes =  _emitenteRepositorio.ObterTodos();

            //Verificação
            listaEmitentes.Should().NotBeNull();
            listaEmitentes.Count.Should().BeGreaterThan(0);
        }//
        [Test]
        public void Emitente_InfraData_Deletar_IDInvalido_EsperadoFalso()
        {
            //Cenário
            BaseSqlTeste.SemearBancoParaEmitente();
            _emitente.ID = 23;
            //Ação
            bool deletado = _emitenteRepositorio.Deletar(_emitente.ID);

            //Verificação
            deletado.Should().BeFalse();
        }
        [Test]
        public void Emitente_InfraData_ObterPorID_IDInvalido_EsperadoFalha()
        {
            //Cenário
            BaseSqlTeste.SemearBancoParaEmitente();
            _emitente.ID = 23;
            //Ação
            Emitente emitente = _emitenteRepositorio.ObterPorId(_emitente.ID);

            //Verificação
            emitente.Should().BeNull();
        }
        [Test]
        public void Emitente_InfraData_ObterPorID_IDZero_EsperadoFalha()
        {
            //Cenário
            _emitente.ID = 0;
            //Ação
            Action action = () => _emitenteRepositorio.ObterPorId(_emitente.ID);

            //Verificação
            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }
        [Test]
        public void Emitente_InfraData_Deletar_IDZero_EsperadoFalha()
        {
            //Cenário
            _emitente.ID = 0;
            //Ação
            Action action = () => _emitenteRepositorio.Deletar(_emitente.ID);

            //Verificação
            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }
        [Test]
        public void Emitente_InfraData_Atualizar_IDZero_EsperadoFalha()
        {
            //Cenário
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.ID = 0;
            //Ação
            Action action = () => _emitenteRepositorio.Atualizar(_emitente);

            //Verificação
            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void Teste_InfraData_Emitente_ObterPorEnderecoID_EsperadoOK()
        {
            _emitente.ID = 1;

            var emitente = _emitenteRepositorio.ObterPorEnderecoID(_emitente.ID);

            emitente.ID.Should().Be(_emitente.ID);
        }

        [Test]
        public void Teste_InfraData_Emitente_ObterPorEnderecoID_IDInvalido_EsperadoNulo()
        {
            _emitente.ID = 1234;

            var emitente = _emitenteRepositorio.ObterPorEnderecoID(_emitente.ID);

            emitente.Should().BeNull();
        }
        //testes de validar ao inserir
        [Test]
        public void Emitente_InfraData_Inserir_EnderecoNulo_EsperadoFalha()
        {
            //Cenário
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.Endereco = null;
            //Ação
            Action action = () => _emitenteRepositorio.Inserir(_emitente);

            //Verificação
            action.Should().Throw<ExcecaoEnderecoEmBranco>();
        }
        [Test]
        public void Emitente_InfraData_Inserir_NomeFantasiaInvalido_EsperadoFalha()
        {
            //Cenário
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.NomeFantasia = String.Empty;
            //Ação
            Action action = () => _emitenteRepositorio.Inserir(_emitente);

            //Verificação
            action.Should().Throw<ExcecaoNomeEmBranco>();
        }
        [Test]
        public void Emitente_InfraData_Inserir_CNPJInvalido_EsperadoFalha()
        {
            //Cenário
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.CNPJ = CnpjObjetoMae.ObterSegundoDigitoInvalido();
            //Ação
            Action action = () => _emitenteRepositorio.Inserir(_emitente);

            //Verificação
            action.Should().Throw<ExcecaoCNPJInvalido>();
        }
        [Test]
        public void Emitente_InfraData_Inserir_InscricaoEstadualInvalido_EsperadoFalha()
        {
            //Cenário
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.InscricaoEstadual = String.Empty;
            //Ação
            Action action = () => _emitenteRepositorio.Inserir(_emitente);

            //Verificação
            action.Should().Throw<ExcecaoInscricaoEstadualInvalido>();
        }
        [Test]
        public void Emitente_InfraData_Inserir_InscricaoMunicipalInvalido_EsperadoFalha()
        {
            //Cenário
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.InscricaoMunicipal = String.Empty;
            //Ação
            Action action = () => _emitenteRepositorio.Inserir(_emitente);

            //Verificação
            action.Should().Throw<ExcecaoInscricaoMunicipalInvalido>();
        }
        [Test]
        public void Emitente_InfraData_Atualizar_EnderecoNulo_EsperadoFalha()
        {
            //Cenário
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.Endereco = null;
            //Ação
            Action action = () => _emitenteRepositorio.Atualizar(_emitente);

            //Verificação
            action.Should().Throw<ExcecaoEnderecoEmBranco>();
        }
        [Test]
        public void Emitente_InfraData_Atualizar_NomeFantasiaInvalido_EsperadoFalha()
        {
            //Cenário
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.NomeFantasia = String.Empty;
            //Ação
            Action action = () => _emitenteRepositorio.Atualizar(_emitente);

            //Verificação
            action.Should().Throw<ExcecaoNomeEmBranco>();
        }
        [Test]
        public void Emitente_InfraData_Atualizar_CNPJInvalido_EsperadoFalha()
        {
            //Cenário
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.CNPJ = CnpjObjetoMae.ObterPrimeiroDigitoInvalido();
            //Ação
            Action action = () => _emitenteRepositorio.Atualizar(_emitente);

            //Verificação
            action.Should().Throw<ExcecaoCNPJInvalido>();
        }
        [Test]
        public void Emitente_InfraData_Atualizar_InscricaoEstadualInvalido_EsperadoFalha()
        {
            //Cenário
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.InscricaoEstadual = String.Empty;
            //Ação
            Action action = () => _emitenteRepositorio.Atualizar(_emitente);

            //Verificação
            action.Should().Throw<ExcecaoInscricaoEstadualInvalido>();
        }
        [Test]
        public void Emitente_InfraData_Atualizar_InscricaoMunicipalInvalido_EsperadoFalha()
        {
            //Cenário
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.InscricaoMunicipal = String.Empty;
            //Ação
            Action action = () => _emitenteRepositorio.Atualizar(_emitente);

            //Verificação
            action.Should().Throw<ExcecaoInscricaoMunicipalInvalido>();
        }

        [Test]
        public void Emitente_InfraData_Atualizar_RazaoSocialInvalida_EsperadoFalha()
        {
            //Cenário
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.RazaoSocial = String.Empty;
            //Ação
            Action action = () => _emitenteRepositorio.Atualizar(_emitente);

            //Verificação
            action.Should().Throw<ExcecaoRazaoSocialInvalida>();
        }
    }
}
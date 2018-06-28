using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Comuns.Testes.Features.Base;
using Projeto_NFe.Comuns.Testes.Features.NotasFiscais;
using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Dominio.Features.NotasFiscais;
using Projeto_NFe.Dominio.Features.NotasFiscais.Excecoes;
using Projeto_NFe.Dominio.Features.Produtos;
using Projeto_NFe.Infra.Data.Features.NotasFiscais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Data.Testes.Features.NotasFiscais
{
    [TestFixture]
    public class NotaFiscalInfraSqlTestes
    {
        private NotaFiscalRepositorioSql _notaFiscalRepositorio;
        private NotaFiscal _notaFiscal;

        [SetUp]
        public void SetUp()
        {
            _notaFiscal = new NotaFiscal();
            _notaFiscalRepositorio = new NotaFiscalRepositorioSql();
        }

        [Test]
        public void NotaFiscal_InfraData_Inserir_EsperadoOK()
        {
            BaseSqlTeste.SemearBancoParaNotaFiscal();
            _notaFiscal = NotaFiscalObjetoMae.ObterValidoNotaFiscal();

            NotaFiscal notaFiscal = _notaFiscalRepositorio.Inserir(_notaFiscal);

            _notaFiscal.ID.Should().Be(notaFiscal.ID);
        }

        [Test]
        public void NotaFiscal_InfraData_Atualizar_EsperadoOK()
        {
            BaseSqlTeste.SemearBancoParaNotaFiscal();
            _notaFiscal = NotaFiscalObjetoMae.ObterValidoNotaFiscal();

            NotaFiscal notaFiscal = _notaFiscalRepositorio.Atualizar(_notaFiscal);

            _notaFiscal.ID.Should().Be(notaFiscal.ID);
        }


        [Test]
        public void NotaFiscal_InfraData_Inserir_ComValorNotaInvalido_EsperadoFalha()
        {
            _notaFiscal = NotaFiscalObjetoMae.ObterValidoNotaFiscal();
            _notaFiscal.ValorTotalNota = 0;

            Action action = () => _notaFiscalRepositorio.Inserir(_notaFiscal);

            action.Should().Throw<ExcecaoValorTotalInvalido>();
        }

        [Test]
        public void NotaFiscal_InfraData_Inserir_ComChaveInvalida_EsperadoFalha()
        {
            _notaFiscal = NotaFiscalObjetoMae.ObterValidoNotaFiscal();
            _notaFiscal.Chave = String.Empty;

            Action action = () => _notaFiscalRepositorio.Inserir(_notaFiscal);

            action.Should().Throw<ExcecaoChaveInvalida>();
        }

        [Test]
        public void NotaFiscal_InfraData_Inserir_ComDataEmissaoInvalida_EsperadoFalha()
        {
            _notaFiscal = NotaFiscalObjetoMae.ObterValidoNotaFiscal();
            _notaFiscal.DataEmissao = DateTime.Now.AddDays(-1);

            Action action = () => _notaFiscalRepositorio.Inserir(_notaFiscal);

            action.Should().Throw<ExcecaoDataEmissaoInvalida>();
        }

        [Test]
        public void NotaFiscal_InfraData_Inserir_ComDataEntradaInvalida_EsperadoFalha()
        {
            _notaFiscal = NotaFiscalObjetoMae.ObterValidoNotaFiscal();
            _notaFiscal.DataEntrada = DateTime.Now.AddDays(-1);

            Action action = () => _notaFiscalRepositorio.Inserir(_notaFiscal);

            action.Should().Throw<ExcecaoDataEntradaInvalida>();
        }

        [Test]
        public void NotaFiscal_InfraData_Inserir_ComDestinatarioInvalido_EsperadoFalha()
        {
            _notaFiscal = NotaFiscalObjetoMae.ObterValidoNotaFiscal();
            _notaFiscal.Destinatario = null;

            Action action = () => _notaFiscalRepositorio.Inserir(_notaFiscal);

            action.Should().Throw<ExcecaoDestinatarioNulo>();
        }

        [Test]
        public void NotaFiscal_InfraData_Inserir_ComEmitenteInvalido_EsperadoFalha()
        {
            _notaFiscal = NotaFiscalObjetoMae.ObterValidoNotaFiscal();
            _notaFiscal.Emitente = null;

            Action action = () => _notaFiscalRepositorio.Inserir(_notaFiscal);

            action.Should().Throw<ExcecaoEmitenteNulo>();
        }

        [Test]
        public void NotaFiscal_InfraData_Inserir_ComContadorDeProdutosInvalido_EsperadoFalha()
        {
            _notaFiscal = NotaFiscalObjetoMae.ObterValidoNotaFiscal();
            _notaFiscal.Produtos = new List<ProdutoNfe>();

            Action action = () => _notaFiscalRepositorio.Inserir(_notaFiscal);

            action.Should().Throw<ExcecaoProdutosVazio>();
        }

        [Test]
        public void NotaFiscal_InfraData_Inserir_ComNaturezaOperacaoInvalida_EsperadoFalha()
        {
            _notaFiscal = NotaFiscalObjetoMae.ObterValidoNotaFiscal();
            _notaFiscal.NaturezaOperacao = String.Empty;

            Action action = () => _notaFiscalRepositorio.Inserir(_notaFiscal);

            action.Should().Throw<ExcecaoNaturezaOperacaoVazia>();
        }


        [Test]
        public void NotaFiscal_InfraData_Atualizar_ComValorNotaInvalido_EsperadoFalha()
        {
            _notaFiscal = NotaFiscalObjetoMae.ObterValidoNotaFiscal();
            _notaFiscal.ValorTotalNota = 0;

            Action action = () => _notaFiscalRepositorio.Atualizar(_notaFiscal);

            action.Should().Throw<ExcecaoValorTotalInvalido>();
        }

        [Test]
        public void NotaFiscal_InfraData_Atualizar_ComChaveInvalida_EsperadoFalha()
        {
            _notaFiscal = NotaFiscalObjetoMae.ObterValidoNotaFiscal();
            _notaFiscal.Chave = String.Empty;

            Action action = () => _notaFiscalRepositorio.Atualizar(_notaFiscal);

            action.Should().Throw<ExcecaoChaveInvalida>();
        }

        [Test]
        public void NotaFiscal_InfraData_Atualizar_ComDataEmissaoInvalida_EsperadoFalha()
        {
            _notaFiscal = NotaFiscalObjetoMae.ObterValidoNotaFiscal();
            _notaFiscal.DataEmissao = DateTime.Now.AddDays(-1);

            Action action = () => _notaFiscalRepositorio.Atualizar(_notaFiscal);

            action.Should().Throw<ExcecaoDataEmissaoInvalida>();
        }

        [Test]
        public void NotaFiscal_InfraData_Atualizar_ComDataEntradaInvalida_EsperadoFalha()
        {
            _notaFiscal = NotaFiscalObjetoMae.ObterValidoNotaFiscal();
            _notaFiscal.DataEntrada = DateTime.Now.AddDays(-1);

            Action action = () => _notaFiscalRepositorio.Atualizar(_notaFiscal);

            action.Should().Throw<ExcecaoDataEntradaInvalida>();
        }

        [Test]
        public void NotaFiscal_InfraData_Atualizar_ComDestinatarioInvalida_EsperadoFalha()
        {
            _notaFiscal = NotaFiscalObjetoMae.ObterValidoNotaFiscal();
            _notaFiscal.Destinatario = null;

            Action action = () => _notaFiscalRepositorio.Atualizar(_notaFiscal);

            action.Should().Throw<ExcecaoDestinatarioNulo>();
        }

        [Test]
        public void NotaFiscal_InfraData_Atualizar_ComEmitenteInvalido_EsperadoFalha()
        {
            _notaFiscal = NotaFiscalObjetoMae.ObterValidoNotaFiscal();
            _notaFiscal.Emitente = null;

            Action action = () => _notaFiscalRepositorio.Atualizar(_notaFiscal);

            action.Should().Throw<ExcecaoEmitenteNulo>();
        }

        [Test]
        public void NotaFiscal_InfraData_Atualizar_ComContadorDeProdutosInvalido_EsperadoFalha()
        {
            _notaFiscal = NotaFiscalObjetoMae.ObterValidoNotaFiscal();
            _notaFiscal.Produtos = new List<ProdutoNfe>();

            Action action = () => _notaFiscalRepositorio.Atualizar(_notaFiscal);

            action.Should().Throw<ExcecaoProdutosVazio>();
        }

        [Test]
        public void NotaFiscal_InfraData_Atualizar_ComNaturezaOperacaoInvalida_EsperadoFalha()
        {
            _notaFiscal = NotaFiscalObjetoMae.ObterValidoNotaFiscal();
            _notaFiscal.NaturezaOperacao = String.Empty;

            Action action = () => _notaFiscalRepositorio.Atualizar(_notaFiscal);

            action.Should().Throw<ExcecaoNaturezaOperacaoVazia>();
        }

        [Test]
        public void NotaFiscal_InfraData_Atualizar_ComIDInvalido_EsperadoFalha()
        {
            _notaFiscal.ID = 0;

            Action action = () => _notaFiscalRepositorio.Atualizar(_notaFiscal);

            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }
        [Test]
        public void NotaFiscal_InfraData_Deletar_EsperadoOK()
        {
            BaseSqlTeste.SemearBancoParaNotaFiscal();
            _notaFiscal.ID = 2;

            bool nfe = _notaFiscalRepositorio.Deletar(_notaFiscal.ID);

            nfe.Should().BeTrue();
        }

        [Test]
        public void NotaFiscal_InfraData_Deletar_ComIDInexistente_EsperadoFalso()
        {
            BaseSqlTeste.SemearBancoParaNotaFiscal();
            _notaFiscal.ID = 2345;

            bool nfe = _notaFiscalRepositorio.Deletar(_notaFiscal.ID);

            nfe.Should().BeFalse();
        }

        [Test]
        public void NotaFiscal_InfraData_Deletar_ComIDZero_EsperadoFalha()
        {
            _notaFiscal.ID = 0;

            Action action = () => _notaFiscalRepositorio.Deletar(_notaFiscal.ID);

            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void NotaFiscal_InfraData_ObterPorID_ComIDZero_EsperadoFalha()
        {
            _notaFiscal.ID = 0;

            Action action = () => _notaFiscalRepositorio.ObterPorId(_notaFiscal.ID);

            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }
        [Test]
        public void NotaFiscal_InfraData_ObterPorID_ComIDInvalido_EsperadoNull()
        {
            BaseSqlTeste.SemearBancoParaNotaFiscal();
            _notaFiscal.ID = 123;

            NotaFiscal nfe = _notaFiscalRepositorio.ObterPorId(_notaFiscal.ID);

            nfe.Should().BeNull();
        }

        [Test]
        public void NotaFiscal_InfraData_ObterPorID_EsperadoOk()
        {
            BaseSqlTeste.SemearBancoParaNotaFiscal();
            _notaFiscal.ID = 1;

            NotaFiscal nfe = _notaFiscalRepositorio.ObterPorId(_notaFiscal.ID);

            nfe.ID.Should().Be(_notaFiscal.ID);
        }

        [Test]
        public void NotaFiscal_InfraData_ObterTodos_EsperadoOk()
        {
            BaseSqlTeste.SemearBancoParaNotaFiscal();

            List<NotaFiscal> listNfe = _notaFiscalRepositorio.ObterTodos();

            listNfe.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void Teste_InfraData_NotaFiscal_ObterPorTransportadorId_EsperadoOk()
        {
            BaseSqlTeste.SemearBancoParaNotaFiscal();

            _notaFiscal.ID = 1;

            NotaFiscal  notaFiscal = _notaFiscalRepositorio.ObterPorTransportadorID(_notaFiscal.ID);

            notaFiscal.ID.Should().BeGreaterThan(0);
        }

        [Test]
        public void Teste_InfraData_NotaFiscal_ObterPorTransportadorId_IDInvalido_EsperadoNull()
        {
            BaseSqlTeste.SemearBancoParaNotaFiscal();

            _notaFiscal.ID = 123;

            NotaFiscal notaFiscal = _notaFiscalRepositorio.ObterPorTransportadorID(_notaFiscal.ID);

            notaFiscal.Should().BeNull();
        }

        [Test]
        public void Teste_InfraData_NotaFiscal_ObterPorEmitenteId_EsperadoOk()
        {
            BaseSqlTeste.SemearBancoParaNotaFiscal();

            _notaFiscal.ID = 1;

            NotaFiscal notaFiscal = _notaFiscalRepositorio.ObterPorEmitenteID(_notaFiscal.ID);

            notaFiscal.ID.Should().BeGreaterThan(0);
        }

        [Test]
        public void Teste_InfraData_NotaFiscal_ObterPorEmitenteId_IDInvalido_EsperadoNull()
        {
            BaseSqlTeste.SemearBancoParaNotaFiscal();

            _notaFiscal.ID = 123;

            NotaFiscal notaFiscal = _notaFiscalRepositorio.ObterPorEmitenteID(_notaFiscal.ID);

            notaFiscal.Should().BeNull();
        }
        [Test]
        public void Teste_InfraData_NotaFiscal_ObterPorDestinatarioId_EsperadoOk()
        {
            BaseSqlTeste.SemearBancoParaNotaFiscal();

            _notaFiscal.ID = 1;

            NotaFiscal notaFiscal = _notaFiscalRepositorio.ObterPorDestinatarioID(_notaFiscal.ID);

            notaFiscal.ID.Should().BeGreaterThan(0);
        }

        [Test]
        public void Teste_InfraData_NotaFiscal_ObterPorDestinatarioId_IDInvalido_EsperadoNull()
        {
            BaseSqlTeste.SemearBancoParaNotaFiscal();

            _notaFiscal.ID = 123;

            NotaFiscal notaFiscal = _notaFiscalRepositorio.ObterPorDestinatarioID(_notaFiscal.ID);

            notaFiscal.Should().BeNull();
        }

        [Test]
        public void Teste_InfraData_NotaFiscal_ObterPorChave_EsperadoOk()
        {
            BaseSqlTeste.SemearBancoParaNotaFiscal();

            _notaFiscal = NotaFiscalObjetoMae.ObterValidoNotaFiscal();

            NotaFiscal notaFiscal = _notaFiscalRepositorio.ObterPorChave(_notaFiscal.Chave);

            notaFiscal.Should().NotBeNull();
            notaFiscal.Chave.Should().Be(_notaFiscal.Chave);
        }

        [Test]
        public void Teste_InfraData_NotaFiscal_ObterPorChave_ChaveInvalida_EsperadoNull()
        {
            BaseSqlTeste.SemearBancoParaNotaFiscal();

            _notaFiscal.Chave = string.Empty;

            NotaFiscal notaFiscal = _notaFiscalRepositorio.ObterPorChave(_notaFiscal.Chave);

            notaFiscal.Should().BeNull();
        }

        [Test]
        public void Teste_InfraData_NotaFiscal_VerificarExistenciaPorChave_ChaveInvalida_EsperadoNull()
        {
            BaseSqlTeste.SemearBancoParaNotaFiscal();

            _notaFiscal.Chave = string.Empty;

            bool notaFiscal = _notaFiscalRepositorio.ValidarExistenciaPorChave(_notaFiscal.Chave);

            notaFiscal.Should().BeFalse();
        }

        [Test]
        public void Teste_InfraData_NotaFiscal_VerificarExistenciaPorChave_EsperadoOk()
       {
            BaseSqlTeste.SemearBancoParaNotaFiscal();

            _notaFiscal = NotaFiscalObjetoMae.ObterValidoNotaFiscal();

            bool notaFiscal = _notaFiscalRepositorio.ValidarExistenciaPorChave(_notaFiscal.Chave);

            notaFiscal.Should().BeTrue();
        }

        [Test]
        public void Teste_InfraData_NotaFiscal_InserirNotaFiscalEmitida_EsperadoOk()
        {
            BaseSqlTeste.SemearBancoParaNotaFiscal();

            _notaFiscal = NotaFiscalObjetoMae.ObterValidoNotaFiscal();

            Action action =()=> _notaFiscalRepositorio.InserirNotaFiscalEmitida(_notaFiscal);

            action.Should().NotThrow();
        }
    }
}

using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Comuns.Testes.Features.Base;
using Projeto_NFe.Comuns.Testes.Features.ProdutosNFe;
using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Dominio.Features.Produtos;
using Projeto_NFe.Dominio.Features.Produtos.Excecoes;
using Projeto_NFe.Dominio.Features.ProdutosNFe;
using Projeto_NFe.Dominio.Features.ProdutosNFe.Excecoes;
using Projeto_NFe.Infra.Data.Features.ProdutosNFe;
using System;
using System.Collections.Generic;

namespace Projeto_NFe.Infra.Data.Testes.Features.ProdutosNFe
{
    [TestFixture]
    public class ProdutoNfeInfraSqlTestes
    {
        ProdutoNfe _produtoNfe;
        IProdutoNFeRepositorio _produtoNfeRepositorio;

        long nfeID;
        long produtoId;

        [SetUp]
        public void SetUp()
        {
            _produtoNfe = new ProdutoNfe();
            _produtoNfeRepositorio = new ProdutoNFeRepositorioSql();
            produtoId = 1;
            nfeID = 1;
        }

        [Test]
        public void ProdutoNFe_InfraData_Inserir_EsperadoOK()
        {
            BaseSqlTeste.SemearBancoParaProdutoNfe();

            _produtoNfe = ProdutoNfeObjetoMae.ObterProdutoNfe();

            ProdutoNfe produtoNfe = _produtoNfeRepositorio.Inserir(_produtoNfe, nfeID, produtoId);

            produtoNfe.ID.Should().BeGreaterThan(0);
        }

        [Test]
        public void ProdutoNFe_InfraData_Inserir_ComNFeIdInvalido_EsperadoFalha()
        {
            _produtoNfe = ProdutoNfeObjetoMae.ObterProdutoNfe();

            nfeID = 0;

            Action action = () => _produtoNfeRepositorio.Inserir(_produtoNfe, nfeID, produtoId);

            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void ProdutoNFe_InfraData_Inserir_ComProdutoIdInvalido_EsperadoFalha()
        {
            _produtoNfe = ProdutoNfeObjetoMae.ObterProdutoNfe();

            produtoId = 0;

            Action action = () => _produtoNfeRepositorio.Inserir(_produtoNfe, nfeID, produtoId);

            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void ProdutoNFe_InfraData_InserirLista_EsperadoOK()
        {
            BaseSqlTeste.SemearBancoParaProdutoNfe();

            List<ProdutoNfe> listaProdutos = ProdutoNfeObjetoMae.ObterListaDeProdutosNfe();

            List<ProdutoNfe> listaProdutoNfe = _produtoNfeRepositorio.InserirListaDeProdutos(listaProdutos, nfeID);

            listaProdutos.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void ProdutoNFe_InfraData_InserirLista_ComNFeIdInvalido_EsperadoFalha()
        {
            nfeID = 0;

            List<ProdutoNfe> listaProdutos = new List<ProdutoNfe>();

            Action action = () => _produtoNfeRepositorio.InserirListaDeProdutos(listaProdutos, nfeID);

            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void ProdutoNFe_InfraData_InserirLista_ComProdutoIdInvalido_EsperadoFalha()
        {
            produtoId = 0;

            List<ProdutoNfe> listaProdutos = new List<ProdutoNfe>();

            Action action = () => _produtoNfeRepositorio.InserirListaDeProdutos(listaProdutos, produtoId);

            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void ProdutoNFe_InfraData_InserirLista_ComListaVazia_EsperadoFalha()
        {
            List<ProdutoNfe> listaProdutos = new List<ProdutoNfe>();

            Action action = () => _produtoNfeRepositorio.InserirListaDeProdutos(listaProdutos, nfeID);

            action.Should().Throw<ListaProdutosVazia>();
        }

        [Test]
        public void Teste_InfraData_Produto_Atualizar_EsperadoOK()
        {
            BaseSqlTeste.SemearBancoParaProdutoNfe();

            _produtoNfe = ProdutoNfeObjetoMae.ObterProdutoNfe();

            ProdutoNfe produtoNfe = _produtoNfeRepositorio.Atualizar(_produtoNfe, nfeID, produtoId);

            produtoNfe.ID.Should().Be(_produtoNfe.ID);
        }

        [Test]
        public void Teste_InfraData_Produto_Atualizar_ComProdutoNFeIdInvalido_EsperadoFalha()
        {
            _produtoNfe.ID = 0;

            Action action = () => _produtoNfeRepositorio.Atualizar(_produtoNfe, nfeID, produtoId);

            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void Teste_InfraData_Produto_Atualizar_ComNFeIdInvalido_EsperadoFalha()
        {
            nfeID = 0;

            Action action = () => _produtoNfeRepositorio.Atualizar(_produtoNfe, nfeID, produtoId);

            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void Teste_InfraData_Produto_Atualizar_ComProdutoIdInvalido_EsperadoFalha()
        {
            produtoId = 0;

            Action action = () => _produtoNfeRepositorio.Atualizar(_produtoNfe, nfeID, produtoId);

            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void Teste_InfraData_Produto_Atualizar_OperacaoNaoSuportada_EsperadoOK()
        {
            Action action = () => _produtoNfeRepositorio.Atualizar(_produtoNfe);

            action.Should().Throw<ExcexaoOperacaoNaoSuportada>();
        }

        [Test]
        public void ProdutoNFe_InfraData_Inserir_OperacaoNaoSuportada_EsperadoOK()
        {
            Action action = () => _produtoNfeRepositorio.Inserir(_produtoNfe);

            action.Should().Throw<ExcexaoOperacaoNaoSuportada>();
        }

        [Test]
        public void ProdutoNFe_InfraData_Deletar_OperacaoNaoSuportada_EsperadoOK()
        {
            BaseSqlTeste.SemearBancoParaProdutoNfe();

            Action action = () => _produtoNfeRepositorio.Deletar(_produtoNfe.ID);

            action.Should().Throw<ExcexaoOperacaoNaoSuportada>();
        }

        [Test]
        public void ProdutoNFe_InfraData_Deletar_PorNotaFiscalID_EsperadoOK()
        {
            BaseSqlTeste.SemearBancoParaProdutoNfe();

            var result = _produtoNfeRepositorio.DeletarPorNotaFiscalID(nfeID);

            result.Should().BeTrue();
        }

        [Test]
        public void ProdutoNFe_InfraData_Deletar_PorNotaFiscalID_ComIdInvalido_EsperadoFalha()
        {
            nfeID = 0;

            Action action = () => _produtoNfeRepositorio.DeletarPorNotaFiscalID(nfeID);

            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void ProdutoNFe_InfraData_Deletar_PorNotaFiscalID_EsperadoFalha()
        {
            BaseSqlTeste.SemearBancoParaProdutoNfe();

            nfeID = 110;

            var result = _produtoNfeRepositorio.DeletarPorNotaFiscalID(nfeID);

            result.Should().BeFalse();
        }

        [Test]
        public void ProdutoNFe_InfraData_Deletar_PorProdutoENotaFiscal_EsperadoOk()
        {
            BaseSqlTeste.SemearBancoParaProdutoNfe();

            var result = _produtoNfeRepositorio.DeletarPorProdutoMaisNotaFiscal(produtoId, nfeID);

            result.Should().BeTrue();
        }

        [Test]
        public void ProdutoNFe_InfraData_Deletar_PorProdutoENotaFiscal_ComNFeIdInvalido_EsperadoFalha()
        {
            nfeID = 0;

            Action action = () => _produtoNfeRepositorio.DeletarPorProdutoMaisNotaFiscal(produtoId, nfeID);

            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void ProdutoNFe_InfraData_Deletar_PorProdutoENotaFiscal_ComProdutoIdInvalido_EsperadoFalha()
        {
            produtoId = 0;

            Action action = () => _produtoNfeRepositorio.DeletarPorProdutoMaisNotaFiscal(produtoId, nfeID);

            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void ProdutoNFe_InfraData_Deletar_PorProdutoMaisNotaFiscal_EsperadoFalha()
        {
            BaseSqlTeste.SemearBancoParaProdutoNfe();

            nfeID = 110;

            var result = _produtoNfeRepositorio.DeletarPorProdutoMaisNotaFiscal(produtoId, nfeID);

            result.Should().BeFalse();
        }

        [Test]
        public void ProdutoNFe_InfraData_ObterTodosPorNotaFiscal_EsperadoOk()
        {
            BaseSqlTeste.SemearBancoParaProdutoNfe();

            List<ProdutoNfe> produtosNfe = _produtoNfeRepositorio.ObterTodosPorNotaFiscal(nfeID);

            produtosNfe.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void ProdutoNFe_InfraData_ObterTodosPorNotaFiscal_IdInvalido_EsperadoFalha()
        {
            nfeID = 0;

            Action action = () => _produtoNfeRepositorio.ObterTodosPorNotaFiscal(nfeID);

            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void ProdutoNFe_InfraData_ObterPorId_EsperadoOk()
        {
            BaseSqlTeste.SemearBancoParaProdutoNfe();

            var produtosNfe = _produtoNfeRepositorio.ObterPorId(nfeID);

            produtosNfe.ID.Should().BeGreaterThan(0);
        }

        [Test]
        public void ProdutoNFe_InfraData_ObterPorId_IdInvalido_EsperadoFalha()
        {
            nfeID = 0;

            Action action = () => _produtoNfeRepositorio.ObterPorId(nfeID);

            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void ProdutoNFe_InfraData_Inserir_QuantidadeInvalida_EsperadoFalha()
        {
            _produtoNfe = ProdutoNfeObjetoMae.ObterProdutoNfe();
            _produtoNfe.Quantidade = -1;

            Action action = () => _produtoNfeRepositorio.Inserir(_produtoNfe, nfeID, produtoId);

            action.Should().Throw<ExcecaoQuantidadeInvalida>();
        }

     
        [Test]
        public void ProdutoNFe_InfraData_ObterTodos_EsperadoOK()
        {
            Action action = () => _produtoNfeRepositorio.ObterTodos();

            action.Should().Throw<ExcexaoOperacaoNaoSuportada>();
        }
    }
}

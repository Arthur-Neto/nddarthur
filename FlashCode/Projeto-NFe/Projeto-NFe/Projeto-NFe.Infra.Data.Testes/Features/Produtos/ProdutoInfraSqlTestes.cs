using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Comuns.Testes.Features.Base;
using Projeto_NFe.Comuns.Testes.Features.Produtos;
using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Dominio.Features.Produtos;
using Projeto_NFe.Dominio.Features.Produtos.Excecoes;
using Projeto_NFe.Infra.Data.Features.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Data.Testes.Features.Produtos
{
    [TestFixture]
    public class ProdutoInfraSqlTestes
    {
        Produto _produto;
        IProdutoRepositorio _produtoRepositorio;

        [SetUp]
        public void SetUp()
        {
            _produto = new Produto();
            _produtoRepositorio = new ProdutoRepositorioSql();

        }

        [Test]
        public void Produto_InfraData_Inserir_EsperadoOK()
        {
            BaseSqlTeste.SemearBancoParaProduto();

            _produto = ProdutoObjetoMae.ObterValido();

            Produto produto = _produtoRepositorio.Inserir(_produto);

            produto.ID.Should().BeGreaterThan(0);
        }

        [Test]
        public void Produto_InfraData_Inserir_ComCodigoInvalido_EsperadoFalha()
        {
            _produto = ProdutoObjetoMae.ObterValido();
            _produto.CodigoProduto = String.Empty;

            Action action = () => _produtoRepositorio.Inserir(_produto);

            action.Should().Throw<ExcecaoCodigoProdutoInvalido>();
        }

        [Test]
        public void Produto_InfraData_Inserir_ComDescricaoInvalida_EsperadoFalha()
        {
            _produto = ProdutoObjetoMae.ObterValido();
            _produto.Descricao = String.Empty;

            Action action = () => _produtoRepositorio.Inserir(_produto);

            action.Should().Throw<ExcecaoDescricaoInvalida>();
        }

        [Test]
        public void Produto_InfraData_Inserir_ComValorInvalido_EsperadoFalha()
        {
            _produto = ProdutoObjetoMae.ObterValido();
            _produto.ValorUnitario = 0;

            Action action = () => _produtoRepositorio.Inserir(_produto);

            action.Should().Throw<ExcecaoValorUnitarioInvalido>();
        }

        [Test]
        public void Produto_InfraData_Atualizar_ComValorInvalido_EsperadoFalha()
        {
            _produto = ProdutoObjetoMae.ObterValido();
            _produto.ValorUnitario = 0;

            Action action = () => _produtoRepositorio.Atualizar(_produto);

            action.Should().Throw<ExcecaoValorUnitarioInvalido>();
        }

        [Test]
        public void Produto_InfraData_Atualizar_ComCodigoInvalido_EsperadoFalha()
        {
            _produto = ProdutoObjetoMae.ObterValido();
            _produto.CodigoProduto = String.Empty;

            Action action = () => _produtoRepositorio.Atualizar(_produto);

            action.Should().Throw<ExcecaoCodigoProdutoInvalido>();
        }

        [Test]
        public void Produto_InfraData_Atualizar_ComDescricaoInvalida_EsperadoFalha()
        {
            _produto = ProdutoObjetoMae.ObterValido();
            _produto.Descricao = String.Empty;

            Action action = () => _produtoRepositorio.Atualizar(_produto);

            action.Should().Throw<ExcecaoDescricaoInvalida>();
        }
        [Test]
        public void Produto_InfraData_Atualizar_EsperadoOK()
        {
            BaseSqlTeste.SemearBancoParaProduto();
            _produto = ProdutoObjetoMae.ObterValido();
            _produto.ID = 1;

            Produto produto = _produtoRepositorio.Atualizar(_produto);

            produto.ID.Should().Be(_produto.ID);
        }

        [Test]
        public void Produto_InfraData_Deletar_EsperadoOK()
        {
            BaseSqlTeste.SemearBancoParaProduto();
            _produto.ID = 2;

            bool produto = _produtoRepositorio.Deletar(_produto.ID);

            produto.Should().BeTrue();
        }

        [Test]
        public void Produto_InfraData_Deletar_ComIDInexistente_EsperadoOK()
        {
            BaseSqlTeste.SemearBancoParaProduto();
            _produto.ID = 2345;

            bool produto = _produtoRepositorio.Deletar(_produto.ID);

            produto.Should().BeFalse();
        }

        [Test]
        public void Produto_InfraData_Deletar_ComIDZero_EsperadoOK()
        {
            _produto.ID = 0;

            Action action = ()=>_produtoRepositorio.Deletar(_produto.ID);

            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void Produto_InfraData_Atualizar_ComIDZero_EsperadoOK()
        {
            _produto.ID = 0;

            Action action = () => _produtoRepositorio.Atualizar(_produto);

            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void Produto_InfraData_ObeterPorID_ComIDZero_EsperadoOK()
        {
            _produto.ID = 0;

            Action action = () => _produtoRepositorio.ObterPorId(_produto.ID);

            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }
        [Test]
        public void Produto_InfraData_ObterPorId_EsperadoOK()
        {
            BaseSqlTeste.SemearBancoParaProduto();
            _produto.ID = 1;

            Produto produto = _produtoRepositorio.ObterPorId(_produto.ID);

            produto.ID.Should().Be(_produto.ID);
        }

        [Test]
        public void Produto_InfraData_ObterTodos_EsperadoOK()
        {
            BaseSqlTeste.SemearBancoParaProduto();

            List<Produto> listaProdutos = _produtoRepositorio.ObterTodos();

            listaProdutos.Count.Should().BeGreaterThan(0);
        }

    }
}

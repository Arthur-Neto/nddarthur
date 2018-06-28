using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Comuns.Testes.Features.Produtos;
using Projeto_NFe.Dominio.Features.Produtos;
using Projeto_NFe.Dominio.Features.Produtos.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Dominio.Testes.Features.Produtos
{
    [TestFixture]
    public class ProdutoDominioTestes
    {
        private Produto _produto;
        
        [SetUp]
        public void SetUp()
        {
            _produto = new Produto();
        }

        [Test]
        public void Produto_Dominio_Validar_EsperadoOK()
        {
            //cenário
            _produto = ProdutoObjetoMae.ObterValido();

            //Ação
            Action action = () => _produto.Validar();

            //Verificação
            action.Should().NotThrow();
        }
        [Test]
        public void Produto_Dominio_Validar_CodigoProduto_EsperadoFalha()
        {
            //cenário
            _produto = ProdutoObjetoMae.ObterCodigoProdutoInvalido();

            //Ação
            Action action = () => _produto.Validar();

            //Verificação
            action.Should().Throw<ExcecaoCodigoProdutoInvalido>();
        }
        [Test]
        public void Produto_Dominio_Validar_Descricao_EsperadoFalha()
        {
            //cenário
            _produto = ProdutoObjetoMae.ObterDescricaoInvalida();

            //Ação
            Action action = () => _produto.Validar();

            //Verificação
            action.Should().Throw<ExcecaoDescricaoInvalida>();
        }
        [Test]
        public void Produto_Dominio_Validar_ValorUnitario_EsperadoFalha()
        {
            //cenário
            _produto = ProdutoObjetoMae.ObterValorUnitarioInvalido();

            //Ação
            Action action = () => _produto.Validar();

            //Verificação
            action.Should().Throw<ExcecaoValorUnitarioInvalido>();
        }
    }
}

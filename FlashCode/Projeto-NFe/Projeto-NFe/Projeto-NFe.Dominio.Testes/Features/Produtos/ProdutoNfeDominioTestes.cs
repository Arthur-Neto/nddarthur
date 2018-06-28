using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Dominio.Features.Impostos;
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
    public class ProdutoNfeDominioTestes
    {
        ProdutoNfe _produtoNfe;

        [SetUp]
        public void SetUp()
        {
            _produtoNfe = new ProdutoNfe();
        }

        [Test]
        public void ProdutoNfe_Dominio_Validar_EsperadoOK()
        {
            _produtoNfe.Quantidade = 10;
            _produtoNfe.ValorUnitario = 20;

            Action action = ()=> _produtoNfe.Validar();

            action.Should().NotThrow();
            _produtoNfe.ValorTotal.Should().BeGreaterThan(0);
        }

        [Test]
        public void ProdutoNfe_Dominio_ObterImposto_EsperadoOK()
        {
            _produtoNfe.Imposto = null;

            _produtoNfe.Imposto.Should().NotBeNull();
        }

        [Test]
        public void ProdutoNfe_Dominio_ObterImpostoNaoNulo_EsperadoOK()
        {
            _produtoNfe.Quantidade = 123;

            _produtoNfe.Imposto = new Imposto(_produtoNfe);

            _produtoNfe.Imposto.Should().NotBeNull();

        }

        [Test]
        public void ProdutoNfe_Dominio_Validar_QuantidadeInvalida_EsperadoFalha()
        {
            _produtoNfe.Quantidade = 0;

            Action action = () => _produtoNfe.Validar();

            action.Should().Throw<ExcecaoQuantidadeInvalida>();
        }

        [Test]
        public void ProdutoNfe_Dominio_Validar_ValorTotal_Negativo_EsperadoFalha()
        {
            _produtoNfe.Quantidade = 1;
            _produtoNfe.ValorTotal = 0;

            Action action = () => _produtoNfe.Validar();

            action.Should().Throw<ExcecaoValorTotalNegativo>();
        }
    }
}

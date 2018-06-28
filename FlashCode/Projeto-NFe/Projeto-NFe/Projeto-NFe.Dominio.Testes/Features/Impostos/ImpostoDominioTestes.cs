using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Dominio.Features.Impostos;
using Projeto_NFe.Dominio.Features.Impostos.Exceptions;
using Projeto_NFe.Dominio.Features.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Dominio.Testes.Features.Impostos
{
    [TestFixture]
    public class ImpostoDominioTestes
    {
        Imposto _imposto;
        

        ProdutoNfe _produtoNfe;

        [SetUp]
        public void SetUp()
        {
            _produtoNfe = new ProdutoNfe();
            _imposto = new Imposto(_produtoNfe);
        }

        [Test]
        public void Imposto_Dominio_Calcular_EsperadoOK()
        {
            _produtoNfe.Quantidade = 15;
            _produtoNfe.ValorUnitario = 13243;

            _imposto = new Imposto(_produtoNfe);

            _imposto.ValorICMS.Should().BeGreaterThan(0);
            _imposto.ValorIPI.Should().BeGreaterThan(0);

        }

        [Test]
        public void Imposto_Dominio_Calcular_ProdutoNull_EsperadoFalha()
        {
            _produtoNfe = null;

            Action action = ()=> _imposto = new Imposto(_produtoNfe);

            action.Should().Throw<ExcecaoProdutoNulo>();

        }
    }
}

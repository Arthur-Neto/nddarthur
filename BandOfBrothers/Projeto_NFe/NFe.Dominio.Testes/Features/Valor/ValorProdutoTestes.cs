using FluentAssertions;
using NFe.Dominio.Features.Valores;
using NUnit.Framework;

namespace NFe.Dominio.Testes.Features.Valor
{
    [TestFixture]
    public class ValorProdutoTestes
    {
        ValorProduto valorProduto;

        [SetUp]
        public void SetUp()
        {
            valorProduto = new ValorProduto();
        }

        [Test]
        public void ValorProduto_Dominio_DeveCalcularICMSCorretamente()
        {
            var valorTotalProduto = 1000; //Unitario * quantidade
            var aliquotaIcms = 0.04;
            var resultado = valorTotalProduto * aliquotaIcms;
            valorProduto.Total = valorTotalProduto;

            valorProduto.CalcularICMS();

            valorProduto.ICMS.Should().Equals(resultado);
        }

        [Test]
        public void ValorProduto_Dominio_DeveCalcularIpiCorretamente()
        {
            var valorTotalProduto = 1000; //Unitario * quantidade
            var aliquotaIpi = 0.1;
            var resultado = valorTotalProduto * aliquotaIpi;
            valorProduto.Total = valorTotalProduto;

            valorProduto.CalcularIpi();

            valorProduto.Ipi.Should().Equals(resultado);
        }
    }
}

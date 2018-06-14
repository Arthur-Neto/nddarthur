using FluentAssertions;
using NFe.Dominio.Features.Valores;
using NUnit.Framework;

namespace NFe.Dominio.Testes.Features.Valor
{
    [TestFixture]
    public class ValorNotaTestes
    {
        ValorNota valorNota;

        [SetUp]
        public void SetUp()
        {
            valorNota = new ValorNota();
        }

        [Test]
        public void ValorNota_Dominio_DeveCalcularICMS()
        {
            var valorTotalProduto = 10000;
            var aliquotaIcms = 0.04;
            var resultado = valorTotalProduto * aliquotaIcms;
            valorNota.TotalProdutos = valorTotalProduto;

            valorNota.CalcularICMS();

            valorNota.ICMS.Should().Equals(resultado);
        }

        [Test]
        public void ValorNota_Dominio_DeveCalcularIpi()
        {
            var valorTotalProduto = 10000;
            var aliquotaIpi = 0.1;
            var resultado = valorTotalProduto * aliquotaIpi;
            valorNota.TotalProdutos = valorTotalProduto;

            valorNota.CalcularIpi();

            valorNota.ICMS.Should().Equals(resultado);
        }

        [Test]
        public void ValorNota_Dominio_DeveCalcularValorTotalNota()
        {
            var valorTotalProduto = 10000;
            valorNota.CalcularICMS();
            var icmsNota = valorNota.ICMS;
            valorNota.CalcularIpi();
            var ipiNota = valorNota.Ipi;
            var frete = valorNota.Frete;
            var resultado = valorTotalProduto + icmsNota + ipiNota + frete;

            valorNota.CalcularValorNota();

            valorNota.TotalNota.Should().Equals(resultado);
        }
    }
}

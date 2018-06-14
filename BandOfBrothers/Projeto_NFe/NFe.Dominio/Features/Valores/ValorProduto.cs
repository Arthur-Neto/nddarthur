using NFe.Dominio.Base;
using NFe.Dominio.Features.Valores.Aliquotas;

namespace NFe.Dominio.Features.Valores
{
    public class ValorProduto : Imposto
    {
        public ValorProduto()
        {
            Aliquota = new Aliquota();
        }

        public decimal Total { get; set; }
        public decimal Unitario { get; set; }
        public Aliquota Aliquota { get; }

        public override void CalcularICMS()
        {
            ICMS = Total * Aliquota.ICMS;
        }

        public override void CalcularIpi()
        {
            Ipi = Total * Aliquota.Ipi;
        }
    }
}

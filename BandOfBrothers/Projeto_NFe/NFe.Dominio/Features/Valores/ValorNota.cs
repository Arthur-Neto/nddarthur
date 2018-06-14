using NFe.Dominio.Base;
using NFe.Dominio.Features.Valores.Aliquotas;

namespace NFe.Dominio.Features.Valores
{
    public class ValorNota : Imposto
    {
        public ValorNota()
        {
            Aliquota = new Aliquota();
        }

        public decimal Frete { get; set; }
        public decimal TotalProdutos { get; set; }
        private decimal _totalNota;
        public decimal TotalNota { get { return _totalNota; } set { _totalNota = value; } }
        private Aliquota Aliquota { get; }

        public void CalcularValorNota()
        {
            _totalNota = TotalProdutos + ICMS + Ipi + Frete;
        }

        public override void CalcularICMS()
        {
            ICMS = TotalProdutos * Aliquota.ICMS;
        }

        public override void CalcularIpi()
        {
            Ipi = TotalProdutos * Aliquota.Ipi;
        }
    }
}

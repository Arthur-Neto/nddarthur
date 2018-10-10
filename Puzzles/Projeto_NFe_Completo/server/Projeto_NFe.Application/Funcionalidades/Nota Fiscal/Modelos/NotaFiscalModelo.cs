using Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Funcionalidades.Notas_Fiscais.Modelos
{
    public class NotaFiscalModelo
    {
        public long Id { get; set; }
        public string Transportador { get; set; }
        public string Destinatario { get; set; }
        public string Emitente { get; set; }
        public string NaturezaOperacao { get; set; }
        public string DataEntrada { get; set; }
        public string DataEmissao { get; set; }
        public virtual List<ProdutoNotaFiscal> Produtos { get; set; }
        public virtual string ChaveAcesso { get; set; }
        public double ValorTotalICMS { get; set; }
        public double ValorTotalIPI { get; set; }
        public double ValorTotalProdutos { get; set; }
        public double ValorTotalFrete { get; set; }
        public double ValorTotalImpostos { get; set; }
        public double ValorTotalNota { get; set; }
    }
}

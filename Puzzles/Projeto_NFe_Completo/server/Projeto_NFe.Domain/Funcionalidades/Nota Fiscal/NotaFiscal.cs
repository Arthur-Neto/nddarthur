using Projeto_NFe.Domain.Base;
using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal
{
    public class NotaFiscal : Entidade
    {
        public virtual Transportador Transportador { get; set; }
        public long TransportadorId { get; set; }
        public virtual Destinatario Destinatario { get; set; }
        public long DestinatarioId { get; set; }
        public virtual Emitente Emitente { get; set; }
        public long EmitenteId { get; set; }
        public string NaturezaOperacao { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime? DataEmissao { get; set; }
        public virtual ICollection<ProdutoNotaFiscal> Produtos { get; set; }
        public virtual string ChaveAcesso { get; set; }
        public double ValorTotalICMS { get; set; }
        public double ValorTotalIPI { get; set; }
        public double ValorTotalProdutos { get; set; }
        public double ValorTotalFrete { get; set; }
        public double ValorTotalImpostos { get; set; }
        public double ValorTotalNota { get; set; }

        public NotaFiscal()
        {
            Produtos = new List<ProdutoNotaFiscal>();
        }

        public bool FoiEmitida {
            get
            {
                if (string.IsNullOrEmpty(ChaveAcesso))
                    return false;

                return true;
            }
        }

        public virtual void GerarChaveDeAcesso(Random sorteador)
        {
            ChaveAcesso = "";
            for (int i = 0; i < 44; i++)
            {
                ChaveAcesso += sorteador.Next(0, 10);
            }
        }

        public virtual void CalcularValoresTotais()
        {
            ValorTotalICMS = 0;
            ValorTotalIPI = 0;
            ValorTotalProdutos = 0;

            foreach (ProdutoNotaFiscal produtoNotaFiscal in Produtos)
            {
                ValorTotalICMS += produtoNotaFiscal.ValorICMS;
                ValorTotalIPI += produtoNotaFiscal.ValorIPI;
                ValorTotalProdutos += produtoNotaFiscal.ValorTotal;
            }

            ValorTotalImpostos = ValorTotalICMS + ValorTotalIPI;
            ValorTotalNota = ValorTotalFrete + ValorTotalImpostos + ValorTotalProdutos;
        }

        private void TransportadorReceberValoresDeDestinatario()
        {
            Transportador = new Transportador();

            Transportador.NomeRazaoSocial = Destinatario.NomeRazaoSocial;
            Transportador.InscricaoEstadual = Destinatario.InscricaoEstadual;
            Transportador.Documento = Destinatario.Documento;
            Transportador.Endereco = Destinatario.Endereco;
            Transportador.ResponsabilidadeFrete = true;
        }
    }
}

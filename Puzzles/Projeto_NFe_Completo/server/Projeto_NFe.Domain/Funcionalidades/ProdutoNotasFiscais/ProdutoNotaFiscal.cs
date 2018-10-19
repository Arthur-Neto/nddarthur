using Projeto_NFe.Domain.Base;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Funcionalidades.Produtos;

namespace Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais
{
    public class ProdutoNotaFiscal : Entidade
    {
        public long ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        public long NotaFiscalId { get; set; }
        public virtual NotaFiscal NotaFiscal { get; set; }

        public virtual int Quantidade { get; set; }

        public virtual double ValorTotal { get => Produto.Valor * Quantidade; private set { } }

        public virtual double ValorICMS { get => Produto.AliquotaICMS * ValorTotal; private set { } }

        public virtual double ValorIPI { get => Produto.AliquotaIPI * ValorTotal; private set { } }

        public ProdutoNotaFiscal(NotaFiscal notaFiscal, Produto produto, int quantidadeProduto)
        {
            NotaFiscal = notaFiscal;
            Produto = produto;
            Quantidade = quantidadeProduto;
        }

        public ProdutoNotaFiscal()
        {
        }
    }
}

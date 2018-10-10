using Projeto_NFe.Domain.Base;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais
{
    public class ProdutoNotaFiscal : Entidade
    {
        public Produto Produto { get; set; }
        public long ProdutoId { get; set; }

        public virtual NotaFiscal NotaFiscal { get; set; }
        public long NotaFiscalId { get; set; }
        public virtual int Quantidade { get; set; }

        public virtual double ValorTotal { get { return Produto.Valor * Quantidade; } }

        public virtual double ValorICMS { get { return Produto.AliquotaICMS * ValorTotal; } }

        public virtual double ValorIPI { get { return Produto.AliquotaIPI * ValorTotal; } }

        public ProdutoNotaFiscal(NotaFiscal notaFiscal, Produto produto, int quantidadeProduto)
        {
            NotaFiscal = notaFiscal;
            Produto = produto;
            Quantidade = quantidadeProduto;
        }
    }
}

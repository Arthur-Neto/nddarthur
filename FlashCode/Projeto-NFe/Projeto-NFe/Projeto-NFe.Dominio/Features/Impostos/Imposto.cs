using Projeto_NFe.Dominio.Base;
using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Dominio.Features.Impostos.Exceptions;
using Projeto_NFe.Dominio.Features.Produtos;
using System;

namespace Projeto_NFe.Dominio.Features.Impostos
{
    public class Imposto
    {
        public readonly double AliquotaIPI = 0.10;

        public readonly double AliquotaICMS = 0.04;

        public double ValorIPI { get; set; }
        public double ValorICMS { get; set; }

        public Imposto(ProdutoNfe produto)
        {
            Calcular(produto);
        }
        
        private void Calcular(ProdutoNfe Produto)
        {
            if (Produto == null)
                throw new ExcecaoProdutoNulo();

            this.ValorIPI = (Produto.ValorUnitario * Produto.Quantidade) * AliquotaIPI;
            this.ValorICMS = (Produto.ValorUnitario * Produto.Quantidade) * AliquotaICMS;
        }
    }
}

using Projeto_NFe.Dominio.Features.Impostos;
using Projeto_NFe.Dominio.Features.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Comuns.Testes.Features.ProdutosNFe
{
    public static class ProdutoNfeObjetoMae
    {
        public static List<ProdutoNfe> ObterListaDeProdutosNfe()
        {
            List<ProdutoNfe> listaProdutos = new List<ProdutoNfe>();

            ProdutoNfe nfe = new ProdutoNfe();
            nfe.ID = 1;
            nfe.Descricao = "Descrição produto 1";
            nfe.CodigoProduto = "111111";
            nfe.Quantidade = 11;
            nfe.ValorUnitario = 111;
            nfe.Imposto = new Imposto(nfe);
            nfe.Imposto.ValorICMS = 11111111;
            nfe.Imposto.ValorIPI = 1111;

            listaProdutos.Add(nfe);

            return listaProdutos;
        }

        public static ProdutoNfe ObterProdutoNfe()
        {
            ProdutoNfe nfe = new ProdutoNfe();
            nfe.ID = 1;
            nfe.ValorUnitario = 123;
            nfe.Quantidade = 12;
            nfe.Imposto = new Imposto(nfe);
            nfe.Imposto.ValorICMS = 12345.12;
            nfe.Imposto.ValorIPI = 2345.23;

            return nfe;
        }
    }
}

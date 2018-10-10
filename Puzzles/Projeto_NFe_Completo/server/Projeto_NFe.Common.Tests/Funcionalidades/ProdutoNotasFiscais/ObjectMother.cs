using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais;
using Projeto_NFe.Domain.Funcionalidades.Produtos;


namespace Projeto_NFe.Common.Tests.Funcionalidades
{
    public static partial class ObjectMother
    {
        public static ProdutoNotaFiscal PegarProdutoNotaFiscalValido(Produto produto, NotaFiscal notaFiscal)
        {
            int quantidadeDeProdutos = 10;
            return new ProdutoNotaFiscal(notaFiscal, produto, quantidadeDeProdutos);
           
        }

        public static ProdutoNotaFiscal PegarProdutoNotaFiscalComQuantidadeInferiorAumValido(Produto produto, NotaFiscal notaFiscal)
        {
            int quantidadeDeProdutos = 0;
            return new ProdutoNotaFiscal(notaFiscal, produto, quantidadeDeProdutos);

        }

        public static ProdutoNotaFiscal PegarProdutoNotaFiscalSemProdutoVinculadoValido(NotaFiscal notaFiscal)
        {
            int quantidadeDeProdutos = 1;
            return new ProdutoNotaFiscal(notaFiscal, null, quantidadeDeProdutos);

        }

        public static ProdutoNotaFiscal PegarProdutoNotaFiscalSemNotaFiscalVinculadaValido(Produto produto)
        {
            int quantidadeDeProdutos = 1;
            return new ProdutoNotaFiscal(null, produto, quantidadeDeProdutos);

        }
    }
}


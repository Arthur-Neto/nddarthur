using NFe.Dominio.Base;
using NFe.Dominio.Features.Valores;

namespace NFe.Dominio.Features.Produtos
{
    public class Produto : Entidade
    {
        public int CodigoProduto { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public ValorProduto ValorProduto { get; set; }

        public Produto()
        {
            ValorProduto = new ValorProduto();
        }

        public void CalcularValorTotal()
        {
            ValorProduto.Total = Quantidade * ValorProduto.Unitario;
        }
        
        public override void Validar()
        {
            if (CodigoProduto <= 0 )
                throw new ProdutoCodigoProdutoException();
            if (string.IsNullOrEmpty(Descricao))
                throw new ProdutoEmptyDescricaoException();
            if (Quantidade <= 0)
                throw new ProdutoQuantidadeException();
            if (ValorProduto.Unitario <= 0)
                throw new ProdutoValorUnitarioException();
        }
    }
}

using NFe.Dominio.Features.Produtos;
using NFe.Dominio.Features.Valores;

namespace NFe.Common.Testes.Features
{
    public static partial class ObjectMother
    {
        public static Produto ObtemProdutoValido()
        {
            return new Produto()
            {
                Id = 1,
                CodigoProduto = 12345,
                Descricao = "Mouse Optico",
                Quantidade = 1,
                ValorProduto = new ValorProduto()
                {
                    Unitario = 15.0m,
                }
            };
        }

        public static Produto ObtemProdutoDescricaoVazio()
        {
            return new Produto()
            {
                CodigoProduto = 12345,
                Quantidade = 1,
                ValorProduto = new ValorProduto()
                {
                    Unitario = 15.0m,
                }
            };
        }

        public static Produto ObtemCodigoProdutoIgualAZero()
        {
            return new Produto()
            {
                CodigoProduto = 0,
                Descricao = "Mouse Optico",
                Quantidade = 1,
                ValorProduto = new ValorProduto()
                {
                    Unitario = 15.0m,
                }
            };
        }

        public static Produto ObtemProdutoQuantidadeIgualAZero()
        {
            return new Produto()
            {
                CodigoProduto = 12345,
                Descricao = "Mouse Optico",
                Quantidade = 0,
                ValorProduto = new ValorProduto()
                {
                    Unitario = 15.0m,
                }
            };
        }

        public static Produto ObtemProdutoValorUnitarioZerado()
        {
            return new Produto()
            {
                CodigoProduto = 12345,
                Descricao = "Mouse Optico",
                Quantidade = 1,
                ValorProduto = new ValorProduto()
                {
                    Unitario = 0m,
                }
            };
        }

    }
}

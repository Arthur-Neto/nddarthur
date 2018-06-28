using Projeto_NFe.Dominio.Features.Impostos;
using Projeto_NFe.Dominio.Features.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Comuns.Testes.Features.Produtos
{
    public static class ProdutoObjetoMae
    {
        public static Produto ObterValido()
        {
            return new Produto
            {
                ID = 1,
                CodigoProduto = "123",
                Descricao = "descrição produto",
                ValorUnitario = 1
            };
        }
        public static Produto ObterValidoComIdZero()
        {
            return new Produto
            {
                ID = 0,
                CodigoProduto = "123",
                Descricao = "descrição produto",
                ValorUnitario = 1
            };
        }
        public static Produto ObterCodigoProdutoInvalido()
        {
            var produto = new Produto();
            produto.ID = 1;
            produto.CodigoProduto = "";
            produto.Descricao = "descrição produto";
            produto.ValorUnitario = 1;

            return produto;
        }

        public static Produto ObterDescricaoInvalida()
        {
            return new Produto
            {
                ID = 1,
                CodigoProduto = "123",
                Descricao = "",
                ValorUnitario = 1
            };
        }

        public static Produto ObterValorUnitarioInvalido()
        {
            var produto = new Produto();
            produto.ID = 1;
            produto.CodigoProduto = "123";
            produto.Descricao = "descrição produto";
            produto.ValorUnitario = 0;

            return produto;
        }
    }
}

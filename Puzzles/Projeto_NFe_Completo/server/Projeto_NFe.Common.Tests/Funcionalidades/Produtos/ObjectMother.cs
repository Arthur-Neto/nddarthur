using Projeto_NFe.Domain.Funcionalidades.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Common.Tests.Funcionalidades
{
    public static partial class ObjectMother
    {
        public static Produto ObterProdutoValido()
        {
            return new Produto()
            {
                Codigo = "123",
                Descricao = "Produto",
                Valor = 1
            };
        }
        public static Produto ObterProdutoComValorNegativo()
        {
            return new Produto()
            {
                Codigo = "12345",
                Descricao = "Produto",
                Valor = -2
            };
        }
        public static Produto ObterProdutoSemCodigo()
        {
            return new Produto()
            {
                Codigo = "",
                Descricao = "Produto",
                Valor = 1
            };
        }
        public static Produto ObterProdutoSemDescricao()
        {
            return new Produto()
            {
                Codigo = "12345",
                Descricao = "",
                Valor = 1
            };
        }
    }
}

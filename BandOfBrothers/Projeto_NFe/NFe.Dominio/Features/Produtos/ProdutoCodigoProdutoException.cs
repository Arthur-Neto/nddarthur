using NFe.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace NFe.Dominio.Features.Produtos
{
    [ExcludeFromCodeCoverage]
    public class ProdutoCodigoProdutoException : BusinessException
    {
        public ProdutoCodigoProdutoException() : base("O código do produto não deve ser menor que 0")
        {
        }
    }
}
using NFe.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace NFe.Dominio.Features.Produtos
{
    [ExcludeFromCodeCoverage]
    public class ProdutoValorUnitarioException : BusinessException
    {
        public ProdutoValorUnitarioException() : base("Valor unitario do produto não pode ser menor que 0")
        {
        }
    }
}
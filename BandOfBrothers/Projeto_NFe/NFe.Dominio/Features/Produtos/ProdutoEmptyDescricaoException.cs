using NFe.Dominio.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace NFe.Dominio.Features.Produtos
{
    [ExcludeFromCodeCoverage]
    public class ProdutoEmptyDescricaoException : BusinessException
    {
        public ProdutoEmptyDescricaoException() : base("Descrição do produto não pode ser vazio")
        {
        }
    }
}
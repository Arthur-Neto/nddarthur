
using Prova1.Domain.Products;
using System;
using System.Linq;

namespace Prova1.Domain.Features.Products
{
    /// <summary>
    /// Representa o repositório de products
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Retorna todas os products
        /// </summary>
        /// <returns>IQueriable com as products.</returns>
        IQueryable<Product> GetAll();

        /// <summary>
        /// Retorna os products conforme o tamanho informado
        /// </summary>
        /// <returns>IQueriable com as products.</returns>
        IQueryable<Product> GetAll(int size);

        /// <summary>
        /// Adiciona um Product
        /// </summary>
        /// <param name="product">Objeto Product com as suas propriedades preenchidas.</param>
        /// <returns>Product inserido com o id atualizado</returns>
        Product Add(Product product);

        /// <summary>
        /// Atualiza as propriedades de um Product.
        /// </summary>
        /// <param name="product">Product com suas propriedades atualizadas</param>
        bool Update(Product product);

        /// <summary>
        /// Retorna um determinado product 
        /// </summary>
        /// <param name="productId">Id da product a ser retornado</param>
        /// <returns>Objeto Product de ir correspondente.</returns>
        Product GetById(int productId);

        /// <summary>
        /// Remove um determinado product. 
        /// </summary>
        /// <param name="productId">Id do product a ser removido</param>
        bool Remove(int productId);
    }
}

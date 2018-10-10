using Prova1.Domain.Orders;
using System.Linq;

namespace Prova1.Domain.Features.Orders
{
    /// <summary>
    /// Representa o repositório de orders
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// Retorna todas as orders
        /// </summary>
        /// <returns>IQueriable com as orders.</returns>
        IQueryable<Order> GetAll();

        /// <summary>
        /// Retorna as orders conforme o tamanho informado em size
        /// </summary>
        /// <returns>IQueriable com as orders.</returns>
        IQueryable<Order> GetAll(int size);

        /// <summary>
        /// Adiciona uma Order
        /// </summary>
        /// <param name="order">Objeto Order com as suas propriedades preenchidas.</param>
        /// <returns>Order inserido com o id atualizado</returns>
        Order Add(Order order);

        /// <summary>
        /// Atualiza as propriedades de uma Order.
        /// </summary>
        /// <param name="order">Order com suas propriedades atualizadas</param>
        bool Update(Order order);

        /// <summary>
        /// Retorna uma determinada order 
        /// </summary>
        /// <param name="orderId">Id da order a ser retornado</param>
        /// <returns>Objeto Order de ir correspondente.</returns>
        Order GetById(int orderId);

        /// <summary>
        /// Remove uma determinada order. 
        /// </summary>
        /// <param name="orderId">Id da order a ser removido</param>
        bool Remove(int orderId);
    }
}

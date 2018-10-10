using Prova1.Domain.Exceptions;
using Prova1.Domain.Features.Orders;
using Prova1.Domain.Orders;
using Prova1.Infra.ORM.Contexts;
using System.Data.Entity;
using System.Linq;

namespace Prova1.Infra.ORM.Features.Orders
{
    /// <summary>
    /// Repositório de orders
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        private Prova1DbContext _context;

        public OrderRepository(Prova1DbContext context)
        {
            _context = context;
        }

        #region ADD

        /// <summary>
        /// Adiciona um novo order na base de dados
        /// </summary>
        // <param name="order">É o order que será adicionado da base de dados</param>
        /// <returns>Retorna o novo order com os atributos atualizados (como id)</returns>
        public Order Add(Order order)
        {
            // Indexamos o produto no context do EF
            // Isso evita que o EF adicione um novo produto caso o order.Product tenha id inválido
            // Estamos considerando que o produto deve ser pré-cadastrado.
            _context.Products.Attach(order.Product);
            // Adiciona a nova order
            var newOrder = _context.Orders.Add(order);
            // Salva no banco
            _context.SaveChanges();
            // Retorna a nova order com id atualizado
            return newOrder;
        }

        #endregion

        #region GET

        public IQueryable<Order> GetAll()
        {
            return _context.Orders.Include(o => o.Product);
        }

        public IQueryable<Order> GetAll(int size)
        {
            return _context.Orders.Include(o => o.Product).Take(size);
        }

        public Order GetById(int productId)
        {
            return _context.Orders.Include(or => or.Product).FirstOrDefault(c => c.Id == productId);
        }

        #endregion

        #region REMOVE

        public bool Remove(int orderId)
        {
            var order = _context.Orders.Where(o => o.Id == orderId).FirstOrDefault();
            if (order == null)
                throw new NotFoundException();
            _context.Entry(order).State = EntityState.Deleted;
            return _context.SaveChanges() > 0;
        }

        #endregion

        #region UPDATE
        public bool Update(Order order)
        {
            // Altera o estado
            _context.Entry(order).State = EntityState.Modified;
            // Salva mudanças
            return _context.SaveChanges() > 0;
        }
        #endregion
    }
}

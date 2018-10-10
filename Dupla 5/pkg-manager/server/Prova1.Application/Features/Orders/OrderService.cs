using AutoMapper;
using Prova1.Application.Features.Orders.Commands;
using Prova1.Application.Features.Orders.Queries;
using Prova1.Application.Features.Orders.ViewModels;
using Prova1.Domain.Exceptions;
using Prova1.Domain.Features.Orders;
using Prova1.Domain.Features.Products;
using Prova1.Domain.Orders;
using System;
using System.Linq;

namespace Prova1.Application.Features.Orders
{
    /// <summary>
    /// Serviço de gerenciamento de orders
    /// </summary>
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repositoryOrder;
        private readonly IProductRepository _repositoryProduct;


        public OrderService(IOrderRepository repositoryOrder, IProductRepository repositoryProduct)
        {
            _repositoryOrder = repositoryOrder;
            _repositoryProduct = repositoryProduct;
        }

        public int Add(OrderRegisterCommand orderCmd)
        {
            var order = Mapper.Map<OrderRegisterCommand, Order>(orderCmd);
            // obtém a entidade do banco
            order.Product = _repositoryProduct.GetById(orderCmd.ProductId) ?? throw new NotFoundException();
            var neworder = _repositoryOrder.Add(order);

            return neworder.Id;
        }

        public bool Remove(OrderRemoveCommand cmd)
        {
            var isRemovedAll = true;
            foreach (var orderId in cmd.OrderIds)
            {
                var isRemoved = _repositoryOrder.Remove(orderId);
                // Aqui poderia dar o tramento adequado, armazenado quais ids foram removidos
                // e quais não forma removidos (e buscar o porquê). 
                // Como é somente um exemplo, vamos somente retornar false (que não foi totalmente concluído)
                isRemovedAll = isRemoved ? isRemovedAll : false;
            }
            return isRemovedAll;
        }

        public IQueryable<Order> GetAll()
        {
            return _repositoryOrder.GetAll();
        }

        public IQueryable<Order> GetAll(OrderQuery query)
        {
            return _repositoryOrder.GetAll(query.Size);
        }

        public Order GetById(int id)
        {
            var updatedOrder = _repositoryOrder.GetById(id);

            return updatedOrder;
        }

        public bool Update(OrderUpdateCommand orderCmd)
        {
            // Obtém a entidade Indexada pelo EF e valida
            var orderDb = _repositoryOrder.GetById(orderCmd.Id) ?? throw new NotFoundException();
            var product = _repositoryProduct.GetById(orderCmd.ProductId) ?? throw new NotFoundException();
            // Mapeia para o objeto do banco
            Mapper.Map<OrderUpdateCommand, Order>(orderCmd, orderDb);
            orderDb.Product = product;
            // Realiza o update no objeto do banco
            return _repositoryOrder.Update(orderDb);
        }
    }
}
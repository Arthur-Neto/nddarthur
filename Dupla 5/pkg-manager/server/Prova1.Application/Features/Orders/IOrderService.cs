using Prova1.Application.Features.Orders.Commands;
using Prova1.Application.Features.Orders.Queries;
using Prova1.Application.Features.Orders.ViewModels;
using Prova1.Domain.Orders;
using System.Linq;

namespace Prova1.Application.Features.Orders
{
    public interface IOrderService
    {
         int Add(OrderRegisterCommand order);

        bool Update(OrderUpdateCommand order);

        Order GetById(int id);

        IQueryable<Order>  GetAll();

        IQueryable<Order> GetAll(OrderQuery query);

        bool Remove(OrderRemoveCommand cmd);
    }
}

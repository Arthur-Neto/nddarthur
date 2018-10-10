using AutoMapper;
using Prova1.Application.Features.Orders.Commands;
using Prova1.Application.Features.Orders.Queries;
using Prova1.Application.Features.Orders.ViewModels;
using Prova1.Domain.Orders;

namespace Prova1.Application.Features.Orders
{
    /// <summary>
    /// 
    ///  Realiza o mapeamento entre o Command/Query e a entidade de domínio Order
    ///  
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderRegisterCommand, Order>();
            CreateMap<Order, OrderViewModel>()
                .ForMember(oq => oq.ProductName, mo => mo.MapFrom(o => o.Product.Name))
                .ForMember(oq => oq.ProductId, mo => mo.MapFrom(o => o.Product.Id))
                .ForMember(oq => oq.Total, mo => mo.MapFrom(o => o.Total));
            CreateMap<OrderUpdateCommand, Order>();
        }
    }
}

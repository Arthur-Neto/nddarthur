using AutoMapper;
using Prova1.Application.Features.Products.Commands;
using Prova1.Application.Features.Products.ViewModels;
using Prova1.Domain.Products;

namespace Prova1.Application.Features.Products
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductRegisterCommand, Product>();
            CreateMap<Product, ProductViewModel>()
                .ForMember(p => p.Manufacture, mc => mc.MapFrom(pq => pq.Manufacture.ToString("yyyy-MM-ddTHH:mm:ssZ")))
                .ForMember(p => p.Expiration, mc => mc.MapFrom(pq => pq.Expiration.ToString("yyyy-MM-ddTHH:mm:ssZ")));
            CreateMap<ProductUpdateCommand, Product>();
        }
    }
}

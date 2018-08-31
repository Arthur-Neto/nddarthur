using Arthur.MF7.Application.Features.Spendings.Commands;
using Arthur.MF7.Application.Features.Spendings.ViewModels;
using Arthur.MF7.Domain.Features.Spendings;
using AutoMapper;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Arthur.MF7.Application.Features.Spendings
{
    [ExcludeFromCodeCoverage]
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Spending, SpendingViewModel>()
                .ForMember(dest => dest.EmployeeName, m => m.MapFrom(src => src.Employee.FirstName + " " + src.Employee.LastName));
            CreateMap<List<Spending>, List<SpendingViewModel>>();
            CreateMap<SpendingRegisterCommand, Spending>();
            CreateMap<SpendingRemoveCommand, Spending>();
        }
    }
}

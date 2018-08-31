using Arthur.MF7.Application.Features.Employees.Commands;
using Arthur.MF7.Application.Features.Employees.ViewModels;
using Arthur.MF7.Domain.Features.Employees;
using AutoMapper;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Arthur.MF7.Application.Features.Employees
{
    [ExcludeFromCodeCoverage]
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeViewModel>()
                .ForMember(dest => dest.FullName, m => m.MapFrom(src => src.FirstName + " " + src.LastName))
                .ForMember(dest => dest.Username, m => m.MapFrom(src => src.User.Username));
            CreateMap<List<Employee>, List<EmployeeViewModel>>();
            CreateMap<EmployeeRegisterCommand, Employee>()
                .ForPath(dest => dest.User.Username, m => m.MapFrom(src => src.Username))
                .ForPath(dest => dest.User.Password, m => m.MapFrom(src => src.Password));
            CreateMap<EmployeeUpdateCommand, Employee>();
            CreateMap<EmployeeRemoveCommand, Employee>();
            CreateMap<Employee, EmployeeRegisterCommand>()
                .ForMember(dest => dest.Username, m => m.MapFrom(src => src.User.Username))
                .ForMember(dest => dest.Password, m => m.MapFrom(src => src.User.Password));
            CreateMap<Employee, EmployeeRemoveCommand>();
            CreateMap<Employee, EmployeeUpdateCommand>();
        }
    }
}

using AutoMapper;
using Bank.Application.Features.Accounts.Commands;
using Bank.Application.Features.Accounts.ViewModels;
using Bank.Domain.Features.Accounts;
using System.Collections.Generic;

namespace Bank.Application.Features.Accounts
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CheckingAccount, CheckingAccountExtractViewModel>().ForMember(dest => dest.Name, m => m.MapFrom(src => src.Client.Name));
            CreateMap<CheckingAccount, CheckingAccountViewModel>();
            CreateMap<List<CheckingAccount>, List<CheckingAccountViewModel>>();
            CreateMap<CheckingAccountRegisterCommand, CheckingAccount>();
            CreateMap<CheckingAccountUpdateCommand, CheckingAccount>();
            CreateMap<CheckingAccountRemoveCommand, CheckingAccount>();
        }
    }
}

using AutoMapper;
using Bank.Application.Features.Clients.Commands;
using Bank.Application.Features.Clients.ViewModels;
using Bank.Domain.Features.Clients;

namespace Bank.Application.Features.Clients
{
    public class MappingProfile :  Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, ClientViewModel>();
            CreateMap<ClientRegisterCommand, Client>();
            CreateMap<ClientUpdateCommand, Client>();
        }
    }
}

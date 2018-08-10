using AutoMapper;
using Bank.Application.Features.Transactions.ViewModels;
using Bank.Domain.Features.Transactions;

namespace Bank.Application.Features.Transactions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Transaction, TransactionViewModel>();
        }
    }
}

using AutoMapper;
using Bank.Application.Features.Transactions.ViewModels;
using Bank.Domain.Features.Transactions;
using System.Diagnostics.CodeAnalysis;

namespace Bank.Application.Features.Transactions
{
    [ExcludeFromCodeCoverage]
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Transaction, TransactionViewModel>();
        }
    }
}

using Arthur.MF7.Domain.Base;

namespace Arthur.MF7.Domain.Features.Spendings
{
    public interface ISpendingRepository : IRepository<Spending>
    {
        bool EmployeeWithSpending(long id);
    }
}

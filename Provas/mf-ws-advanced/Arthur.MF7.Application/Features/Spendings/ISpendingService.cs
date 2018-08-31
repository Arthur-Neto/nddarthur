using Arthur.MF7.Application.Features.Spendings.Commands;
using Arthur.MF7.Domain.Features.Spendings;
using System.Linq;

namespace Arthur.MF7.Application.Features.Spendings
{
    public interface ISpendingService
    {
        long Add(SpendingRegisterCommand cmd);

        Spending GetById(long id);

        IQueryable<Spending> GetAll();

        bool Remove(SpendingRemoveCommand cmd);
    }
}

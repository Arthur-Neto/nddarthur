using Arthur.MF7.Application.Features.Spendings.Commands;
using Arthur.MF7.Domain.Exceptions;
using Arthur.MF7.Domain.Features.Employees;
using Arthur.MF7.Domain.Features.Spendings;
using AutoMapper;
using System.Linq;

namespace Arthur.MF7.Application.Features.Spendings
{
    public class SpendingService : ISpendingService
    {
        private ISpendingRepository _repositorySpending;
        private IEmployeeRepository _repositoryEmployee;

        public SpendingService(ISpendingRepository repositorySpending, IEmployeeRepository repositoryEmployee)
        {
            _repositorySpending = repositorySpending;
            _repositoryEmployee = repositoryEmployee;
        }

        public long Add(SpendingRegisterCommand cmd)
        {
            Employee employee = _repositoryEmployee.GetById(cmd.EmployeeId) ?? throw new NotFoundException();

            Spending spending = Mapper.Map<SpendingRegisterCommand, Spending>(cmd);
            spending.Employee = employee;

            Spending newSpending = _repositorySpending.Add(spending);

            return newSpending.Id;
        }

        public IQueryable<Spending> GetAll()
        {
            return _repositorySpending.GetAll();
        }

        public Spending GetById(long id)
        {
            if (id < 1)
            {
                throw new NotFoundException();
            }

            Spending spending = _repositorySpending.GetById(id) ?? throw new NotFoundException();

            return spending;
        }

        public bool Remove(SpendingRemoveCommand cmd)
        {
            Spending spendingDb = _repositorySpending.GetById(cmd.Id) ?? throw new NotFoundException();

            return _repositorySpending.Remove(spendingDb);
        }
    }
}

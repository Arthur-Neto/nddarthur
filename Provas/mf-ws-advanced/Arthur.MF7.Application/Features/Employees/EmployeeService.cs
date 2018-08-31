using Arthur.MF7.Application.Features.Employees.Commands;
using Arthur.MF7.Domain.Exceptions;
using Arthur.MF7.Domain.Features.Employees;
using Arthur.MF7.Domain.Features.Spendings;
using Arthur.MF7.Infra.Crypto;
using AutoMapper;
using System.Linq;

namespace Arthur.MF7.Application.Features.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _repositoryEmployee;
        private readonly ISpendingRepository _repositorySpending;

        public EmployeeService(IEmployeeRepository repositoryEmployee, ISpendingRepository repositorySpending)
        {
            _repositoryEmployee = repositoryEmployee;
            _repositorySpending = repositorySpending;
        }

        public long Add(EmployeeRegisterCommand cmd)
        {
            Employee employee = Mapper.Map<EmployeeRegisterCommand, Employee>(cmd);

            employee.User.Password = employee.User.Password.GenerateHash();

            Employee newEmployee = _repositoryEmployee.Add(employee);

            return newEmployee.Id;
        }

        public IQueryable<Employee> GetAll()
        {
            return _repositoryEmployee.GetAll();
        }

        public Employee GetById(long id)
        {
            if (id < 1)
            {
                throw new NotFoundException();
            }

            Employee employee = _repositoryEmployee.GetById(id) ?? throw new NotFoundException();

            return employee;
        }

        public bool Remove(EmployeeRemoveCommand cmd)
        {
            Employee employeeDb = _repositoryEmployee.GetById(cmd.Id) ?? throw new NotFoundException();

            if (_repositorySpending.EmployeeWithSpending(cmd.Id))
            {
                employeeDb.IsActive = false;
                _repositoryEmployee.Update(employeeDb);
                return false;
            }

            return _repositoryEmployee.Remove(employeeDb);
        }

        public bool Update(EmployeeUpdateCommand cmd)
        {
            Employee employeeDb = _repositoryEmployee.GetById(cmd.Id) ?? throw new NotFoundException();

            Employee employee = Mapper.Map(cmd, employeeDb);

            return _repositoryEmployee.Update(employee);
        }
    }
}

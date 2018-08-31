using Arthur.MF7.Application.Features.Employees.Commands;
using Arthur.MF7.Domain.Features.Employees;
using System.Linq;

namespace Arthur.MF7.Application.Features.Employees
{
    public interface IEmployeeService
    {
        long Add(EmployeeRegisterCommand cmd);

        bool Update(EmployeeUpdateCommand cmd);

        Employee GetById(long id);

        IQueryable<Employee> GetAll();

        bool Remove(EmployeeRemoveCommand cmd);
    }
}

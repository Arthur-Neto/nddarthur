using Arthur.MF7.Domain.Exceptions;
using Arthur.MF7.Domain.Features.Employees;
using Arthur.MF7.Infra.ORM.Base;
using System.Data.Entity;
using System.Linq;

namespace Arthur.MF7.Infra.ORM.Features.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        protected MF7Context _context;

        public EmployeeRepository(MF7Context context)
        {
            _context = context;
        }

        public Employee Add(Employee employee)
        {
            Employee newEmployee = _context.Employees.Add(employee);
            _context.SaveChanges();
            return newEmployee;
        }

        public IQueryable<Employee> GetAll()
        {
            return _context.Set<Employee>();
        }

        public Employee GetById(long id)
        {
            return _context.Employees.FirstOrDefault(e => e.Id == id);
        }

        public bool Remove(Employee employee)
        {
            Employee getEmployee = _context.Employees.Where(e => e.Id == employee.Id).FirstOrDefault();
            if (getEmployee == null)
            {
                throw new NotFoundException();
            }

            _context.Employees.Remove(getEmployee);
            return _context.SaveChanges() > 0;
        }

        public bool Update(Employee employee)
        {
            _context.Entry<Employee>(employee).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }
    }
}

using Arthur.MF7.Domain.Exceptions;
using Arthur.MF7.Domain.Features.Spendings;
using Arthur.MF7.Infra.ORM.Base;
using System.Data.Entity;
using System.Linq;

namespace Arthur.MF7.Infra.ORM.Features.Spendings
{
    public class SpendingRepository : ISpendingRepository
    {
        protected MF7Context _context;

        public SpendingRepository(MF7Context context)
        {
            _context = context;
        }

        public Spending Add(Spending spending)
        {
            Spending newSpending = _context.Spendings.Add(spending);
            _context.SaveChanges();
            return newSpending;
        }

        public IQueryable<Spending> GetAll()
        {
            return _context.Spendings;
        }

        public Spending GetById(long id)
        {
            return _context.Spendings.FirstOrDefault(e => e.Id == id);
        }

        public bool EmployeeWithSpending(long id)
        {
            var employee = _context.Spendings.FirstOrDefault(s => s.Employee.Id == id);
            if (employee == null)
                return false;
            else
                return true;
        }

        public bool Remove(Spending spending)
        {
            Spending getSpending = _context.Spendings.Where(e => e.Id == spending.Id).FirstOrDefault();
            if (getSpending == null)
            {
                throw new NotFoundException();
            }

            _context.Spendings.Remove(getSpending);
            return _context.SaveChanges() > 0;
        }

        public bool Update(Spending spending)
        {
            _context.Entry<Spending>(spending).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }
    }
}

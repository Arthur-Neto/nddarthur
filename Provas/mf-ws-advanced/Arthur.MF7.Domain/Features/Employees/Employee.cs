using Arthur.MF7.Domain.Base;
using Arthur.MF7.Domain.Features.Users;

namespace Arthur.MF7.Domain.Features.Employees
{
    public class Employee : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public User User { get; set; }
        public string Position { get; set; }
        public bool IsActive { get; set; }
    }
}

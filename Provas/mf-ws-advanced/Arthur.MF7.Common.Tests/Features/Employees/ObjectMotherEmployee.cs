using Arthur.MF7.Domain.Features.Employees;
using Arthur.MF7.Domain.Features.Users;

namespace Arthur.MF7.Common.Tests.Features
{
    public static partial class ObjectMother
    {
        public static Employee GetValidEmployee()
        {
            return new Employee()
            {
                FirstName = "Fulano",
                IsActive = true,
                LastName = "ASDASDA",
                Position = "xxxx",
                User = new User()
                {
                    Password = "test",
                    Username = "test"
                }
            };
        }
    }
}

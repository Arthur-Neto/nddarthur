using Bank.Domain.Exceptions;
using Bank.Domain.Features.Users;
using Bank.Infra.Data.Base;
using System.Linq;

namespace Bank.Infra.Data.Features.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly BankContext _context;

        public UserRepository(BankContext context)
        {
            _context = context;
        }

        public User GetUser(string username, string password)
        {
            var user = this._context.Users.FirstOrDefault(u => u.Username.Equals(username) && u.Password == password) ?? throw new InvalidCredentialsException();
            return user;
        }
    }
}

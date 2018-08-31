using Arthur.MF7.Domain.Exceptions;
using Arthur.MF7.Domain.Features.Users;
using Arthur.MF7.Infra.ORM.Base;
using System.Linq;

namespace Arthur.MF7.Infra.ORM.Features.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly MF7Context _context;

        public UserRepository(MF7Context context)
        {
            _context = context;
        }

        public User GetUser(string username, string password)
        {
            User user = _context.Users.FirstOrDefault(u => u.Username.Equals(username) && u.Password == password) ?? throw new InvalidCredentialsException();
            return user;
        }
    }
}

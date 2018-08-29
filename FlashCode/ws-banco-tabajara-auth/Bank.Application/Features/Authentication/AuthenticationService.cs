using Bank.Domain.Features.Users;
using Bank.Infra.Crypto;

namespace Bank.Application.Features.Authentication
{
    public class AuthenticationService
    {
        private IUserRepository _userRepository;

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Login(string username, string password)
        {
            password = password.GenerateHash();
            return _userRepository.GetUser(username, password);
        }
    }
}

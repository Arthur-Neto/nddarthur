using Arthur.MF7.Domain.Features.Users;
using Arthur.MF7.Infra.Crypto;

namespace Arthur.MF7.Application.Features.Authentication
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

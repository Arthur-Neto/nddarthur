using Arthur.MF7.Domain.Base;

namespace Arthur.MF7.Domain.Features.Users
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

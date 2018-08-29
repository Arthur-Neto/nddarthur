using Bank.Domain.Base;

namespace Bank.Domain.Features.Users
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

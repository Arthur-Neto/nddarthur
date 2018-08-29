namespace Bank.Domain.Features.Users
{
    public interface IUserRepository
    {
        User GetUser(string username, string password);
    }
}

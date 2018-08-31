namespace Arthur.MF7.Domain.Features.Users
{
    public interface IUserRepository
    {
        User GetUser(string username, string password);
    }
}

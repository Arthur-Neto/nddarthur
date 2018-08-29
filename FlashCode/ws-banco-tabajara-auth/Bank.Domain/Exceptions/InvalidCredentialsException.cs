namespace Bank.Domain.Exceptions
{
    public class InvalidCredentialsException : BusinessException
    {
        public InvalidCredentialsException() : base(ErrorCodes.Unauthorized, "The user name or password is incorrect") { }
    }
}

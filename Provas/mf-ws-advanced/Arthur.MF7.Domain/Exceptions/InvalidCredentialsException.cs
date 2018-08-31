using System.Diagnostics.CodeAnalysis;

namespace Arthur.MF7.Domain.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class InvalidCredentialsException : BusinessException
    {
        public InvalidCredentialsException() : base(ErrorCodes.Unauthorized, "The user name or password is incorrect") { }
    }
}

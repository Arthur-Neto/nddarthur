using System.Diagnostics.CodeAnalysis;

namespace Arthur.MF7.Domain.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class InvalidObjectException : BusinessException
    {
        public InvalidObjectException() : base(ErrorCodes.InvalidObject, "This object is invalid") { }
    }
}

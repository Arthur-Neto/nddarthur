using System.Diagnostics.CodeAnalysis;

namespace Arthur.MF7.Domain.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class AlreadyExistsException : BusinessException
    {
        public AlreadyExistsException() : base(ErrorCodes.AlreadyExists, "This registry already exists") { }
    }
}

using System.Diagnostics.CodeAnalysis;

namespace Arthur.MF7.Domain.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class NotAllowedException : BusinessException
    {
        public NotAllowedException() : base(ErrorCodes.NotAllowed, "Operation not allowed") { }
    }
}

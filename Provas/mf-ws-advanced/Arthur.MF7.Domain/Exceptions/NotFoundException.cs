using System.Diagnostics.CodeAnalysis;

namespace Arthur.MF7.Domain.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class NotFoundException : BusinessException
    {
        public NotFoundException() : base(ErrorCodes.NotFound, "Registry not found") { }
    }
}

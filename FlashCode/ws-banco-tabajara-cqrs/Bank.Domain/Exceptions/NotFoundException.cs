using System.Diagnostics.CodeAnalysis;

namespace Bank.Domain.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class NotFoundException : BusinessException
    {
        public NotFoundException() : base(ErrorCodes.NotFound, "Registry not found") { }
    }
}

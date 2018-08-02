using System.Diagnostics.CodeAnalysis;

namespace MF6.Domain.Exceptions {

    [ExcludeFromCodeCoverage]
    public class NotFoundException : BusinessException {

        public NotFoundException() : base(ErrorCodes.NotFound, "Registry not found") {
        }
    }
}
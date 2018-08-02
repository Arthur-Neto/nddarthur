using System.Diagnostics.CodeAnalysis;

namespace MF6.Domain.Exceptions {

    [ExcludeFromCodeCoverage]
    public class NotAllowedException : BusinessException {

        public NotAllowedException() : base(ErrorCodes.NotAllowed, "Operation not allowed") {
        }
    }
}
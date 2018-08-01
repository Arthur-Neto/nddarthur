using System.Diagnostics.CodeAnalysis;

namespace MF6.Domain.Exceptions {

    [ExcludeFromCodeCoverage]
    public class InvalidObjectException : BusinessException {

        public InvalidObjectException() : base(ErrorCodes.InvalidObject, "This object is invalid") {
        }
    }
}
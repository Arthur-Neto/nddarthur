using System;
using System.Diagnostics.CodeAnalysis;

namespace Arthur.MF7.Domain.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class BusinessException : Exception
    {
        public BusinessException(ErrorCodes errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }

        public ErrorCodes ErrorCode { get; }
    }
}

using System;

namespace MF6.Domain.Exceptions {

    public class BusinessException : Exception {

        public BusinessException(ErrorCodes errorCode, string message) : base(message) {
            ErrorCode = errorCode;
        }

        public ErrorCodes ErrorCode { get; }
    }
}
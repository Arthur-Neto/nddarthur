using MF6.Domain.Exceptions;
using System;

namespace MF6.API.Exceptions {

    /// <summary>
    ///  Classe que representa uma exceção lançada para o client como resposta.
    ///</summary>
    public class ExceptionPayload {
        public int ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        public static ExceptionPayload New<T>(T exception) where T : Exception {
            int errorCode;
            if (exception is BusinessException)
                errorCode = (exception as BusinessException).ErrorCode.GetHashCode();
            else
                errorCode = ErrorCodes.Unhandled.GetHashCode();
            return new ExceptionPayload {
                ErrorCode = errorCode,
                ErrorMessage = exception.Message,
            };
        }
    }
}
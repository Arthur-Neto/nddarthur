using System;

namespace Exemplo.Dominio.Exceptions {
    public class BusinessException : Exception {
        public BusinessException(string message) : base(message) {
        }
    }
}

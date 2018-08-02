using System;

namespace Arthur.ORM.Dominio.Exceptions {
    public class BusinessException : Exception {
        public BusinessException(string message) : base(message) {
        }
    }
}

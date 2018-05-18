using System;

namespace Mariana.Dominio.Exceptions
{
    public class ValidacaoException : Exception
    {
        public ValidacaoException()
        {
        }

        public ValidacaoException(string message) : base(message)
        {
        }

        public ValidacaoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

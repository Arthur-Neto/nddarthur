using System;

namespace ArthurProva.Domain.Exceptions
{
    public class ValidacaoException : Exception
    {
        public ValidacaoException(string message) : base(message)
        {
        }
    }
}

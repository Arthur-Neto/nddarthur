using System;
using System.Runtime.Serialization;

namespace Mariana.Dominio.Exceptions.Disciplina
{
    public class DuplicadaException : Exception
    {
        public DuplicadaException()
        {

        }

        public DuplicadaException(string message) : base(message)
        {

        }

        public DuplicadaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicadaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

using System;

namespace Mariana.Dominio.Exceptions.Disciplina
{
    public class ListaVaziaException : Exception
    {
        public ListaVaziaException()
        {
        }

        public ListaVaziaException(string message) : base(message)
        {
        }

        public ListaVaziaException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

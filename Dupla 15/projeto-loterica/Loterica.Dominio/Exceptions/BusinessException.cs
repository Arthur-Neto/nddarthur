using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loterica.Dominio.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException() : base("Erro na validação")
        {
        }

        public BusinessException(string message) : base(message)
        {
        }
    }
}

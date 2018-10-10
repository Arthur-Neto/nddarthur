using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova1.Domain.Exceptions
{
    /// <summary>
    /// Representa uma exceção de negócio. 
    /// É a classe base para a implementação de exceções de negócio. 
    /// 
    /// </summary>
    public class BusinessException : Exception
    {
        public BusinessException(ErrorCodes errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }

        public ErrorCodes ErrorCode { get; }
    }
}

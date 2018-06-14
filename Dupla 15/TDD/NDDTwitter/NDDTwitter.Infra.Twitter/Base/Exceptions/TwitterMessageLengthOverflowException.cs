using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTwitter.Infra.Twitter.Base.Exceptions
{
    public class TwitterMessageLengthOverflowException : Exception
    {
        public TwitterMessageLengthOverflowException() : base("A mensagem não deve conter mais que 140 caracteres")
        {
        }
    }
}

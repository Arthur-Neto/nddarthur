using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTwitter.Infra.Twitter.Base.Exceptions
{
    public class TwitterMessageEmptyException : Exception
    {
        public TwitterMessageEmptyException() : base("A mensagem não pode ser vazia ou conter espaços em branco")
        {
        }
    }
}

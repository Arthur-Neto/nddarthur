using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTwitter.Infra.Twitter.Base.Exceptions
{
    public class TwitterMessageIdentifierUndefinedException : Exception
    {
        public TwitterMessageIdentifierUndefinedException() : base("O id não pode ser negativo")
        {
        }
    }
}

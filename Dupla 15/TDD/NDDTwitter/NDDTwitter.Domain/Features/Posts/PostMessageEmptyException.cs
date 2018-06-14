using NDDTwitter.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTwitter.Domain.Features.Posts
{
    public class PostMessageEmptyException : BusinessException
    {
        public PostMessageEmptyException() : base("A mensagem não deve ser vazia")
        {
        }
    }
}

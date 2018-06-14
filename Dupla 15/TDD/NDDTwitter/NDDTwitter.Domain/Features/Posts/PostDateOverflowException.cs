using NDDTwitter.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTwitter.Domain.Features.Posts
{
    public class PostDateOverflowException : BusinessException
    {
        public PostDateOverflowException() : base("A data de criação da mensagem não pode ser maior que a data atual")
        {
        }
    }
}

using NDDTwitter.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NDDTwitter.Domain.Features.Posts
{
    public class Post
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public DateTime PostDate { get; set; }
        public string DisplayPostDate { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(this.Message))
                throw new PostMessageEmptyException();
            if (this.Message.Length > 140)
                throw new PostMessageOverflowException();
            if (this.PostDate > DateTime.Now)
                throw new PostDateOverflowException();
        }
    }
}

using NDDTwitter.Domain.Features.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTwitter.Application.Features.Posts
{
    public interface IPostService
    {
        Post Add(Post post);
        Post Update(Post post);
        Post Get(long id);
        IEnumerable<Post> GetAll();
        void Delete(Post post);
    }
}

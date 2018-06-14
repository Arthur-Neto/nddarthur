using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NDDTwitter.Domain.Exceptions;
using NDDTwitter.Domain.Features.Posts;

namespace NDDTwitter.Application.Features.Posts
{
    public class PostService : IPostService
    {
        private IPostRepository _repositorio;

        public PostService(IPostRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public Post Add(Post post)
        {
            try
            {
                post.Validate();
                return _repositorio.Save(post);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Delete(Post post)
        {
            try
            {
                if (post.Id == 0)
                    throw new IdentifierUndefinedException();
                _repositorio.Delete(post);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public Post Get(long id)
        {
            try
            {
                if (id == 0)
                    throw new IdentifierUndefinedException();
                return _repositorio.Get(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Post> GetAll()
        {
            try
            {
                return _repositorio.GetAll();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public Post Update(Post post)
        {
            if (post.Id == 0)
                throw new IdentifierUndefinedException();
            try
            {
                post.Validate();
                return _repositorio.Update(post);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

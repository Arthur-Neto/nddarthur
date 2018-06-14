using NDDTwitter.Domain.Exceptions;
using NDDTwitter.Domain.Features.Posts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTwitter.Infra.Data.Features.Posts
{
    public class PostRepository : IPostRepository
    {
        #region Querys
        private const string _insert = @"INSERT INTO Posts (Message, PostDate) VALUES (@Message, @PostDate);";

        private const string _getAll = @"SELECT * FROM Posts";

        private const string _getById = @"SELECT * FROM Posts WHERE Id = @Id";

        private const string _update = @"UPDATE Posts SET Message = @Message, PostDate = @PostDate WHERE Id = @Id";

        private const string _delete = @"DELETE FROM Posts WHERE Id = @Id";
        #endregion

        public void Delete(Post post)
        {
            if (post.Id == 0)
                throw new IdentifierUndefinedException();

            Db.Delete(_delete, Take(post));
        }

        public Post Get(long id)
        {
            if (id == 0)
                throw new IdentifierUndefinedException();

            return Db.Get(_getById, Make, new object[] { "@Id", id });
            
        }

        public IEnumerable<Post> GetAll()
        {
            return Db.GetAll(_getAll, Make);
        }

        public Post Save(Post post)
        {
            post.Validate();
            post.Id = Db.Insert(_insert, Take(post));
            return Get(post.Id);
        }

        public Post Update(Post post)
        {
            post.Validate();
            if (post.Id == 0)
                throw new IdentifierUndefinedException();
            Db.Update(_update, Take(post));
            return Get(post.Id);
        }

        /// <summary>
        /// Cria um objeto Customer baseado no DataReader.
        /// </summary>
        private static Func<IDataReader, Post> Make = reader =>
           new Post
           {
               Id = Convert.ToInt64(reader["Id"]),
               Message = reader["Message"].ToString(),
               PostDate = Convert.ToDateTime(reader["PostDate"])
           };

        /// <summary>
        /// Cria a lista de parametros do objeto Post para passar para o comando Sql
        /// </summary>
        /// <param name="post">Post.</param>
        /// <returns>lista de parametros</returns>
        private object[] Take(Post post)
        {
            return new object[]
            {
                "@Id", post.Id,
                "@Message", post.Message,
                "@PostDate", post.PostDate
            };
        }
    }
}

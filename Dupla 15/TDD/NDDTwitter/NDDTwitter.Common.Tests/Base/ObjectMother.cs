using NDDTwitter.Domain.Features.Posts;
using NDDTwitter.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDDTwitter.Common.Tests.Base
{
    public static class ObjectMother
    {
        public static Post GetPost()
        {
            return new Post()
            {
                Id = 1,
                Message = "asd",
                PostDate = DateTime.Now
            };
        }

        public static Post GetInvalidIdPost()
        {
            return new Post()
            {
                Id = 0,
                Message = "asd",
                PostDate = DateTime.Now
            };
        }

        public static Post GetNoMessagePost()
        {
            return new Post()
            {
                Id = 1,
                Message = " ",
                PostDate = DateTime.Now
            };
        }

        public static Post GetMessageOverflowPost()
        {
            return new Post()
            {
                Id = 1,
                Message = "asdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasd",
                PostDate = DateTime.Now
            };
        }

        public static Post GetInvalidPostDatePost()
        {
            return new Post()
            {
                Id = 1,
                Message = "asd",
                PostDate = DateTime.Now.AddYears(+1)
            };
        }
    }
}

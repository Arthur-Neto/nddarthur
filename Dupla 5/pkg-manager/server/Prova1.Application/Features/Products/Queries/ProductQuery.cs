using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova1.Application.Features.Products.Queries
{
    public class ProductQuery
    {
        public virtual int Size { get; set; }

        public ProductQuery(int _size)
        {
            Size = _size;
        }
    }
}

using System.Data.Entity;
using System.Linq;
using Prova1.Domain.Exceptions;
using Prova1.Domain.Features.Products;
using Prova1.Domain.Products;
using Prova1.Infra.ORM.Contexts;

namespace Prova1.Infra.ORM.Features.Products
{
    public class ProductRepository : IProductRepository
    {
        private Prova1DbContext _context;

        public ProductRepository(Prova1DbContext context)
        {
            _context = context;
        }

        #region ADD

        public Product Add(Product product)
        {
            var newCustomer = _context.Products.Add(product);
            _context.SaveChanges();
            return newCustomer;
        }

        #endregion

        #region GET
        public IQueryable<Product> GetAll(int size)
        {
            return this._context.Products.Take(size);
        }

        public IQueryable<Product> GetAll()
        {
            return this._context.Products;
        }

        public Product GetById(int productId)
        {
            return _context.Products.FirstOrDefault(c => c.Id == productId);
        }
        #endregion

        #region REMOVE
        public bool Remove(int productId)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
                throw new NotFoundException();
            _context.Entry(product).State = EntityState.Deleted;
            return _context.SaveChanges() > 0;
        }
        #endregion

        #region UPDATE

        public bool Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        #endregion
    }
}

using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDao
    {

        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInstock=15},
                new Product{ProductId=1,CategoryId=1,ProductName="Kamera",UnitPrice=15,UnitsInstock=15},
                new Product{ProductId=1,CategoryId=1,ProductName="Telefon",UnitPrice=15,UnitsInstock=15},
                new Product{ProductId=1,CategoryId=1,ProductName="Klavye",UnitPrice=15,UnitsInstock=15},
                new Product{ProductId=1,CategoryId=1,ProductName="Fare",UnitPrice=15,UnitsInstock=15},
            };
        }
      
        public void add(Product product)
        {
            throw new NotImplementedException();
        }

        public void delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public Product get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> getAll()
        {
            return _products;
        }

        public List<Product> getAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> getAllByCategory(int CategoryId)
        {
            return _products.Where(p => p.CategoryId == CategoryId).ToList();
        }

        public void update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInstock = product.UnitsInstock;

        }
    }
}

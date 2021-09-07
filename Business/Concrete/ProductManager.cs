using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDao _productDao;

        public ProductManager(IProductDao productDao)
        {
            _productDao = productDao;
        }

        public List<Product> getAll()
        {
            return _productDao.getAll();
        }

        public List<Product> getAllByategoryId(int id)
        {
            return _productDao.getAll(p => p.CategoryId == id);
        }

        public List<Product> getByUnitPrice(decimal min, decimal max)
        {
            return _productDao.getAll(p => p.UnitPrice>=min  && p.UnitPrice < max);;
        }
    }
}

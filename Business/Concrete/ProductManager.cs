using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public IResult add(Product product)
        {
            if (product.ProductName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalıd);
            }
            _productDao.add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> getAll()
        {
            if (DateTime.Now.Hour == 04)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            } 
            return new SuccessDataResult<List<Product>>(_productDao.getAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> getAllByategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDao.getAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> getById(int productId)
        {
            return new SuccessDataResult<Product>(_productDao.get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> getByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDao.getAll(p => p.UnitPrice>=min  && p.UnitPrice < max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDao.GetProductDetails());
        }
    }
}

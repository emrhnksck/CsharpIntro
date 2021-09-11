using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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
        ICategoryService _categoryService;

        public ProductManager(IProductDao productDao,ICategoryService categoryService)
        {
            _productDao = productDao;
            _categoryService = categoryService;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult add(Product product)
        {
            
            IResult result = BusinessRules.run(checkIfProductNameExist(product.ProductName),
                checkIfProductCountOfCategoryCorrect(product.CategoryId),checkIfCategoryLimitExceded());

            if (result != null)
            {
                return result;
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

        [ValidationAspect(typeof(ProductValidator))]
        public IResult update(Product product)
        {
            throw new NotImplementedException();
        }
    
        private IResult checkIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDao.getAll(p => p.CategoryId == categoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult checkIfProductNameExist(string productName)
        {
            var result = _productDao.getAll(p => p.ProductName == productName).Any();
            if (result )
            {
                return new ErrorResult(Messages.ProductNameAlreadyExist);
            }
            return new SuccessResult();
        }

        private IResult checkIfCategoryLimitExceded()
        {
            var result = _categoryService.getAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }
    }
}

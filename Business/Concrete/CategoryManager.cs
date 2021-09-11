using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {

        ICategoryDao _categoryDao;

        public CategoryManager(ICategoryDao categoryDao)
        {
            _categoryDao = categoryDao;
        }

        public IDataResult<List<Category>> getAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDao.getAll());
        }

        public IDataResult<Category> getById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDao.get(c => c.CategoryId == categoryId));
        }
    }
}

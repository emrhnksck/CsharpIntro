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
    public class CategoryManager : ICategoryService
    {

        ICategoryDao _categoryDao;

        public CategoryManager(ICategoryDao categoryDao)
        {
            _categoryDao = categoryDao;
        }

        public List<Category> getAll()
        {
            return _categoryDao.getAll();
        }

        public Category getById(int categoryId)
        {
            return _categoryDao.get(c => c.CategoryId == categoryId);
        }
    }
}

using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDao : ICategoryDao
    {
        public void add(Category entity)
        { 
            throw new NotImplementedException();
        }

        public void delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public Category get(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Category> getAll(Expression<Func<Category, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}

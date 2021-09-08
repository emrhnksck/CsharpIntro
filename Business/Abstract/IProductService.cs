using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> getAll();
        List<Product> getAllByategoryId(int id);
        List<Product> getByUnitPrice(decimal min, decimal max);

        List<ProductDetailDto> GetProductDetails();


    }
}

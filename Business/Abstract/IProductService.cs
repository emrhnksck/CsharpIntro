﻿using Core.Utilities.Results;
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
        IDataResult<List<Product>> getAll();
        IDataResult<List<Product>> getAllByategoryId(int id);
        IDataResult<List<Product>> getByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IResult add(Product product);
        IDataResult<Product> getById(int productId);
        IResult update(Product product);

    }
}

using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //Loosely coupled
        private IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult getAll()
        {
            var result = productService.getAll();
            if (result.success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
            
        [HttpPost("add")]
        public IActionResult add(Product product)
        {
            var result = productService.add(product);
            if (result.success==false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult getById(int id)
        {
            var result = productService.getById(id);
            if(result.success == false)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}

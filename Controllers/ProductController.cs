using System;
using System.Collections.Generic;
using Entity_Framework_2.Models;
using Entity_Framework_2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Entity_Framework_2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("/products")]
        public List<Product> GetAll()
        {
            return _productService.GetAll();
        }

        [HttpGet("/product/{id}")]
        public ActionResult<Product> GetOne(int id)
        {
            return _productService.GetOne(id);
        }

        [HttpPost("/product")]
        public Product Create(ProductDTO product)
        {
            return _productService.Create(product);
        }

        [HttpPut("/product")]
        public Product Edit(ProductDTO product)
        {
            return _productService.Edit(product);
        }

        [HttpDelete("/product/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _productService.Delete(id);

                return Ok();

            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
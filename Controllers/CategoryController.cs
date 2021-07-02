using System;
using System.Collections.Generic;
using Entity_Framework_2.Models;
using Entity_Framework_2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Entity_Framework_2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("/categories")]
        public List<Category> GetAll()
        {
            return _categoryService.GetAll();
        }

        [HttpGet("/category/{id}")]
        public ActionResult<Category> GetOne(int id)
        {
            return _categoryService.GetOne(id);
        }

        [HttpPost("/category")]
        public Category Create(CategoryDTO category)
        {
            return _categoryService.Create(category);
        }

        [HttpPut("/category")]
        public Category Edit(CategoryDTO category)
        {
            return _categoryService.Edit(category);
        }

        [HttpDelete("/category/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _categoryService.Delete(id);

                return Ok();

            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
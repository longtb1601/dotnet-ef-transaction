using System;
using System.Collections.Generic;
using System.Linq;
using Entity_Framework_2.Models;

namespace Entity_Framework_2.Services
{
    public class CategoryService : ICategoryService
    {
        private ProductContext _productContext;
        public CategoryService(ProductContext productContext)
        {
            _productContext = productContext;
        }
        public Category GetOne(int id) 
        {
            var category = _productContext.Categories.FirstOrDefault(c => c.CategoryId == id);

            return category;
        }
        public List<Category> GetAll()
        {
            return _productContext.Categories.ToList();
        }
        public Category Create(CategoryDTO category)
        {
             using var transaction = _productContext.Database.BeginTransaction(); //using transaction

            try
            {
                var newCategory = new Category {
                    CategoryName = category.CategoryName
                };

                _productContext.Categories.Add(newCategory);
                _productContext.SaveChanges();

                transaction.Commit(); 

                return newCategory;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Delete(int id)
        {
            var category = _productContext.Categories.FirstOrDefault(c => c.CategoryId == id);

            using var transaction = _productContext.Database.BeginTransaction(); //using transaction

            try 
            {
                List<Product> productsDelete = _productContext.Products.Where(p => p.CategoryId == id).ToList();

                _productContext.Products.RemoveRange(productsDelete);

                _productContext.Categories.Remove(category);

                _productContext.SaveChanges();

                transaction.Commit(); 

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Category Edit(CategoryDTO category)
        {
            var categoryEdit = _productContext.Categories.FirstOrDefault(c => c.CategoryId == category.Id);

            using var transaction = _productContext.Database.BeginTransaction(); //using transaction

            try
            {
                categoryEdit.CategoryName = category.CategoryName;
                _productContext.SaveChanges();

                transaction.Commit(); 

                return categoryEdit;

            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
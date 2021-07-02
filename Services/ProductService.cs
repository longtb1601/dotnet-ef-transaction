using System;
using System.Collections.Generic;
using System.Linq;
using Entity_Framework_2.Models;

namespace Entity_Framework_2.Services
{
    public class ProductService : IProductService
    {
        private ProductContext _productContext;
        public ProductService(ProductContext productContext)
        {
            _productContext = productContext;
        }
        public Product GetOne(int id) 
        {
            var product = _productContext.Products.FirstOrDefault(p => p.ProductId == id);

            return product;
        }
        public List<Product> GetAll()
        {
            return _productContext.Products.ToList();
        }
        public Product Create(ProductDTO product)
        {
            using var transaction = _productContext.Database.BeginTransaction(); //using transaction

            try
            {
                var newProduct = new Product {
                    ProductName = product.ProductName,
                    Manufacturer = product.Manufacturer,
                    CategoryId = product.CategoryId,
                };

                _productContext.Products.Add(newProduct);
                _productContext.SaveChanges();

                transaction.Commit(); 

                return newProduct;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void Delete(int id)
        {
            var product = _productContext.Products.FirstOrDefault(p => p.ProductId == id);

            _productContext.Remove(product);

            _productContext.SaveChanges();
        }

        public Product Edit(ProductDTO product)
        {
            var productEdit = _productContext.Products.FirstOrDefault(p => p.ProductId == product.Id);

            using var transaction = _productContext.Database.BeginTransaction(); //using transaction

            try
            {
                productEdit.ProductName = product.ProductName;
                productEdit.Manufacturer = product.Manufacturer;
                productEdit.CategoryId = product.CategoryId;
                _productContext.SaveChanges();

                transaction.Commit(); 

                return productEdit;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
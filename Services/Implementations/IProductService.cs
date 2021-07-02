using System.Collections.Generic;
using Entity_Framework_2.Models;

namespace Entity_Framework_2.Services
{
    public interface IProductService
    {
        Product GetOne(int id);
        List<Product> GetAll();
        Product Create(ProductDTO model);
        Product Edit(ProductDTO model);
        void Delete(int id);
    }
}
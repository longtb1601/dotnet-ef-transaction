using System.Collections.Generic;
using Entity_Framework_2.Models;

namespace Entity_Framework_2.Services
{
    public interface ICategoryService
    {
        Category GetOne(int id);
        List<Category> GetAll();
        Category Create(CategoryDTO model);
        Category Edit(CategoryDTO model);
        bool Delete(int id);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using OrderOut.DtosOU.Dtos;
using OrderOut.EF.Models;

namespace OrderOut.Services.category
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();
        Task<Category> GetCategory(long categoryId);
        Task<bool> CreateCategory(CategoryDto request);
        Task<bool> UpdateCategory(Category request);
        Task<bool> DeleteCategory(long categoryId);
    }
}

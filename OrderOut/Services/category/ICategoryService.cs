using System.Collections.Generic;
using System.Threading.Tasks;
using OrderOut.EF.Models;

namespace OrderOut.Services.category
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();
        Task<Category> GetCategory(int categoryId);
        Task<bool> CreateCategory(Category request);
        Task<bool> UpdateCategory(Category request);
        Task<bool> DeleteCategory(long categoryId);
    }
}

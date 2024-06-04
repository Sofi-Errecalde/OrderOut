using Microsoft.AspNetCore.Mvc;
using OrderOut.EF.Models;
using OrderOut.Services.category;

namespace OrderOut.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("GetCategory")]
        public async Task<Category> GetCategory(int categoryId)
        {
            return await _categoryService.GetCategory(categoryId);
        }

        [HttpGet]
        [Route("AllCategories")]
        public async Task<List<Category>> AllCategories()
        {
            return  await _categoryService.GetAllCategories();
        }

        [HttpPost]
        [Route("CreateCategory")]
        public Task<bool> CreateCategory(Category category)
        {
            return  _categoryService.CreateCategory(category);
        }

        [HttpPut]
        [Route("UpdateCategory")]
        public Task<bool> UpdateCategory(Category category)
        {
            return  _categoryService.UpdateCategory(category);
        }

        [HttpDelete]
        [Route("DeleteCategory")]
        public Task<bool> DeleteCategory(long categoryId)
        {
            return  _categoryService.DeleteCategory(categoryId);
        }
    }
}

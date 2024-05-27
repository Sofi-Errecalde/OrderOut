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
        public Category GetCategory(int categoryId)
        {
            return _categoryService.GetCategory(categoryId);
        }

        [HttpGet]
        [Route("AllCategories")]
        public List<Category> AllCategories()
        {
            return  _categoryService.GetAllCategories();
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
        public Task<bool> DeleteCategory(int categoryId)
        {
            return  _categoryService.DeleteCategory(categoryId);
        }
    }
}

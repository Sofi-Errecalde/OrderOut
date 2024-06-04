using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using OrderOut.EF.Models;
using OrderOut.Repositorys;

namespace OrderOut.Services.category
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository,
                               IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            var categories =  await _categoryRepository.GetAllCategories();
            var response = _mapper.Map<List<Category>>(categories);
            return response;
        }

        public async Task<Category> GetCategory(int categoryId)
        {
            var category = await  _categoryRepository.GetCategory(categoryId);
            var response = _mapper.Map<Category>(category);
            return response;
        }

        public  Task<bool> CreateCategory(Category request)
        {
            var newCategory =  _mapper.Map<Category>(request);
            var response =   _categoryRepository.CreateCategory(newCategory);
            return response;
        }

        public Task<bool> UpdateCategory(Category request)
        {
            var category = _mapper.Map<Category>(request);
            var response =   _categoryRepository.UpdateCategory(category);
            return response;
        }

        public Task<bool> DeleteCategory(long categoryId)
        {
            var response =   _categoryRepository.DeleteCategory(categoryId);
            return response;
        }
    }
}

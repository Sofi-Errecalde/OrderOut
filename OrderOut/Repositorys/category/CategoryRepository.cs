using System.Collections.Generic;
using System.Threading.Tasks;
using DBContext;
using Microsoft.EntityFrameworkCore;
using OrderOut.EF;
using OrderOut.EF.Models;

namespace OrderOut.Repositorys
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _context.Categories.Where(x => x.IsDeleted == false).ToListAsync();
        }

        public async Task<Category?> GetCategory(long categoryId)
        {
            return await _context.Categories.Where(x => x.Id == categoryId && !x.IsDeleted).FirstOrDefaultAsync();
        }

        public async Task<bool> CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCategory(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCategory(long categoryId)
        {
            var category = await _context.Categories.Where(x => x.Id == categoryId).FirstOrDefaultAsync();
            if (category != null)
            {
                try
                {
                    category.IsDeleted = true;
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return false;
        }
    }
}

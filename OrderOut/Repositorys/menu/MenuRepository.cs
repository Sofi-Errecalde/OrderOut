using System.Collections.Generic;
using System.Threading.Tasks;
using DBContext;
using Microsoft.EntityFrameworkCore;
using OrderOut.EF;
using OrderOut.EF.Models;

namespace OrderOut.Repositorys
{
    public class MenuRepository : IMenuRepository
    {
        private readonly AppDbContext _context;

        public MenuRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<List<Menu>> GetAllMenus()
        {
            return _context.Menus.Where(x => !x.IsDeleted).ToListAsync();
        }

        public  Task<Menu?> GetMenu(int menuId)
        {
            return   _context.Menus.Where(x => x.Id == menuId && x.IsDeleted).FirstOrDefaultAsync();
        }

        public  bool CreateMenu(Menu menu)
        {
            _context.Menus.Add(menu);
              _context.SaveChangesAsync();
            return true;
        }

        public  bool UpdateMenu(Menu menu)
        {
            _context.Entry(menu).State = EntityState.Modified;
              _context.SaveChangesAsync();
            return true;
        }

        public  bool DeleteMenu(int menuId)
        {
            var menu =   _context.Menus.FindAsync(menuId);
              _context.SaveChangesAsync();
            return true;
        }
    }
}

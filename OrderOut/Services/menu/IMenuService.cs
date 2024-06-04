
using OrderOut.EF.Models;

namespace OrderOut.Services.menu
{
    public interface IMenuService
    {
        Task<List<Menu>> GetAllMenus();
        Task<Menu> GetMenu(int menuId);
        bool CreateMenu(Menu request);
        bool UpdateMenu(Menu request);
        bool DeleteMenu(int menuId);
    }
}

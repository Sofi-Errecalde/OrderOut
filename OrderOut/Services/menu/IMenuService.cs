using System.Collections.Generic;
using System.Threading.Tasks;
using OrderOut.Dtos;
using OrderOut.EF.Models;

namespace OrderOut.Services.menu
{
    public interface IMenuService
    {
        List<Menu> GetAllMenus();
        Menu GetMenu(int menuId);
        bool CreateMenu(Menu request);
        bool UpdateMenu(Menu request);
        bool DeleteMenu(int menuId);
    }
}

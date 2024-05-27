using System.Collections.Generic;
using System.Threading.Tasks;
using OrderOut.EF.Models;

namespace OrderOut.Repositorys
{
    public interface IMenuRepository
    {
        Task<List<Menu>> GetAllMenus();
        Task<Menu?> GetMenu(int menuId);
        bool CreateMenu(Menu menu);
        bool UpdateMenu(Menu menu);
        bool DeleteMenu(int menuId);
    }
}
